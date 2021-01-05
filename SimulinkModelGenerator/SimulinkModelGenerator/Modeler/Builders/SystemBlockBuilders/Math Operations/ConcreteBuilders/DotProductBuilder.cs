﻿using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class DotProductBuilder : MathOperationBuilder<ProductBuilder>, IDotProduct
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected override string BlockType => "DotProduct";
        protected override string BlockName => "Dot Product";
        protected override string OutDataTypeStr => "Inherit: Inherit via internal rule";


        public DotProductBuilder(Model model)
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