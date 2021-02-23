using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    public sealed class Ode23sSolverBuilder : IOde23sVariableSolverType
    {
        private readonly Model model;

        public Ode23sSolverBuilder(Model model)
        {
            model.ConfigSet.Solver.SolverOptions.Solver = VariableSolver.Ode23s.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = VariableSolver.Ode23s.GetDescription();

            this.model = model;
        }

        public IOde23sVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(initialStep, minStep, maxStep, numberOfConsecutiveMinSteps);
            return this;
        }

        public IOde23sVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetTolerance(relativeTolerance, absoluteTolerance);
            return this;
        }

        public IOde23sVariableSolverType WithShapePreservation(ShapePreservation shape)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ShapePreservation = shape;
            return this;
        }

        public IOde23sVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingAlgorithm = algorithm;
            return this;
        }

        public IOde23sVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingControl = control;
            return this;
        }

        public IOde23sVariableSolverType WithJacobian(Jacobian jacobian)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SolverJacobianMethodControl = jacobian;
            return this;
        }
    }
}
