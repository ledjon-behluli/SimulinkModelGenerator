using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders
{  
    public sealed class ControlSystemBuilder : IControlSystem
    {
        private readonly Model model;

        internal ControlSystemBuilder(Model model)
        {
            model.System = new Models.System()
            {
                Block = new List<Block>(),
                Line = new List<Line>(),
                Name = model.Name
            };

            this.model = model;
        }

        public IControlSystem AddSources(Action<SystemSourcesBuilder> action = null)
        {
            SystemSourcesBuilder builder = new SystemSourcesBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public IControlSystem AddSinks(Action<SystemSinksBuilder> action = null)
        {
            SystemSinksBuilder builder = new SystemSinksBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public IControlSystem AddMathOperations(Action<SystemMathOperationsBuilder> action = null)
        {
            SystemMathOperationsBuilder builder = new SystemMathOperationsBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public IControlSystem AddContinuous(Action<SystemContinuousBuilder> action = null)
        {
            SystemContinuousBuilder builder = new SystemContinuousBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public IControlSystem AddConnections(string startingBlockName, Action<SystemLineBuilder> action = null)
        {
            SystemLineBuilder builder = new SystemLineBuilder(model, startingBlockName);
            action?.Invoke(builder);
            return this;
        }
    }
}
