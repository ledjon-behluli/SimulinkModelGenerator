using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Fixed
{
    public sealed class ExtrapolatedSolverBuilder : IExtrapolatedFixedSolverType
    {
        private readonly Model model;

        internal ExtrapolatedSolverBuilder(Model model)
        {
            this.model = model;
        }

        public IExtrapolatedFixedSolverType WithSampleTime(double sampleTime = 0.001)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SetSampleTime(sampleTime);
            return this;
        }

        public IExtrapolatedFixedSolverType WithJacobian(Jacobian jacobian)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SolverJacobianMethodControl = jacobian;
            return this;
        }

        public IExtrapolatedFixedSolverType WithNewtonInterations(int numberOfIterations = 1)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.NumberNewtonIterations = numberOfIterations;
            return this;
        }

        public IExtrapolatedFixedSolverType WithOrder(ExtrapolationOrder order)
        {
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.ExtrapolationOrder = order;
            return this;
        }
    }
}
