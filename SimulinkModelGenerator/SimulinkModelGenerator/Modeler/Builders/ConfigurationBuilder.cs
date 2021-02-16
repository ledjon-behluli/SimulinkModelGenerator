using SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed class ConfigurationBuilder : IConfiguration
    {
        private readonly Model model;

        public ConfigurationBuilder(Model model)
        {
            model.ConfigSet = new ConfigSet()
            {
                Solver = ConfigSet.Solver.Default
            };

            this.model = model;
        }

        public IConfiguration ConfigureSolver(Action<SolverConfigurationBuilder> action = null)
        {
            SolverConfigurationBuilder<ConfigurationBuilder> builder = new SolverConfigurationBuilder<ConfigurationBuilder>(this, model);
            action?.Invoke(builder);
            return this;
        }
    }
}
