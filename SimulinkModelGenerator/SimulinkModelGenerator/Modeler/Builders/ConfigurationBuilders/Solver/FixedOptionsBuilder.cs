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

        public IIntrapolatedFixedSolverType Auto()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Auto.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Auto.GetDescription();

            return new IntrapolatedSolverBuilder(model);
        }

        public IIntrapolatedFixedSolverType Discrete()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Discrete.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Discrete.GetDescription();

            return new IntrapolatedSolverBuilder(model);
        }

        public IIntrapolatedFixedSolverType Ode8()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Ode8.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Ode8.GetDescription();

            return new IntrapolatedSolverBuilder(model);
        }

        public IIntrapolatedFixedSolverType Ode5()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Ode5.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Ode5.GetDescription();

            return new IntrapolatedSolverBuilder(model);
        }

        public IIntrapolatedFixedSolverType Ode4()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Ode4.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Ode4.GetDescription();

            return new IntrapolatedSolverBuilder(model);
        }

        public IIntrapolatedFixedSolverType Ode3()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Ode3.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Ode3.GetDescription();

            return new IntrapolatedSolverBuilder(model);
        }

        public IIntrapolatedFixedSolverType Ode2()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Ode2.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Ode2.GetDescription();

            return new IntrapolatedSolverBuilder(model);
        }

        public IIntrapolatedFixedSolverType Ode1()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Ode1.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Ode1.GetDescription();

            return new IntrapolatedSolverBuilder(model);
        }

        public IExtrapolatedFixedSolverType Ode14x()
        {
            model.ConfigSet.Solver.SolverOptions.Solver = FixedSolver.Ode14x.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = FixedSolver.Ode14x.GetDescription();

            return new ExtrapolatedSolverBuilder(model);
        }
    }
}
