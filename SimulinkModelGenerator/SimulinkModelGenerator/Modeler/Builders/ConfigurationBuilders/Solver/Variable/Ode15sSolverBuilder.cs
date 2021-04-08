using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    internal class Ode15sSolverBuilder : IOde15sVariableSolverType
    {
        private readonly Model model;

        internal Ode15sSolverBuilder(Model model)
        {
            model.Array.ConfigSet.Solver.SolverOptions.Solver = VariableSolver.Ode15s.GetDescription();
            model.Array.ConfigSet.Solver.SolverOptions.SolverName = VariableSolver.Ode15s.GetDescription();

            this.model = model;
        }

        public IOde15sVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(initialStep, minStep, maxStep, numberOfConsecutiveMinSteps);
            return this;
        }

        public IOde15sVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SetTolerance(relativeTolerance, absoluteTolerance);
            return this;
        }

        public IOde15sVariableSolverType WithShapePreservation(ShapePreservation shape)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ShapePreservation = shape;
            return this;
        }

        public IOde15sVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingAlgorithm = algorithm;
            return this;
        }

        public IOde15sVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingControl = control;
            return this;
        }

        public IOde15sVariableSolverType WithJacobian(Jacobian jacobian)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SolverJacobianMethodControl = jacobian;
            return this;
        }

        public IOde15sVariableSolverType WithOrder(MaximumOrder order)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.MaxOrder = order;
            return this;
        }

        public IOde15sVariableSolverType WithReset(ResetMethod method)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SolverResetMethod = method;
            return this;
        }
    }
}
