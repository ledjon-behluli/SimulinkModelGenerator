using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    public sealed class Ode23tbSolverBuilder : IOde23tbVariableSolverType
    {
        private readonly Model model;

        internal Ode23tbSolverBuilder(Model model)
        {
            model.Array.ConfigSet.Solver.SolverOptions.Solver = VariableSolver.Ode23tb.GetDescription();
            model.Array.ConfigSet.Solver.SolverOptions.SolverName = VariableSolver.Ode23tb.GetDescription();

            this.model = model;
        }

        public IOde23tbVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(initialStep, minStep, maxStep, numberOfConsecutiveMinSteps);
            return this;
        }

        public IOde23tbVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SetTolerance(relativeTolerance, absoluteTolerance);
            return this;
        }

        public IOde23tbVariableSolverType WithShapePreservation(ShapePreservation shape)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ShapePreservation = shape;
            return this;
        }

        public IOde23tbVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingAlgorithm = algorithm;
            return this;
        }

        public IOde23tbVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingControl = control;
            return this;
        }

        public IOde23tbVariableSolverType WithJacobian(Jacobian jacobian)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SolverJacobianMethodControl = jacobian;
            return this;
        }

        public IOde23tbVariableSolverType WithReset(ResetMethod method)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SolverResetMethod = method;
            return this;
        }
    }
}
