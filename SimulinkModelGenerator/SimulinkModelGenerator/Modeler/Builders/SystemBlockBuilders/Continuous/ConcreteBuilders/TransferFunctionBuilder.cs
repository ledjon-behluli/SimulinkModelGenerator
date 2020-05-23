using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;
using SimulinkModelGenerator.Exceptions;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class TransferFunctionBuilder : SystemBlockBuilder<TransferFunctionBuilder>, ITransferFunction
    {
        internal override SizeU Size => new SizeU(60, 36);

        private string _Numerator = null;
        private string _Denominator = "[1 1]";

        private int _NumeratorCount = 0;
        private int _DenominatorCount = 2;

        public TransferFunctionBuilder(Model model)
            : base(model)
        {

        }


        public ITransferFunction SetNumerator(params double[] coefficients)
        {
            if (coefficients.Length > 0)
            {
                _Numerator = $"[{string.Join(" ", coefficients)}]";
                _NumeratorCount = coefficients.Length;
            }

            return this;
        }

        public ITransferFunction SetDenominator(params double[] coefficients)
        {
            if (coefficients.Length == 0)
            {
                throw new ArgumentException("Denominator can not have zero number of coefficients!");
            }
            else if (coefficients.Length == 1)
            {
                if (coefficients[0] == 0)
                    throw new InvalidOperationException("The order of the transfer function numerator must be less than or equal to the order of the denominator!");
                else
                {
                    _Denominator = $"[{coefficients[0]}]";
                    _DenominatorCount = 1;
                }
            }
            else
            {
                _Denominator = $"[{string.Join(" ", coefficients)}]";
                _DenominatorCount = coefficients.Length;
            }

            return this;
        }


        internal override void Build()
        {
            if (_NumeratorCount > _DenominatorCount)
                throw new InvalidOperationException("The order of the transfer function numerator must be less than or equal to the order of the denominator!");

            List<P> list = new List<P>()
            {
                new P() { Name = "Position", Text = base._Position },
                new P() { Name = "BlockMirror", Text = base.BlockMirror },
                new P() { Name = "Denominator", Text = _Denominator }
            };

            if(_NumeratorCount > 0)
            {
                list.Add(new P() { Name = "Numerator", Text = _Numerator });
            }

            base.model.System.Block.Add(new Block()
            {
                BlockType = "TransferFcn",
                Name = base.GetName("TransferFcn"),
                P = list
            });         
        }
    }
}
