using System;
using System.Linq;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.ComponentModel;
using SimulinkModelGenerator.Exceptions;

namespace SimulinkModelGenerator
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

    public enum OutputSignalType
    {
        [Description("auto")]
        Auto,
        [Description("real")]
        Real,
        [Description("complex")]
        Complex
    }

    public enum RootFindingAlgorithm
    {
        [Description("Excat")]
        Exact,
        [Description("Newton-Raphson")]
        Newton_Raphson
    }
}

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders
{
    internal class SizeU
    {
        internal uint Width { get; private set; }
        internal uint Height { get; private set; }

        internal SizeU(uint width, uint height)
        {
            if (width == 0)
                throw new SimulinkModelGeneratorException("Only positive values for width are not allowed.");

            if (height == 0)
                throw new SimulinkModelGeneratorException("Only positive values for height are not allowed.");

            Width = width;
            Height = height;
        }
    }

    public abstract class SystemBlockBuilder
    {
        internal readonly Model model;

        internal string _Name;

        private string _position;
        protected string _Position
        {
            get => !string.IsNullOrEmpty(_position) ? _position : $"[0, 0, {Size.Width}, {Size.Height}]";
            set => _position = value;
        }

        internal abstract SizeU Size { get; }

        internal bool blockMirror = false;
        internal string _BlockMirror => blockMirror ? "on" : "off";

        internal SystemBlockBuilder(Model model)
        {
            this.model = model;
        }

        /// <summary>
        /// Generates a unique name by appending a number at the end of <paramref name="blockName"/>, if that name is already taken.
        /// <para>If <see cref="_Name"/> is already set, than this will be returned.</para>
        /// <para>If there are no other blocks with the same name, than <paramref name="blockName"/> will be returned.</para>
        /// </summary>
        protected string GenerateUniqueName(string blockName)
        {
            if (!string.IsNullOrEmpty(_Name))
                return _Name;

            var blocks = model.System.Block.Where(b => b.BlockName.StartsWith(blockName));
            if (blocks != null)
            {
                string number = blocks.Count() == 0 ? string.Empty : blocks.Count().ToString();
                return $"{blockName}{number}";
            }

            return blockName;
        }

        /// <summary>
        /// Get the total number of <see cref="Block"/>s with the same <paramref name="blockType"/>.
        /// </summary>
        protected int GetBlockTypeCount(string blockType)
        {
            return this.model.System.Block.Count(b => b.BlockType.Contains(blockType));
        }

        internal abstract void Build();
    }

    public abstract class SystemBlockBuilder<T> : SystemBlockBuilder
        where T : SystemBlockBuilder<T>, ISystemBlock
    {
        private readonly T _blockBuilderInstance;

        internal SystemBlockBuilder(Model model) 
            : base(model)
        {
            _blockBuilderInstance = (T)this;
        }

        public ISystemBlock WithName(string name)
        {
            base._Name = name;
            return _blockBuilderInstance;
        }

        public ISystemBlock SetPosition(uint x, uint y)
        {
            
            base._Position = $"[{x}, {y}, {x + Size.Width}, {y + Size.Height}]";
            return _blockBuilderInstance;
        }

        public ISystemBlock FlipHorizontally()
        {
            base.blockMirror = !base.blockMirror;
            return _blockBuilderInstance;
        }
    }
}
