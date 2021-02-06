using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using SimulinkModelGenerator.Extensions;
using System.ComponentModel;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public enum MinMaxType
    {
        [Description("min")]
        Min,
        [Description("max")]
        Max
    }

    public abstract class MinMaxBuilder<T> : MathOperationBuilder<T>, IMinMax
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

        public MinMaxBuilder(Model model)
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
                throw new ArgumentException("A minimum of 1 input is required!");

            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "Ports", Text = _Ports });
            block.P.Add(new Parameter() { Name = "Inputs", Text = _NumberOfInputs });
            block.P.Add(new Parameter() { Name = "ZeroCross", Text = _EnableZeroCrossingDetection ? "on" : "off" });
            block.P.Add(new Parameter() { Name = "Function", Text = _FunctionType.GetDescription() });

            model.System.Block.Add(block);
        }
    }

    public sealed class MinBuilder : MinMaxBuilder<MinBuilder>
    {
        protected override MinMaxType _FunctionType => MinMaxType.Min;

        public MinBuilder(Model model)
            : base(model)
        {

        }
    }

    public sealed class MaxBuilder : MinMaxBuilder<MaxBuilder>
    {
        protected override MinMaxType _FunctionType => MinMaxType.Max;

        public MaxBuilder(Model model)
            : base(model)
        {

        }
    }
}
