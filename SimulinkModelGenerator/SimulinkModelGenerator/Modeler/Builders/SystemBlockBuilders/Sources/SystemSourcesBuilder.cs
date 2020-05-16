using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class SystemSourcesBuilder : ISystemSource
    {
        private readonly Model model;

        public SystemSourcesBuilder(Model model)
        {
            this.model = model;
        }

       
        public ISystemSource AddConstant(Action<ConstantBuilder> action = null) => AddSource<ConstantBuilder>(action);
        public ISystemSource AddRamp(Action<RampBuilder> action = null) => AddSource<RampBuilder>(action);
        public ISystemSource AddStep(Action<StepBuilder> action = null) => AddSource<StepBuilder>(action);

        private ISystemSource AddSource<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(ConstantBuilder))
                builder = new ConstantBuilder(model);
            else if (systemBlockType == typeof(RampBuilder))
                builder = new RampBuilder(model);
            else if (systemBlockType == typeof(StepBuilder))
                builder = new StepBuilder(model);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported source builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
