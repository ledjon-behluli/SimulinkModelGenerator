using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Common;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.ComponentModel;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public enum MathFunctionType
    {
        [Description("exp")]
        exp,
        [Description("log")]
        log,
        [Description("10^u")]
        _10_PowerOf_U,
        [Description("log10")]
        log10,
        [Description("magnitude^2")]
        magnitude_PowerOf_2,
        [Description("square")]
        square,
        [Description("pow")]
        pow,
        [Description("conj")]
        conj,
        [Description("reciprocal")]
        reciprocal,
        [Description("hypot")]
        hypot,
        [Description("rem")]
        rem,
        [Description("mod")]
        mod,
        [Description("transpose")]
        transpose,
        [Description("hermitian")]
        hermitian
    }

    public sealed class MathFunctionBuilder : MathOperationBuilder<MathFunctionBuilder>, IMathFunction
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected override string BlockType => "Math";
        protected override string BlockName => "Math\\nFunction";
        protected override string OutDataTypeStr => "Inherit: Same as first input";

        private string _Ports = "[1 1]";
        private MathFunctionType _Operator = MathFunctionType.exp;
        private OutputSignalType _SignalType = OutputSignalType.Auto;

        public MathFunctionBuilder(Model model)
            : base(model)
        {
            _SaturateOnIntegerOverflow = true;
        }

        public IMathFunction WithFunctionType(MathFunctionType type)
        {
            if (type == MathFunctionType.pow || type == MathFunctionType.hypot || type == MathFunctionType.rem || type == MathFunctionType.mod)
                _Ports = "[2 1]";
            else
                _Ports = "[1 1]";

            _Operator = type;
            return this;
        }

        public IMathFunction WithOutputSignalType(OutputSignalType type)
        {
            _SignalType = type;
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "Ports", Text = _Ports });
            block.P.Add(new Parameter() { Name = "OutputSignalType", Text = _SignalType.GetDescription() });
            block.P.Add(new Parameter() { Name = "Operator", Text = _Operator.GetDescription() });
            block.P.Add(new Parameter() { Name = "AlgorithmType", Text = RootFindingAlgorithm.Newton_Raphson.GetDescription() });
            block.P.Add(new Parameter() { Name = "Iterations", Text = "3" });
            block.P.Add(new Parameter() { Name = "IntermediateResultsDataTypeStr", Text = "Inherit: Inherit via internal rule" });

            model.System.Block.Add(block);
        }
    }
}
