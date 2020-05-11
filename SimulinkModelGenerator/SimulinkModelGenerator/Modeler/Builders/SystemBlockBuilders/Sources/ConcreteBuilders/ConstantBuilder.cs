using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class ConstantBuilder : SystemBlockBuilder<ConstantBuilder>, IConstant
    {
        internal override SizeU Size => new SizeU(30, 30);

        private string _Value = "1";

        public ConstantBuilder(Model model)
            : base(model)
        {

        }

        public IConstant SetValue(decimal value)
        {
            _Value = value.ToString();
            return this;
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Constant",
                Name = base.GetName("Constant"),
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "BlockMirror", Text = base.BlockMirror },
                    new P() { Name = "Value", Text = _Value }
                }
            });
        }
    }
}
