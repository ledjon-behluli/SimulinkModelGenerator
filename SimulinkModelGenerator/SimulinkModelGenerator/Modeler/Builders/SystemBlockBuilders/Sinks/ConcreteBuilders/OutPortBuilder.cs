﻿using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    internal class OutPortBuilder : PortBuilder<OutPortBuilder>, IOutPort
    {
        protected override string BlockType => "Outport";
        protected override string BlockName => "Out";

        private string _SignalName = string.Empty;

        internal OutPortBuilder(Model model)
            : base(model)
        {

        }

        public IOutPort WithSignalName(string name)
        {
            _SignalName = name ?? string.Empty;
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "SignalName", Text = _SignalName });

            model.System.Block.Add(block);
        }
    }
}
