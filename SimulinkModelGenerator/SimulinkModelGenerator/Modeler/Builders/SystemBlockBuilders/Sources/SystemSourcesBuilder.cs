using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class SystemSourcesBuilder : ISystemSource
    {
        private readonly ModelInformation modelInformation;

        public SystemSourcesBuilder(ModelInformation modelInformation)
        {
            this.modelInformation = modelInformation;
        }

       
        public ISystemSource AddConstant(Action<ConstantBuilder> action = null) => AddSource<ConstantBuilder>(action);
        public ISystemSource AddRamp(Action<RampBuilder> action = null) => AddSource<RampBuilder>(action);
        public ISystemSource AddStep(Action<StepBuilder> action = null) => AddSource<StepBuilder>(action);

        private ISystemSource AddSource<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(ConstantBuilder))
                builder = new ConstantBuilder(modelInformation);
            else if (systemBlockType == typeof(RampBuilder))
                builder = new RampBuilder(modelInformation);
            else if (systemBlockType == typeof(StepBuilder))
                builder = new StepBuilder(modelInformation);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported source builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
