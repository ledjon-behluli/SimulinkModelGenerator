using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;
using System.ComponentModel;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Exceptions;

namespace SimulinkModelGenerator
{
    public enum TrigonometricFunctionType
    {
        [Description("sin")]
        sin,
        [Description("cos")]
        cos,
        [Description("tan")]
        tan,
        [Description("asin")]
        asin,
        [Description("acos")]
        acos,
        [Description("atan")]
        atan,
        [Description("atan2")]
        atan2,
        [Description("sinh")]
        sinh,
        [Description("cosh")]
        cosh,
        [Description("tanh")]
        tanh,
        [Description("asinh")]
        asinh,
        [Description("acosh")]
        acosh,
        [Description("atanh")]
        atanh,
        [Description("sincos")]
        sincos,
        [Description("cos + jsin")]
        cos_jsin
    }
}

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    internal class TrigonometricFunctionBuilder : SystemBlockBuilder<TrigonometricFunctionBuilder>, 
        ITrigonometricFunction, IWithNoneApproximation, IWithCordicApproximation
    {
        private enum ApproximationMethod
        {
            [Description("None")]
            None,
            [Description("CORDIC")]
            CORDIC
        }

        internal override SizeU Size => new SizeU(30, 30);

        private string _Ports = "[1 1]";
        private string _NumberOfIterations = "11";
        private TrigonometricFunctionType _Operator = TrigonometricFunctionType.sin;
        private ApproximationMethod _Method = ApproximationMethod.None;
        private OutputSignalType _SignalType = OutputSignalType.Auto;

        internal TrigonometricFunctionBuilder(Model model)
            : base(model)
        {

        }

        public ITrigonometricFunction WithFunctionType(TrigonometricFunctionType type)
        {
            if (type == TrigonometricFunctionType.atan2)
                _Ports = "[2 1]";
            else if (type == TrigonometricFunctionType.sincos)
                _Ports = "[1 2]";
            else
                _Ports = "[1 1]";

            _Operator = type;
            return this;
        }

        public IWithNoneApproximation WithNoneApproximation()
        {
            _Method = ApproximationMethod.None;
            return this;
        }

        public ITrigonometricFunction WithOutputSignalType(OutputSignalType type)
        {
            _Method = ApproximationMethod.None;
            _SignalType = type;

            return this;
        }

        public IWithCordicApproximation WithCordicApproximation()
        {
            _Method = ApproximationMethod.CORDIC;
            _SignalType = OutputSignalType.Auto;

            return this;
        }

        public ITrigonometricFunction SetNumberOfIterations(int count)
        {
            if (count < 1)
                throw new SimulinkModelGeneratorException("Number of iterations must be greater than 0");

            _NumberOfIterations = count.ToString();
            return this;
        }


        internal override void Build()
        {
            model.System.Block.Add(new Block()
            {
                BlockType = "Trigonometry",
                BlockName = GenerateUniqueName("Trigonometry\\nFunction"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "Ports", Text = _Ports },
                    new Parameter() { Name = "Operator", Text = _Operator.GetDescription() },
                    new Parameter() { Name = "ApproximationMethod", Text = _Method.GetDescription() },
                    new Parameter() { Name = "NumberOfIterations", Text = _NumberOfIterations },
                    new Parameter() { Name = "OutputSignalType", Text = _SignalType.GetDescription() },
                    new Parameter() { Name = "SampleTime", Text = "-1" }
                }
            });
        }
    }
}
