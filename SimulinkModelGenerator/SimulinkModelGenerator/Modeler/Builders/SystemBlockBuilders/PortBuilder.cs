using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders
{
    public abstract class PortBuilder<T> : SystemBlockBuilder<T>, IPort
        where T : PortBuilder<T>
    {
        internal override SizeU Size => new SizeU(30, 14);

        protected abstract string BlockType { get; }
        protected abstract string BlockName { get; }

        private string _PortNumber = string.Empty;
        private IconDisplay _IconDisplay = IconDisplay.PortNumber;

        internal PortBuilder(Model model)
            : base(model)
        {

        }

        /// <summary>
        /// Position of port on parent block.
        /// </summary>
        public IPort SetPortNumber(int port)
        {
            if (port < 1 || port > 65535)
                throw new ArgumentException("Port number must be a positive integer constant between 1 and 65535");

            _PortNumber = port.ToString();
            return this;
        }

        /// <summary>
        /// Specify the information displayed on the block icon.
        /// </summary>
        public IPort WithIconDisplay(IconDisplay iconDisplay)
        {
            _IconDisplay = iconDisplay;
            return this;
        }

        internal Block GetBlock()
        {
            int _count = GetBlockTypeCount(BlockType);
            string _portNumber = string.IsNullOrEmpty(_PortNumber) ? (_count + 1).ToString() : _PortNumber;

            return new Block()
            {
                BlockType = BlockType,
                BlockName = $"{BlockName}{_count + 1}",
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "Port", Text = _portNumber },
                    new Parameter() { Name = "IconDisplay", Text = _IconDisplay.GetDescription() }
                }
            };
        }
    }
}
