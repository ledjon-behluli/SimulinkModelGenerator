using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders
{
    public sealed class SolverConfigurationBuilder : ISolverConfiguration
    {
        private readonly Model model;

        public SolverConfigurationBuilder(Model model)
        {
            model.ConfigSet._Solver = ConfigSet.Solver.Default;
            this.model = model;
        }
    }
}
