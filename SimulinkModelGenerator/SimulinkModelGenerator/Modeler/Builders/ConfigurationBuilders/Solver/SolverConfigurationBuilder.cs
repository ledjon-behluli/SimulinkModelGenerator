using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class SolverConfigurationBuilder : ISolverConfiguration
    {
        private readonly Model model;

        public SolverConfigurationBuilder(Model model)
        {
            this.model = model;
        }

        public ISolverConfiguration ConfigureSimulationTime(Action<SimulationTimeBuilder> action = null)
        {
            SimulationTimeBuilder builder = new SimulationTimeBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public ISolverConfiguration ConfigureOptions(Action<OptionsBuilder> action = null)
        {
            OptionsBuilder builder = new OptionsBuilder(model);
            action?.Invoke(builder);
            return this;
        }
    }
}
