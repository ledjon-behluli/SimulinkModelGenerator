using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimulinkModelGenerator
{
    public enum TimeSourceType
    {
        [Description("Use simulation time")]
        SimulationTime,
        [Description("User external signal")]
        ExternalSignal
    }
}

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public abstract class GeneratorBuilder<T> : SystemBlockBuilder<T>, IGenerator
        where T : GeneratorBuilder<T>
    {
        internal override SizeU Size => new SizeU(30, 30);
        protected abstract string BlockType { get; }
        protected abstract string BlockName { get; }

        protected string _Amplitude = "1";
        protected TimeSourceType _TimeSourceType;
        private string _Ports => _TimeSourceType == TimeSourceType.SimulationTime ? "[0 1]" : "[1 1]";


        internal GeneratorBuilder(Model model)
            : base(model)
        {

        }

        public IGenerator WithTimeSource(TimeSourceType type)
        {
            _TimeSourceType = type;
            return this;
        }

        public IGenerator SetAmplitude(double amplitude)
        {
            _Amplitude = amplitude.ToString();
            return this;
        }


        internal virtual Block GetBlock()
        {
            return new Block()
            {
                BlockType = BlockType,
                BlockName = GenerateUniqueName(BlockName),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = _Position },
                    new Parameter() { Name = "BlockMirror", Text = _BlockMirror },
                    new Parameter() { Name = "Ports", Text = _Ports },
                    new Parameter() { Name = "Amplitude", Text = _Amplitude },
                    new Parameter() { Name = "TimeSource", Text = _TimeSourceType.GetDescription() },
                    new Parameter() { Name = "VectorParams1D", Text = "on" }
                }
            };
        }
    }
}
