using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
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
                BlockName = GenerateUniqueName("Constant"),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "Value", Text = _Value }
                }
            });
        }
    }
}
