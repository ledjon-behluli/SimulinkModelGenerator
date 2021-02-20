using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    public sealed class Ode23tbSolverBuilder : IOde23tbVariableSolverType
    {
        private readonly Model model;

        public Ode23tbSolverBuilder(Model model)
        {
            this.model = model;
        }

        public IOde23tbVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(initialStep, minStep, maxStep, numberOfConsecutiveMinSteps);
            return this;
        }

        public IOde23tbVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetTolerance(relativeTolerance, absoluteTolerance);
            return this;
        }

        public IOde23tbVariableSolverType WithShapePreservation(ShapePreservation shape)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetShapePreservation(shape);
            return this;
        }

        public IOde23tbVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetZeroCrossingAlgorithm(algorithm);
            return this;
        }

        public IOde23tbVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetZeroCrossingControl(control);
            return this;
        }

        public IOde23tbVariableSolverType WithJacobian(Jacobian jacobian)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetJacobian(jacobian);
            return this;
        }

        public IOde23tbVariableSolverType WithReset(ResetMethod method)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetResetMethod(method);
            return this;
        }
    }
}
