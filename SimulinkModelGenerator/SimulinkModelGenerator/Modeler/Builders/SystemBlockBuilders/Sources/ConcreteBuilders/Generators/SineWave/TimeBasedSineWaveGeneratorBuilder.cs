using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders.Generators.SineWave
{
    public sealed class TimeBasedSineWaveGeneratorBuilder : SineWaveGeneratorBuilder<TimeBasedSineWaveGeneratorBuilder>, ITimeBasedSineWaveGenerator
    {
        protected override string SineType => "Time based";

        private string _Frequency = "1";
        private string _Phase = "0";
        private string _SampleTime = "0";
        protected override string SampleTime => _SampleTime;

        public TimeBasedSineWaveGeneratorBuilder(Model model)
            : base(model)
        {

        }

        public new ITimeBasedSineWaveGenerator SetBias(double bias)
        {
            base.SetBias(bias);
            return this;
        }

        public ITimeBasedSineWaveGenerator SetFrequency(double frequency)
        {
            if (frequency <= 0)
                throw new ArgumentException("Frequency must be greater than 0.");

            _Frequency = frequency.ToString();
            return this;
        }

        public ITimeBasedSineWaveGenerator SetPhase(double phase)
        {
            _Phase = phase.ToString();
            return this;
        }

        public ITimeBasedSineWaveGenerator SetSampleTime(double sampleTime)
        {
            if (sampleTime < 0)
                throw new ArgumentException("Frequency must be greater than or equal to 0.");

            _SampleTime = sampleTime.ToString();
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "Frequency", Text = _Frequency });
            block.P.Add(new Parameter() { Name = "Phase", Text = _Phase });

            model.System.Block.Add(block);
        }
    }
}
