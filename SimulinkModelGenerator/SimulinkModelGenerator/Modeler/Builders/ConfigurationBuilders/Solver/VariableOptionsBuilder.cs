using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class VariableOptionsBuilder : IVariableStepSolverOptions
    {
        private readonly Model model;

        public VariableOptionsBuilder(Model model)
        {
            this.model = model;
            SetSolverType(VariableSolver.Auto);
        }

        private void SetSolverType(VariableSolver solver)
        {
            model.ConfigSet.Solver.SolverOptions.Solver = solver.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = solver.GetDescription();
        }

        public IAutoVariableSolverType Auto() => throw new NotImplementedException();
        public IDiscreteVariableSolverType Discrete() => throw new NotImplementedException();
        public IOde45VariableSolverType Ode45() => throw new NotImplementedException();
        public IOde23VariableSolverType Ode23() => throw new NotImplementedException();
        public IOde113VariableSolverType Ode113() => throw new NotImplementedException();
        public IOde15sVariableSolverType Ode15s() => throw new NotImplementedException();
        public IOde23sVariableSolverType Ode23s() => throw new NotImplementedException();
        public IOde23tVariableSolverType Ode23t() => throw new NotImplementedException();
        public IOde23tbVariableSolverType Ode23tb() => throw new NotImplementedException();
    }
}

