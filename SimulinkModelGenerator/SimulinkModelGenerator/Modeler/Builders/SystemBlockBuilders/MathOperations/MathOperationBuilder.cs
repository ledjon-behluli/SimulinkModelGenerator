using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public enum IntegerRoundingMode
    {
        [Description("Ceiling")]
        Ceiling,
        [Description("Convergent")]
        Convergent,
        [Description("Floor")]
        Floor,
        [Description("Nearest")]
        Nearest,
        [Description("Round")]
        Round,
        [Description("Simplest")]
        Simplest,
        [Description("Zero")]
        Zero
    }

    public enum IconShape
    {
        [Description("round")]
        Round,

        [Description("rectangular")]
        Rectangular
    }

    public enum InputType
    {
        [Description("+")]
        Plus,

        [Description("-")]
        Minus
    }

    public abstract class MathOperationBuilder<T> : SystemBlockBuilder<T>, IMathOperation
        where T : MathOperationBuilder<T>
    {
        protected abstract string BlockType { get; }
        protected abstract string BlockName { get; }
        protected abstract string OutDataTypeStr { get; }

        protected double? _OutMin = null;
        protected double? _OutMax = null;
        protected bool _SaturateOnIntegerOverflow = false;
        protected bool _LockOutputDataType = false;
        protected bool _RequireAllInputsToHaveSameDataType = false;
        protected IntegerRoundingMode _RoundingMode = IntegerRoundingMode.Floor;

        public MathOperationBuilder(Model model)
            : base(model)
        {

        }

        public IMathOperation SaturateOnIntegerOverflow()
        {
            _SaturateOnIntegerOverflow = true;
            return this;
        }

        public IMathOperation DepriveOnIntegerOverflow()
        {
            _SaturateOnIntegerOverflow = false;
            return this;
        }

        public IMathOperation LockOutputDataType()
        {
            _LockOutputDataType = true;
            return this;
        }
         
        public IMathOperation UnlockOutputDataType()
        {
            _LockOutputDataType = false;
            return this;
        }

        public IMathOperation WithRoundingMode(IntegerRoundingMode mode)
        {
            _RoundingMode = mode;
            return this;
        }

        public IMathOperation SetMinimumOutputForRangeChecking(double value)
        {
            if (_OutMax != null && value > (double)_OutMax)
                throw new ArgumentException("Minimum output value must be less than or equal to maximum value.");

            _OutMin = value;
            return this;
        }

        public IMathOperation SetMaximumOutputForRangeChecking(double value)
        {
            if (_OutMin != null && value < (double)_OutMin)
                throw new ArgumentException("Maximum output value must be greater than or equal to minimum value.");

            _OutMax = value;
            return this;
        }

        protected Block GetBlock()
        {
            return new Block()
            {
                BlockType = BlockType,
                BlockName = GenerateUniqueName(BlockName),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "OutMin", Text = _OutMin != null ? $"[{_OutMin}]" : "[]" },
                    new Parameter() { Name = "OutMax", Text = _OutMax != null ? $"[{_OutMax}]" : "[]" },
                    new Parameter() { Name = "OutDataTypeStr", Text = OutDataTypeStr },
                    new Parameter() { Name = "LockScale", Text = _LockOutputDataType ? "on" : "off" },
                    new Parameter() { Name = "RndMeth", Text = _RoundingMode.GetDescription() },
                    new Parameter() { Name = "SaturateOnIntegerOverflow", Text = _SaturateOnIntegerOverflow ? "on" : "off" },
                    new Parameter() { Name = "SampleTime", Text = "-1" },
                    new Parameter() { Name = "InputSameDT", Text = _RequireAllInputsToHaveSameDataType ? "on" : "off" }
                }
            };
        }
    }
}
