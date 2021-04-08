using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    internal class SystemSinksBuilder : ISystemSink
    {
        private readonly Model model;

        internal SystemSinksBuilder(Model model)
        {
            this.model = model;
        }
       
        public ISystemSink AddDisplay(Action<IDisplay> action = null) => AddSink<DisplayBuilder>(action);
        public ISystemSink AddScope(Action<IScope> action = null) => AddSink<ScopeBuilder>(action);
        public ISystemSink AddOutPort(Action<IOutPort> action = null) => AddSink<OutPortBuilder>(action);
        public ISystemSink AddToWorkspace(Action<IToWorkspace> action = null) => AddSink<ToWorkspaceBuilder>(action);
        public ISystemSink AddXYGraph(Action<IXYGraph> action = null) => AddSink<XYGraphBuilder>(action);


        private ISystemSink AddSink<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder;

            if (systemBlockType == typeof(DisplayBuilder))
                builder = new DisplayBuilder(model);
            else if (systemBlockType == typeof(ScopeBuilder))
                builder = new ScopeBuilder(model);
            else if (systemBlockType == typeof(OutPortBuilder))
                builder = new OutPortBuilder(model);
            else if (systemBlockType == typeof(ToWorkspaceBuilder))
                builder = new ToWorkspaceBuilder(model);
            else if (systemBlockType == typeof(XYGraphBuilder))
                builder = new XYGraphBuilder(model);
            else
                throw new SimulinkModelGeneratorException("Unsupported sink builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
