using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
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
        public ISystemSink AddOutPort(Action<OutPortBuilder> action = null) => AddSink<OutPortBuilder>(action);
        public ISystemSink AddToWorkspace(Action<ToWorkspaceBuilder> action = null) => AddSink<ToWorkspaceBuilder>(action);


        private ISystemSink AddSink<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(DisplayBuilder))
                builder = new DisplayBuilder(model);
            else if (systemBlockType == typeof(ScopeBuilder))
                builder = new ScopeBuilder(model);
            else if (systemBlockType == typeof(OutPortBuilder))
                builder = new OutPortBuilder(model);
            else if (systemBlockType == typeof(ToWorkspaceBuilder))
                builder = new ToWorkspaceBuilder(model);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported sink builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
