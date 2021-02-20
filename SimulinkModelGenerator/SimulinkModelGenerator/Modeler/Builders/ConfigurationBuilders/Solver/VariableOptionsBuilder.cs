using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Variable;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class VariableOptionsBuilder : IVariableStepSolverOptions
    {
        private readonly Model model;

        public VariableOptionsBuilder(Model model)
        {
            this.model = model;
            this.model.ConfigSet.Solver.SolverOptions.Solver = VariableSolver.Auto.GetDescription();
            this.model.ConfigSet.Solver.SolverOptions.SolverName = VariableSolver.Auto.GetDescription();
        }

        public IAutoVariableSolverType Auto() => new AutoSolverBuilder(model);
        public IDiscreteVariableSolverType Discrete() => new DiscreteSolverBuilder(model);
        public IOde45VariableSolverType Ode45() => new Ode45SolverBuilder(model);
        public IOde23VariableSolverType Ode23() => new Ode23SolverBuilder(model);
        public IOde113VariableSolverType Ode113() => new Ode113SolverBuilder(model);
        public IOde15sVariableSolverType Ode15s() => new Ode15sSolverBuilder(model);
        public IOde23sVariableSolverType Ode23s() => new Ode23sSolverBuilder(model);
        public IOde23tVariableSolverType Ode23t() => new Ode23tSolverBuilder(model);
        public IOde23tbVariableSolverType Ode23tb() => new Ode23tbSolverBuilder(model);
    }
}

