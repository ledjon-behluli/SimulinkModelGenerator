using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Common;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public abstract class BaseSquareRootBuilder<T> : MathOperationBuilder<T>
        where T : BaseSquareRootBuilder<T>
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected abstract string Operator { get; }

        protected override string BlockType => "Sqrt";
        protected override string OutDataTypeStr => "Inherit: Inherit via internal rule";

        protected OutputSignalType _OutputSignalType = OutputSignalType.Auto;
        protected RootFindingAlgorithm _Algorithm = RootFindingAlgorithm.Exact;
        protected string _NumberOfIterations = "3";

        public BaseSquareRootBuilder(Model model)
            : base(model)
        {

        }

        protected T SetNumberOfIterations(int count)
        {
            if (count < 0)
                throw new ArgumentException("Number of iterations can not be less than 0");

            _NumberOfIterations = count.ToString();
            return (T)this;
        }

        protected T WithAlgorithm(RootFindingAlgorithm algorithm)
        {
            _Algorithm = algorithm;
            return (T)this;
        }

        protected T WithOutputSignal(OutputSignalType type)
        {
            _OutputSignalType = type;
            return (T)this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "OutputSignalType", Text = _OutputSignalType.GetDescription() });
            block.P.Add(new Parameter() { Name = "Operator", Text = Operator });
            block.P.Add(new Parameter() { Name = "AlgorithmType", Text = _Algorithm.GetDescription() });
            block.P.Add(new Parameter() { Name = "Iterations", Text = _NumberOfIterations });

            model.System.Block.Add(block);
        }
    }

    public sealed class SquareRootBuilder : BaseSquareRootBuilder<SquareRootBuilder>, ISqrt
    {
        protected override string Operator => "sqrt";
        protected override string BlockName => "Sqrt";

        public SquareRootBuilder(Model model)
            : base(model)
        {

        }

        public new ISqrt WithOutputSignal(OutputSignalType type) => base.WithOutputSignal(type);
    }

    public sealed class SignedSquareRootBuilder : BaseSquareRootBuilder<SignedSquareRootBuilder>, ISignedSqrt
    {
        protected override string Operator => "signedSqrt";
        protected override string BlockName => "Signed\\nSqrt";

        public SignedSquareRootBuilder(Model model)
            : base(model)
        {

        }

        public new ISignedSqrt WithOutputSignal(OutputSignalType type) => base.WithOutputSignal(type);
    }

    public sealed class ReciprocalSquareRootBuilder : BaseSquareRootBuilder<ReciprocalSquareRootBuilder>, IReciprocalSqrt
    {
        protected override string Operator => "rSqrt";
        protected override string BlockName => "Reciprocal\\nSqrt";

        public ReciprocalSquareRootBuilder(Model model)
            : base(model)
        {

        }

        public new IReciprocalSqrt WithAlgorithm(RootFindingAlgorithm algorithm) => base.WithAlgorithm(algorithm);

        public new IReciprocalSqrt SetNumberOfIterations(int count) => base.SetNumberOfIterations(count);
    }
}
