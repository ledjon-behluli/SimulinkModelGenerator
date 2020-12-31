using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemSink
    {
        ISystemSink AddDisplay(Action<DisplayBuilder> action = null);
        ISystemSink AddScope(Action<ScopeBuilder> action = null);
        ISystemSink AddOutPort(Action<OutPortBuilder> action = null);
    }

    #region Uncategorized

    public interface IScope : ISystemBlock
    {
        IScope SetInputPorts(uint numberOfPorts);
    }

    public interface IDisplay : ISystemBlock
    {

    }

    public interface IOutPort : IPort
    {
        IOutPort WithSignalName(string name);
    }

    #endregion
}
