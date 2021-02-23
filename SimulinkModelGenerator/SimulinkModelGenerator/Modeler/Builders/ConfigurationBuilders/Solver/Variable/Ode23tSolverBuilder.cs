using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    public class Ode23tSolverBuilder : IOde23tVariableSolverType
    {
        private readonly Model model;

        public Ode23tSolverBuilder(Model model)
        {
            model.ConfigSet.Solver.SolverOptions.Solver = VariableSolver.Ode23t.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = VariableSolver.Ode23t.GetDescription();

            this.model = model;
        }

        public IOde23tVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(initialStep, minStep, maxStep, numberOfConsecutiveMinSteps);
            return this;
        }

        public IOde23tVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetTolerance(relativeTolerance, absoluteTolerance);
            return this;
        }

        public IOde23tVariableSolverType WithShapePreservation(ShapePreservation shape)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ShapePreservation = shape;
            return this;
        }

        public IOde23tVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingAlgorithm = algorithm;
            return this;
        }

        public IOde23tVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingControl = control;
            return this;
        }

        public IOde23tVariableSolverType WithJacobian(Jacobian jacobian)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SolverJacobianMethodControl = jacobian;
            return this;
        }

        public IOde23tVariableSolverType WithReset(ResetMethod method)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SolverResetMethod = method;
            return this;
        }
    }
}
