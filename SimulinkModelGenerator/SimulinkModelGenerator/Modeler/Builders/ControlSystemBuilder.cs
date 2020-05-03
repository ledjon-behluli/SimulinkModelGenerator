﻿using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders
{  
    public sealed class ControlSystemBuilder : IControlSystem, IControlSystemNewConnection
    {
        private readonly Model model;

        public ControlSystemBuilder(Model model)
        {
            model.System = new System()
            {
                Block = new List<Block>(),
                Line = new List<Line>()
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


        public IControlSystemLine Connect(string sourceBlockName, string destinationBlockName)
        {            
            SystemLineBuilder builder = new SystemLineBuilder(this, model, sourceBlockName);
            return builder.Build(sourceBlockName, destinationBlockName);
        }
    }
}
