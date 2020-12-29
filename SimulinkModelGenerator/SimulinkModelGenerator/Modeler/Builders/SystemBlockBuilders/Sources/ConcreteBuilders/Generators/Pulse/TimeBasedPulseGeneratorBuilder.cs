using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders.Generators.Pulse
{
    public sealed class TimeBasedPulseGeneratorBuilder : PulseGeneratorBuilder<TimeBasedPulseGeneratorBuilder>, 
        ITimeBasedPulseGenerator
    {
        protected override string PulseType => "Time based";

        public TimeBasedPulseGeneratorBuilder(Model model)
            : base(model)
        {

        }

        /// <param name="period">Period (secs)</param>
        public ITimeBasedPulseGenerator SetPeriod(double period)
        {
            if (period <= 0)
                throw new ArgumentException("Period must be greater than 0.");

            _Period = period.ToString();
            return this;
        }

        /// <param name="width">Pulse width (% of period)</param>
        public ITimeBasedPulseGenerator SetPulseWidth(double width)
        {
            if (width <= 0 || width >= 100)
                throw new ArgumentException("Pulse width must be exclusive between (0 - 100).");

            _PulseWidth = width.ToString();
            return this;
        }

        /// <param name="delay">Phase delay (secs)</param>
        public ITimeBasedPulseGenerator SetPhaseDelay(double delay)
        {
            if (delay < 0)
                throw new ArgumentException("Phase delay must be greater than or equal to 0.");

            _Period = delay.ToString();
            return this;
        }
        
    }
}
