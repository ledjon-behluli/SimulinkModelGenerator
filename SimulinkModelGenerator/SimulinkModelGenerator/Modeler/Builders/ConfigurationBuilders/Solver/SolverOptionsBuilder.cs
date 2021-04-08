using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    internal class SolverOptionsBuilder : ISolverOptions
    {
        private readonly Model model;

        internal SolverOptionsBuilder(Model model)
        {
            this.model = model;
        }

        public IVariableStepSolverOptions AsVariableStepSolver() => new VariableOptionsBuilder(model);
        public IFixedStepSolverOptions AsFixedStepSolver() => new FixedOptionsBuilder(model);
    }
}
