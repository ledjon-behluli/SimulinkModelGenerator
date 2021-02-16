using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public abstract class SimulationTimeBuilder : ISolverSimulationTime
    {
        private readonly Model model;

        public SimulationTimeBuilder(Model model)
        {
            this.model = model;
        }

        public ISolverOptions Set(double startTime = 0, double stopTime = 10)
        {
            SimulationTime simulationTime = model.ConfigSet.Solver.SimulationTime;

            simulationTime.StartTime = startTime.ToString();
            simulationTime.StopTime = stopTime.ToString();

            return new OptionsBuilder(model);
        }

        public abstract ISolverConfiguration Done();
    }

    public sealed class SimulationTimeBuilder<T> : SimulationTimeBuilder
        where T : ISolverConfiguration
    {
        private readonly T instance;

        public SimulationTimeBuilder(T instance, Model model)
            : base(model)
        {
            this.instance = instance;
        }

        public override ISolverConfiguration Done() => instance;
    }
}
