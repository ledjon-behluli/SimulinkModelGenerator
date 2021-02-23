using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    public class Ode45SolverBuilder : IOde45VariableSolverType
    {
        private readonly Model model;

        public Ode45SolverBuilder(Model model)
        {
            model.ConfigSet.Solver.SolverOptions.Solver = VariableSolver.Ode45.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = VariableSolver.Ode45.GetDescription();

            this.model = model;
        }

        public IOde45VariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(initialStep, minStep, maxStep, numberOfConsecutiveMinSteps);
            return this;
        }

        public IOde45VariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetTolerance(relativeTolerance, absoluteTolerance);
            return this;
        }

        public IOde45VariableSolverType WithShapePreservation(ShapePreservation shape)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ShapePreservation = shape;
            return this;
        }

        public IOde45VariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingAlgorithm = algorithm;
            return this;
        }

        public IOde45VariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ZeroCrossingControl = control;
            return this;
        }
    }
}
