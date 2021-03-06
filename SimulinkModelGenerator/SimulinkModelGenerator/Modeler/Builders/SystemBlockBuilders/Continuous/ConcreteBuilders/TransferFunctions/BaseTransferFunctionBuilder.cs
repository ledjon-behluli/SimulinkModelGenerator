﻿using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;
using SimulinkModelGenerator.Models;
using SimulinkModelGenerator.Exceptions;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    internal abstract class BaseTransferFunctionBuilder<T> : SystemBlockBuilder<T>
        where T : BaseTransferFunctionBuilder<T>, ISystemBlock
    {
        internal override SizeU Size => new SizeU(60, 36);
        internal abstract string BlockType { get; }
        internal abstract string BlockName { get; }

        protected string _Numerator = null;
        protected string _Denominator = "[1 1]";

        protected int _NumeratorCount;
        protected int _DenominatorCount;

        internal BaseTransferFunctionBuilder(Model model)
            : base(model)
        {
           
        }


        protected void SetNumerator(params double[] coefficients)
        {
            if (coefficients.Length > 0)
            {
                _Numerator = $"[{string.Join(" ", coefficients)}]";
                _NumeratorCount = coefficients.Length;
            }
        }

        protected void SetDenominator(params double[] coefficients)
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
        }

        internal Block GetBlock()
        {
            if (_NumeratorCount > _DenominatorCount)
                throw new SimulinkModelGeneratorException("The order of the transfer function numerator must be less than or equal to the order of the denominator!");

            List<Parameter> list = new List<Parameter>()
            {
                new Parameter() { Name = "Position", Text = base._Position },
                new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                new Parameter() { Name = "AbsoluteTolerance", Text = "auto" }
            };

            return new Block()
            {
                BlockType = BlockType,
                BlockName = GenerateUniqueName(BlockName),
                Parameters = list
            };
        }
    }
}