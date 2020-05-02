using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class ScopeBuilder : SystemBlockBuilder<ScopeBuilder>, IScope
    {
        private string _NumInputPorts = "1";
        private string _Ports = "[1]";

        public ScopeBuilder(Model model)
            : base(model)
        {

        }

        public IScope SetInputPorts(uint numberOfPorts)
        {
            if (numberOfPorts > 0)
            {
                _NumInputPorts = numberOfPorts.ToString();
                _Ports = $"[{numberOfPorts}]";
            }
            else
                throw new ArgumentException("Scope can not have less than 1 port!");

            return this;
        }

        public override ISystemBlock SetPosition(uint x, uint y, uint width = 30, uint height = 32)
        {
            return base.SetPosition(x, y, width, height);
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Scope",
                Name = base.GetName("Scope"),
                P = new List<P>()
                {
                    new P() { Name = "Ports", Text = _Ports },
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "BlockMirror", Text = base.BlockMirror },
                    new P() { Name = "NumInputPorts", Text = _NumInputPorts }
                }
            });
        }
    }
}