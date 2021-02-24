using SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed class ConfigurationBuilder : IConfiguration
    {
        private readonly Model model;

        internal ConfigurationBuilder(Model model)
        {
            model.Array.ConfigSet = new ConfigSet()
            {
                Solver = Models.Solver.Default
            };

            this.model = model;
        }

        public IConfiguration Solver(Action<SolverConfigurationBuilder> action = null)
        {
            SolverConfigurationBuilder builder = new SolverConfigurationBuilder(model);
            action?.Invoke(builder);
            return this;
        }
    }
}
