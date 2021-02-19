using System;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class SimulationTimeBuilder : ISolverSimulationTime
    {
        private readonly Model model;

        public SimulationTimeBuilder(Model model)
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
        public void Set(double startTime = 0, double stopTime = 10)
        {
            if (startTime < 0)
                startTime = 0;

            stopTime = Math.Abs(stopTime);

            if (startTime >= stopTime)
                throw new ArgumentException("Simulation stop time must be greater than start time.");

            SimulationTime simulationTime = model.ConfigSet.Solver.SimulationTime;

            simulationTime.StartTime = startTime.ToString();
            simulationTime.StopTime = stopTime.ToString();
        }
    }
}
