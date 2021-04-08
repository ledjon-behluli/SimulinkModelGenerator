using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    internal class DerivativeBuilder : SystemBlockBuilder<DerivativeBuilder>, IDerivative
    {
        internal override SizeU Size => new SizeU(30, 30);

        private string _Coefficient = "inf";

        internal DerivativeBuilder(Model model)
            : base(model)
        {

        }

        /// <summary>
        /// Set coefficient 'c' in the transfer function approximation s/(c*s + 1) used for linearization.
        /// </summary>
        public IDerivative SetCoefficient(double coefficient)
        {
            _Coefficient = coefficient.ToString();
            return this;
        }

        /// <summary>
        /// Sets coefficient 'c' to '+inf' in the transfer function approximation s/(c*s + 1) used for linearization.
        /// </summary>
        public IDerivative WithPositiveInfiniteCoefficient()
        {
            _Coefficient = "+inf";
            return this;
        }

        /// <summary>
        /// Sets coefficient 'c' to '-inf' in the transfer function approximation s/(c*s + 1) used for linearization.
        /// </summary>
        public IDerivative WithNegativeInfiniteCoefficient()
        {
            _Coefficient = "-inf";
            return this;
        }


        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Derivative",
                BlockName = GenerateUniqueName("Derivative"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "CoefficientInTFapproximation", Text = _Coefficient }
                }
            });
        }
    }
}
