using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    internal class DotProductBuilder : MathOperationBuilder<DotProductBuilder>, IDotProduct
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected override string BlockType => "DotProduct";
        protected override string BlockName => "Dot Product";
        protected override string OutDataTypeStr => "Inherit: Inherit via internal rule";


        internal DotProductBuilder(Model model)
            : base(model)
        {
            _RequireAllInputsToHaveSameDataType = true;
        }

        internal override void Build()
        {
            Block block = GetBlock();
            model.System.Block.Add(block);
        }
    }
}
