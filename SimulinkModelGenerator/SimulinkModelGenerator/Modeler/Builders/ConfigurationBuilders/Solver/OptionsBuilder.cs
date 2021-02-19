using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class OptionsBuilder : ISolverOptions
    {
        private readonly Model model;

        public OptionsBuilder(Model model)
        {
            this.model = model;
        }

        public IVariableStepSolverOptions WithVariableStep() => new VariableOptionsBuilder(model);
        public IFixedStepSolverOptions WithFixedStep() => new FixedOptionsBuilder(model);
    }
}
