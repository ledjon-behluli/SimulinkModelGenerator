using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemSink
    {
        ISystemSink AddDisplay(Action<DisplayBuilder> action = null);
        ISystemSink AddScope(Action<ScopeBuilder> action = null);
    }

    public interface IScope : ISystemBlock
    {
        IScope SetInputPorts(uint numberOfPorts);
    }

    public interface IDisplay : ISystemBlock
    {

    }
}
