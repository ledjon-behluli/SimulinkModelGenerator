using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using SimulinkModelGenerator.Extensions;
using System.ComponentModel;
using SimulinkModelGenerator.Exceptions;

namespace SimulinkModelGenerator
{
    public enum MinMaxType
    {
        [Description("min")]
        Min,
        [Description("max")]
        Max
    }
}

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    internal abstract class MinMaxBuilder<T> : MathOperationBuilder<T>, IMinMax
        where T : MinMaxBuilder<T>
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected override string BlockType => "MinMax";
        protected override string BlockName => "MinMax";
        protected override string OutDataTypeStr => "Inherit: Inherit via internal rule";

        protected abstract MinMaxType _FunctionType { get; }

        private bool _EnableZeroCrossingDetection = true;
        private string _Ports = "[2 1]";
        private string _NumberOfInputs = "2";

        internal MinMaxBuilder(Model model)
            : base(model)
        {
            
        }

        public IMinMax DisableZeroCrossingDetection()
        {
            _EnableZeroCrossingDetection = false;
            return this;
        }

        public IMinMax SetNumberOfInputs(int count)
        {
            if (count >= 1)
            {
                _NumberOfInputs = count.ToString();
                _Ports = $"[{count} 1]";
            }
            else
                throw new SimulinkModelGeneratorException("A minimum of 1 input is required!");

            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "Ports", Text = _Ports });
            block.Parameters.Add(new Parameter() { Name = "Inputs", Text = _NumberOfInputs });
            block.Parameters.Add(new Parameter() { Name = "ZeroCross", Text = _EnableZeroCrossingDetection ? "on" : "off" });
            block.Parameters.Add(new Parameter() { Name = "Function", Text = _FunctionType.GetDescription() });

            model.System.Block.Add(block);
        }
    }

    internal class MinBuilder : MinMaxBuilder<MinBuilder>, IMin
    {
        protected override MinMaxType _FunctionType => MinMaxType.Min;

        internal MinBuilder(Model model)
            : base(model)
        {

        }
    }

    internal class MaxBuilder : MinMaxBuilder<MaxBuilder>, IMax
    {
        protected override MinMaxType _FunctionType => MinMaxType.Max;

        internal MaxBuilder(Model model)
            : base(model)
        {

        }
    }
}
