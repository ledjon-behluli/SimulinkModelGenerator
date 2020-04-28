using System.Linq;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders
{
    public abstract class SystemBlockBuilder
    {
        protected readonly Model model;

        protected string _Name;        
        protected string _SID;
        protected string _Position;
        protected string _ZOrder;

        public SystemBlockBuilder(Model model)
        {
            this.model = model;
            this._SID = (this.model.System.Block.Max(b => int.Parse(b.SID)) + 1).ToString();
            this._ZOrder = this._SID;
        }
       
        protected string GetName(string blockType)
        {
            if (!string.IsNullOrEmpty(_Name))
                return _Name;

            var blocks = this.model.System.Block.Where(b => b.BlockType.Contains(blockType));
            if(blocks != null)
            {
                return blocks.Count().ToString();
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

        public ISystemBlock SetPosition(int x1, int y1, int x2, int y2)
        {
            base._Position = $"[{x1}, {y1}, {x2}, {y2}]";
            return _blockBuilderInstance;
        }
    }
}
