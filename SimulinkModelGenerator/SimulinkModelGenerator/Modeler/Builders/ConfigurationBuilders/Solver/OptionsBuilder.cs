﻿using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class OptionsBuilder : ISolverOptions
    {
        private readonly Model model;

        internal OptionsBuilder(Model model)
        {
            this.model = model;
        }

        public IVariableStepSolverOptions AsVariableStepSolver() => new VariableOptionsBuilder(model);
        public IFixedStepSolverOptions AsFixedStepSolver() => new FixedOptionsBuilder(model);
    }
}
