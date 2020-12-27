using System;
using System.Linq;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders
{
    internal class SizeU
    {
        internal uint Width { get; private set; }
        internal uint Height { get; private set; }

        internal SizeU(uint width, uint height)
        {
            if (width < 1)
                throw new ArgumentException("Zero or negative values for width are not allowed.");

            if (height < 1)
                throw new ArgumentException("Zero or negative values for height are not allowed.");

            Width = width;
            Height = height;
        }
    }

    public abstract class SystemBlockBuilder
    {
        protected readonly Model model;

        protected string _Name;

        private string _position;
        protected string _Position
        {
            get => !string.IsNullOrEmpty(_position) ? _position : $"[0, 0, {Size.Width}, {Size.Height}]";
            set => _position = value;
        }

        internal abstract SizeU Size { get; }

        internal bool blockMirror = false;
        protected string _BlockMirror => blockMirror ? "on" : "off";

        public SystemBlockBuilder(Model model)
        {
            this.model = model;
        }
       
        /// <summary>
        /// Get a new name for the <paramref name="blockType"/> by appending a number at the end if the name is taken.
        /// Otherwise returns the name of the <paramref name="blockType"/>.
        /// </summary>
        protected string GetName(string blockType)
        {
            if (!string.IsNullOrEmpty(_Name))
                return _Name;

            var blocks = this.model.System.Block.Where(b => b.BlockType.Contains(blockType));
            if(blocks != null)
            {
                string number = blocks.Count() == 0 ? string.Empty : blocks.Count().ToString();
                return $"{blockType}{number}";
            }

            return blockType;
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
      
        public SystemBlockBuilder(Model model) 
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
