using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class ZeroPoleBuilder : BaseTransferFunctionBuilder<ZeroPoleBuilder>, IZeroPole
    {
        internal override string BlockType => "ZeroPole";
        internal override string BlockName => "Zero-Pole";

        private string _Gain = "[1]";

        internal ZeroPoleBuilder(Model model)
            : base(model)
        {
            _Numerator = "[1]";
            _Denominator = "[0 -1]";
            _NumeratorCount = 0;
            _DenominatorCount = 2;
        }

        public IZeroPole SetZeros(params double[] coefficients)
        {
            SetNumerator(coefficients);
            return this;
        }

        public IZeroPole SetPoles(params double[] coefficients)
        {
            SetDenominator(coefficients);
            return this;
        }

        public IZeroPole SetGain(double gain)
        {
            _Gain = $"[{gain}]";
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            if (_NumeratorCount > 0)
            {
                block.Parameters.Add(new Parameter() { Name = "Zeros", Text = _Numerator });
            }

            block.Parameters.Add(new Parameter() { Name = "Poles", Text = _Denominator });
            block.Parameters.Add(new Parameter() { Name = "Gain", Text = _Gain });

            model.System.Block.Add(block);
        }
    }
}