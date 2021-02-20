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
            model.ConfigSet.Solver.AdditionalSolverOptions.SetJacobian(jacobian);
            return this;
        }

        public IExtrapolatedFixedSolverType WithNewtonInterations(int number = 1)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetNewtonInterations(number);
            return this;
        }

        public IExtrapolatedFixedSolverType WithOrder(ExtrapolationOrder order)
        {
            model.ConfigSet.Solver.AdditionalSolverOptions.SetExtrapolationOrder(order);
            return this;
        }
    }
}
