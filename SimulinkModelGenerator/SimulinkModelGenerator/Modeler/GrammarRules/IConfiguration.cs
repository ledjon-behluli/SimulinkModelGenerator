using SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IConfiguration
    {
        IConfiguration ConfigureSolver(Action<SolverConfigurationBuilder> action = null);
    }

    public interface ISolverConfiguration
    {

    }
}
