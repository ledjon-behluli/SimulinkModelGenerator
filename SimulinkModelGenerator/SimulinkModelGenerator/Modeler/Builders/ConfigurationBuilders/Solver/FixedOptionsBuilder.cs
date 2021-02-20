using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Fixed;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed partial class FixedOptionsBuilder : IFixedStepSolverOptions
    {
        private readonly Model model;

        public FixedOptionsBuilder(Model model)
        {
            this.model = model;
            this.model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Auto.GetDescription();
            this.model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Auto.GetDescription();
        }
       
        public IIntrapolatedFixedSolverType Auto() => new IntrapolatedSolverBuilder(model);
        public IIntrapolatedFixedSolverType Discrete() => new IntrapolatedSolverBuilder(model);
        public IIntrapolatedFixedSolverType Ode8() => new IntrapolatedSolverBuilder(model);
        public IIntrapolatedFixedSolverType Ode5() => new IntrapolatedSolverBuilder(model);
        public IIntrapolatedFixedSolverType Ode4() => new IntrapolatedSolverBuilder(model);
        public IIntrapolatedFixedSolverType Ode3() => new IntrapolatedSolverBuilder(model);
        public IIntrapolatedFixedSolverType Ode2() => new IntrapolatedSolverBuilder(model);
        public IIntrapolatedFixedSolverType Ode1() => new IntrapolatedSolverBuilder(model);
        public IExtrapolatedFixedSolverType Ode14x() => new ExtrapolatedSolverBuilder(model);
    }
}
