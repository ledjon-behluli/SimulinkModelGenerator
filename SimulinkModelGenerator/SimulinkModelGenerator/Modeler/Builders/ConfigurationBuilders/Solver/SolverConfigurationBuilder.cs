using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class SolverConfigurationBuilder : ISolverConfiguration
    {
        private readonly Model model;

        internal SolverConfigurationBuilder(Model model)
        {
            this.model = model;
        }

        /// <summary>
        /// <list type="bullet">
        /// <item><description>If <paramref name="startTime"/> &lt; 0, than it will be set to 0.</description></item>
        /// <item><description>If <paramref name="stopTime"/> &lt; 0, than it will be set to its absolute value.</description></item>
        /// <item><description>Invalid input: <paramref name="startTime"/> &gt; <paramref name="stopTime"/>.</description></item>
        /// </list>
        /// </summary>
        /// <param name="startTime">Simulation start time.</param>
        /// <param name="stopTime">Simulation stop time.</param>
        /// <exception cref="ArgumentException" />
        public ISolverConfiguration SetSimulationTimes(double startTime = 0, double stopTime = 10)
        {
            if (startTime < 0)
                startTime = 0;

            stopTime = Math.Abs(stopTime);

            if (startTime >= stopTime)
                throw new ArgumentException("Simulation stop time must be greater than start time.");

            model.Array.ConfigSet.Solver.SimulationTime.StartTime = startTime;
            model.Array.ConfigSet.Solver.SimulationTime.StopTime = stopTime;

            return this;
        }

        public ISolverConfiguration Options(Action<OptionsBuilder> action = null)
        {
            OptionsBuilder builder = new OptionsBuilder(model);
            action?.Invoke(builder);
            return this;
        }
    }
}
