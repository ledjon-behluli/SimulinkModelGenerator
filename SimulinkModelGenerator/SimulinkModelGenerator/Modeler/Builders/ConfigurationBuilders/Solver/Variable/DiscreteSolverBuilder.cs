using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    internal class DiscreteSolverBuilder : IDiscreteVariableSolverType
    {
        private readonly Model model;

        internal DiscreteSolverBuilder(Model model)
        {
            model.Array.ConfigSet.Solver.SolverOptions.Solver = VariableSolver.Discrete.GetDescription();
            model.Array.ConfigSet.Solver.SolverOptions.SolverName = VariableSolver.Discrete.GetDescription();

            this.model = model;
        }

        public IDiscreteVariableSolverType WithStepSize(double? maxStep = null)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(maxStep: maxStep);
            return this;
        }

        public IDiscreteVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingAlgorithm = algorithm;
            return this;
        }

        public IDiscreteVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingControl = control;
            return this;
        }
    }
}
