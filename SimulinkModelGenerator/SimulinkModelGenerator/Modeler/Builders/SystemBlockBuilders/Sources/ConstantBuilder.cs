using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class ConstantBuilder : SystemBlockBuilder<ConstantBuilder>, IConstant
    {
        private string _Value = "1";

        public ConstantBuilder(ModelInformation modelInformation)
            : base(modelInformation)
        {

        }

        public IConstant SetValue(decimal value)
        {
            _Value = value.ToString();
            return this;
        }

        internal override void Build()
        {
            base.modelInformation.Model.System.Block.Add(new Block()
            {
                BlockType = "Constant",
                Name = base.GetName("Constant"),
                SID = base._SID,
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "ZOrder", Text = base._ZOrder },
                    new P() { Name = "Value", Text = _Value }
                }
            });
        }
    }
}
