using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class SystemSinksBuilder : ISystemSink
    {
        private readonly ModelInformation modelInformation;

        public SystemSinksBuilder(ModelInformation modelInformation)
        {
            this.modelInformation = modelInformation;
        }
       
        public ISystemSink AddDisplay(Action<DisplayBuilder> action = null) => AddSink<DisplayBuilder>(action);
        public ISystemSink AddScope(Action<ScopeBuilder> action = null) => AddSink<ScopeBuilder>(action);

        private ISystemSink AddSink<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(DisplayBuilder))
                builder = new DisplayBuilder(modelInformation);
            else if (systemBlockType == typeof(ScopeBuilder))
                builder = new ScopeBuilder(modelInformation);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported sink builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
