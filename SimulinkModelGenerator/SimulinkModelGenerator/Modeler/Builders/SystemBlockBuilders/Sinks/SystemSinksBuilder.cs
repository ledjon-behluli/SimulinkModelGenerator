using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class SystemSinksBuilder : ISystemSink
    {
        private readonly Model model;

        public SystemSinksBuilder(Model model)
        {
            this.model = model;
        }
       
        public ISystemSink AddDisplay(Action<DisplayBuilder> action = null) => AddSink<DisplayBuilder>(action);
        public ISystemSink AddScope(Action<ScopeBuilder> action = null) => AddSink<ScopeBuilder>(action);

        private ISystemSink AddSink<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(DisplayBuilder))
                builder = new DisplayBuilder(model);
            else if (systemBlockType == typeof(ScopeBuilder))
                builder = new ScopeBuilder(model);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported sink builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
