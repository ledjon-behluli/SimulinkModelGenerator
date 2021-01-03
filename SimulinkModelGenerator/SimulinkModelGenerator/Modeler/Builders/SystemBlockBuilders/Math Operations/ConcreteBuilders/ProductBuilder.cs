using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class ProductBuilder : MathOperationBuilder<ProductBuilder>, IProduct
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected override string BlockType => "Product";
        protected override string BlockName => "Product";
        protected override string OutDataTypeStr => "Inherit: Inherit via internal rule";

        private string _Ports = "[2 1]";
        private string _NumberOfInputs = "2";

        public ProductBuilder(Model model)
            : base(model)
        {

        }

        public IProduct SetNumberOfInputs(int count)
        {
            if(count >= 1)
            {
                _NumberOfInputs = count.ToString();
                _Ports = $"[{count} 1]";
            }
            else
                throw new ArgumentException("A minimum of 1 input is required!");

            return this;
        }


        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "Ports", Text = _Ports });
            block.P.Add(new Parameter() { Name = "Inputs", Text = _NumberOfInputs });

            model.System.Block.Add(block);
        }
    }
}
