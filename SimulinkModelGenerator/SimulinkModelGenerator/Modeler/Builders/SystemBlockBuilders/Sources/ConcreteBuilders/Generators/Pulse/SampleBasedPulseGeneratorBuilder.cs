using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class SampleBasedPulseGeneratorBuilder : PulseGeneratorBuilder<SampleBasedPulseGeneratorBuilder>, 
        ISampleBasedPulseGenerator
    {
        protected override string PulseType => "Sample based";

        public SampleBasedPulseGeneratorBuilder(Model model)
            : base(model)
        {

        }

        /// <param name="period">Period (number of samples)</param>
        public ISampleBasedPulseGenerator SetPeriod(int period)
        {
            if (period <= 0)
                throw new ArgumentException("Period must be greater than 0.");

            _Period = period.ToString();
            return this;
        }

        /// <param name="width">Pulse width (number of samples)</param>
        public ISampleBasedPulseGenerator SetPulseWidth(int width)
        {
            if (width > double.Parse(_Period))
                throw new SimulinkModelGeneratorException("Pulse width must be less than or equal to Period.");

            _PulseWidth = width.ToString();
            return this;
        }

        /// <param name="delay">Phase delay (number of samples)</param>
        public ISampleBasedPulseGenerator SetPhaseDelay(int delay)
        {
            if (delay < 0)
                throw new ArgumentException("Phase delay must be greater than or equal to 0.");

            _Period = delay.ToString();
            return this;
        }

        /// <param name="sampleTime">Sample time</param>
        public ISampleBasedPulseGenerator SetSampleTime(double sampleTime)
        {
            if (sampleTime < 0)
                throw new ArgumentException("Sample time must be greater than or equal to 0.");

            _SampleTime = sampleTime.ToString();
            return this;
        }
    }
}