using SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders;
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
            model.ConfigSet = new ConfigSet();
            this.model = model;
        }

        public IConfiguration ConfigureSolver(Action<SolverConfigurationBuilder> action = null)
        {
            SolverConfigurationBuilder builder = new SolverConfigurationBuilder(model);
            action?.Invoke(builder);
            return this;
        }
    }
}
