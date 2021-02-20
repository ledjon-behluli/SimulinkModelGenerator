using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    public sealed class Ode113SolverBuilder : IOde113VariableSolverType
    {
        private readonly Model model;

        public Ode113SolverBuilder(Model model)
        {
            this.model = model;
        }

        public IOde113VariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(initialStep, minStep, maxStep, numberOfConsecutiveMinSteps);
            return this;
        }

        public IOde113VariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetTolerance(relativeTolerance, absoluteTolerance);
            return this;
        }

        public IOde113VariableSolverType WithShapePreservation(ShapePreservation shape)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetShapePreservation(shape);
            return this;
        }

        public IOde113VariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetZeroCrossingAlgorithm(algorithm);
            return this;
        }

        public IOde113VariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetZeroCrossingControl(control);
            return this;
        }
    }
}
