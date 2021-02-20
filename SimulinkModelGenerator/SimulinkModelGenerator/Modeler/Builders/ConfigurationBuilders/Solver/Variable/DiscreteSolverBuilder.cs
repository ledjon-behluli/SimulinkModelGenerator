using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    public sealed class DiscreteSolverBuilder : IDiscreteVariableSolverType
    {
        private readonly Model model;

        public DiscreteSolverBuilder(Model model)
        {
            this.model = model;
        }

        public IDiscreteVariableSolverType WithStepSize(double? maxStep = null)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(maxStep: maxStep);
            return this;
        }

        public IDiscreteVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetZeroCrossingAlgorithm(algorithm);
            return this;
        }

        public IDiscreteVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetZeroCrossingControl(control);
            return this;
        }
    }
}
