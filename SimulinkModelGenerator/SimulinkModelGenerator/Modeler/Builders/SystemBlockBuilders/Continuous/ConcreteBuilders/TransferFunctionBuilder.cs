using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;
using SimulinkModelGenerator.Exceptions;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class TransferFunctionBuilder : SystemBlockBuilder<TransferFunctionBuilder>, ITransferFunction
    {
        private string _Numerator = null;
        private string _Denominator = "[1 1]";

        private int _NumeratorCount = 0;
        private int _DenominatorCount = 2;

        public TransferFunctionBuilder(ModelInformation modelInformation)
            : base(modelInformation)
        {

        }


        public ITransferFunction SetNumerator(params decimal[] coefficients)
        {
            if (coefficients.Length > 0)
            {
                _Numerator = $"[{string.Join(" ", coefficients)}]";
                _NumeratorCount = coefficients.Length;
            }

            return this;
        }

        public ITransferFunction SetDenominator(params decimal[] coefficients)
        {
            if (coefficients.Length == 0)
            {
                throw new SimulinkModelGeneratorException("Denominator can not have zero number of coefficients!");
            }
            else if (coefficients.Length == 1)
            {
                if (coefficients[0] == 0)
                    throw new SimulinkModelGeneratorException("The order of the transfer function numerator must be less than or equal to the order of the denominator!");
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
                throw new SimulinkModelGeneratorException("The order of the transfer function numerator must be less than or equal to the order of the denominator!");

            List<P> list = new List<P>()
            {
                new P() { Name = "Position", Text = base._Position },
                new P() { Name = "ZOrder", Text = base._ZOrder },
                new P() { Name = "Denominator", Text = _Denominator }
            };

            if(_NumeratorCount > 0)
            {
                list.Add(new P() { Name = "Numerator", Text = _Numerator });
            }

            base.modelInformation.Model.System.Block.Add(new Block()
            {
                BlockType = "TransferFcn",
                Name = base.GetName("TransferFcn"),
                SID = base._SID,
                P = list
            });         
        }
    }
}
