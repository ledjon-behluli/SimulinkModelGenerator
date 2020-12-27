using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders
{
    public enum IconDisplay
    {
        [Description("Port number")]
        PortNumber,
        [Description("Signal name")]
        SignalName,
        [Description("Port number and signal name")]
        Both
    }

    public sealed class InportBuilder : SystemBlockBuilder<InportBuilder>, IInport
    {
        internal override SizeU Size => new SizeU(30, 14);

        private string _PortNumber = string.Empty;
        private IconDisplay _IconDisplay = IconDisplay.PortNumber;

        public InportBuilder(Model model)
            : base(model)
        {

        }

        /// <summary>
        /// Position of port on parent block.
        /// </summary>
        public IInport SetPortNumber(int port)
        {
            if (port < 1 || port > 65535)
                throw new ArgumentException("Port number must be a positive integer constant between 1 and 65535");

            _PortNumber = port.ToString();
            return this;
        }

        /// <summary>
        /// Specify the information displayed on the block icon.
        /// </summary>
        public IInport WithIconDisplay(IconDisplay iconDisplay)
        {
            _IconDisplay = iconDisplay;
            return this;
        }

        internal override void Build()
        {
            int _count = GetBlockTypeCount("Inport");
            string _portNumber = string.IsNullOrEmpty(_PortNumber) ? (_count + 1).ToString() : _PortNumber;

            base.model.System.Block.Add(new Block()
            {
                BlockType = "Inport",
                Name = $"In{_count + 1}",
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "Port", Text = _portNumber },
                    new Parameter() { Name = "IconDisplay", Text = _IconDisplay.GetDescription() }
                }
            });
        }
    }
}
