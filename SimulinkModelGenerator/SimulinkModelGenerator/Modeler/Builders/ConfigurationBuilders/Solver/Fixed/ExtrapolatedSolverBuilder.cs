using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Fixed
{
    public sealed class ExtrapolatedSolverBuilder : IExtrapolatedFixedSolverType
    {
        private readonly Model model;

        public ExtrapolatedSolverBuilder(Model model)
        {
            this.model = model;
        }

        public IExtrapolatedFixedSolverType WithSampleTime(double sampleTime = 0.001)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetSampleTime(sampleTime);
            return this;
        }

        public IExtrapolatedFixedSolverType WithJacobian(Jacobian jacobian)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SolverJacobianMethodControl = jacobian;
            return this;
        }

        public IExtrapolatedFixedSolverType WithNewtonInterations(int numberOfIterations = 1)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.NumberNewtonIterations = numberOfIterations;
            return this;
        }

        public IExtrapolatedFixedSolverType WithOrder(ExtrapolationOrder order)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.ExtrapolationOrder = order;
            return this;
        }
    }
}
