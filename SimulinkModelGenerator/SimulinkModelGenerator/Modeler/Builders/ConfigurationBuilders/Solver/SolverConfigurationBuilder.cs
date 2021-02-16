using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public abstract class SolverConfigurationBuilder : ISolverConfiguration
    {
        private readonly Model model;

        public SolverConfigurationBuilder(Model model)
        {
            this.model = model;
        }

        public ISolverConfiguration ConfigureSimulationTime(Action<SimulationTimeBuilder> action = null)
        {
            SimulationTimeBuilder<SolverConfigurationBuilder> builder = new SimulationTimeBuilder<SolverConfigurationBuilder>(this, model);
            action?.Invoke(builder);
            return this;
        }

        public ISolverConfiguration ConfigureOptions(Action<OptionsBuilder> action = null)
        {
            OptionsBuilder builder = new OptionsBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public abstract IConfiguration Done();
    }

    public sealed class SolverConfigurationBuilder<T> : SolverConfigurationBuilder
        where T : IConfiguration
    {
        private readonly T instance;

        public SolverConfigurationBuilder(T instance, Model model)
            : base(model)
        {
            this.instance = instance;
        }

        public override IConfiguration Done() => instance;
    }
}
