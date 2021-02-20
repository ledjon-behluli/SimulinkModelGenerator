using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable
{
    public sealed class AutoSolverBuilder : IAutoVariableSolverType
    {
        private readonly Model model;

        public AutoSolverBuilder(Model model)
        {
            this.model = model;
        }


        public IAutoVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetStepSize(initialStep, minStep, maxStep, numberOfConsecutiveMinSteps);
            return this;
        }

        public IAutoVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetTolerance(relativeTolerance, absoluteTolerance);
            return this;
        }

        public IAutoVariableSolverType WithShapePreservation(ShapePreservation shape)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetShapePreservation(shape);
            return this;
        }

        public IAutoVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetZeroCrossingAlgorithm(algorithm);
            return this;
        }

        public IAutoVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetZeroCrossingControl(control);
            return this;
        }
    }
}
