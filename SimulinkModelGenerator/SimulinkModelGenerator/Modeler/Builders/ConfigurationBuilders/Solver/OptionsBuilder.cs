using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class OptionsBuilder : ISolverOptions
    {
        private readonly Model model;

        public OptionsBuilder(Model model)
        {
            this.model = model;
        }
    }
}
