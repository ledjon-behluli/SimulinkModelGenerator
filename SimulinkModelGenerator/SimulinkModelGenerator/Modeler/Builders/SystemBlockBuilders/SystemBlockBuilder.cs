using System;
using System.Linq;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders
{
    public abstract class SystemBlockBuilder
    {
        protected readonly Model model;

        protected string _Name;     
        protected string _Position;

        internal bool blockMirror = false;
        protected string BlockMirror => blockMirror ? "on" : "off";

        public SystemBlockBuilder(Model model)
        {
            this.model = model;
        }
       
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

        public virtual ISystemBlock SetPosition(uint x, uint y, uint width, uint height)
        {
            if (width < 1)
                throw new ArgumentException("Zero or negative values for width are not allowed.");

            if(height < 1)
                throw new ArgumentException("Zero or negative values for height are not allowed.");

            base._Position = $"[{x}, {y}, {x + width}, {y + height}]";
            return _blockBuilderInstance;
        }

        public ISystemBlock FlipHorizontally()
        {
            base.blockMirror = !base.blockMirror;
            return _blockBuilderInstance;
        }
    }
}
