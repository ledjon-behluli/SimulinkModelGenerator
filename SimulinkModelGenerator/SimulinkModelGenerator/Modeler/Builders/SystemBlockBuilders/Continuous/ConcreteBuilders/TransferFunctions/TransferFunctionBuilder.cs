using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class TransferFunctionBuilder : BaseTransferFunctionBuilder<TransferFunctionBuilder>, ITransferFunction
    {
        internal override string BlockType => "TransferFcn";
        internal override string BlockName => "TransferFcn";

        internal TransferFunctionBuilder(Model model)
            : base(model)
        {
            _Numerator = "[1]";
            _Denominator = "[1 1]";
            _NumeratorCount = 0;
            _DenominatorCount = 2;
        }

        public new ITransferFunction SetNumerator(params double[] coefficients)
        {
            base.SetNumerator(coefficients);
            return this;
        }

        public new ITransferFunction SetDenominator(params double[] coefficients)
        {
            base.SetDenominator(coefficients);
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            if (_NumeratorCount > 0)
            {
                block.Parameters.Add(new Parameter() { Name = "Numerator", Text = _Numerator });
            }

            block.Parameters.Add(new Parameter() { Name = "Denominator", Text = _Denominator });

            model.System.Block.Add(block);
        }
    }
}
