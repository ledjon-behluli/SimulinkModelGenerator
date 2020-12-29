using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders.Generators.SineWave
{
    public abstract class SineWaveGeneratorBuilder<T> : GeneratorBuilder<T>
        where T : SineWaveGeneratorBuilder<T>
    {
        protected override string BlockType => "Sin";
        protected override string BlockName => "Sine Wave";
        protected abstract string SineType { get; }
        protected abstract string SampleTime { get; }

        protected string _Bias = "0";


        public SineWaveGeneratorBuilder(Model model)
            : base(model)
        {

        }

        protected void SetBias(double bias)
        {
            _Bias = bias.ToString();
        }

        protected override Block GetBlock()
        {
            Block block = base.GetBlock();

            block.P.Add(new Parameter() { Name = "SineType", Text = SineType });
            block.P.Add(new Parameter() { Name = "Bias", Text = _Bias });
            block.P.Add(new Parameter() { Name = "SampleTime", Text = SampleTime });

            return block;
        }
    }
}
