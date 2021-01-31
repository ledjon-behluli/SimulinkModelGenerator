using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemSink
    {
        ISystemSink AddDisplay(Action<DisplayBuilder> action = null);
        ISystemSink AddScope(Action<ScopeBuilder> action = null);
        ISystemSink AddOutPort(Action<OutPortBuilder> action = null);
        ISystemSink AddToWorkspace(Action<ToWorkspaceBuilder> action = null);
        ISystemSink AddXYGraph(Action<XYGraphBuilder> action = null);
    }


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

    public interface IToWorkspace : ISystemBlock
    {
        IToWorkspace SetVariableName(string name);
        IToWorkspace SetMaxDataPoints(int points);
        IToWorkspace SetDecimation(int decimation);
        IToWorkspace WithSignalSaveType(SignalSaveType type);
        IToWorkspace WithSaveFormat(SaveFormat format);
        IToWorkspace LogFixedPointDataAsFiObject();
    }

    public interface IXYGraph : ISystemBlock
    {
        IXYGraph SetXMin(double value);
        IXYGraph SetXMax(double value);
        IXYGraph SetYMin(double value);
        IXYGraph SetYMax(double value);
        IXYGraph SetSampleTime(double sampleTime);
    }
}
