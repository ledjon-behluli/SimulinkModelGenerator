using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    internal class ProductBuilder : MathOperationBuilder<ProductBuilder>, IProduct
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected override string BlockType => "Product";
        protected override string BlockName => "Product";
        protected override string OutDataTypeStr => "Inherit: Inherit via internal rule";

        private string _Ports = "[2 1]";
        private string _NumberOfInputs = "2";

        internal ProductBuilder(Model model)
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
                throw new SimulinkModelGeneratorException("A minimum of 1 input is required!");

            return this;
        }


        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "Ports", Text = _Ports });
            block.Parameters.Add(new Parameter() { Name = "Inputs", Text = _NumberOfInputs });

            model.System.Block.Add(block);
        }
    }
}
