using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.ComponentModel;

namespace SimulinkModelGenerator
{
    public enum FrequencyUnit
    {
        [Description("rad/sec")]
        RadiansPerSec,
        [Description("Hertz")]
        Hertz
    }

    public enum WaveForm
    {
        [Description("sine")]
        Sine,
        [Description("square")]
        Square,
        [Description("sawtooth")]
        Sawtooth,
        [Description("random")]
        Random
    }
}

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class SignalGeneratorBuilder : GeneratorBuilder<SignalGeneratorBuilder>, ISignalGenerator
    {
        protected override string BlockType => "SignalGenerator";
        protected override string BlockName => "Signal\\nGenerator";

        private FrequencyUnit _Unit = FrequencyUnit.RadiansPerSec;
        private WaveForm _WaveForm = WaveForm.Sine;
        private string _Frequency = "1";

        internal SignalGeneratorBuilder(Model model)
            : base(model)
        {

        }

        public ISignalGenerator WithUnit(FrequencyUnit unit)
        {
            _Unit = unit;
            return this;
        }

        public ISignalGenerator WithWaveForm(WaveForm waveForm)
        {
            _WaveForm = waveForm;
            return this;
        }

        public ISignalGenerator SetFrequency(double frequency)
        {
            if (frequency < 0)
                throw new ArgumentException("Frequency must be greater than or equal to 0.");

            _Frequency = frequency.ToString();
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "WaveForm", Text = _WaveForm.GetDescription() });
            block.Parameters.Add(new Parameter() { Name = "Units", Text = _Unit.GetDescription() });
            block.Parameters.Add(new Parameter() { Name = "Frequency", Text = _Frequency });

            model.System.Block.Add(block);
        }
    }
}
