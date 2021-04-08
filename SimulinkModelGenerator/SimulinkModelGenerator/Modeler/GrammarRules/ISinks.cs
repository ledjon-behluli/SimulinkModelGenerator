using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemSink
    {
        ISystemSink AddDisplay(Action<IDisplay> action = null);
        ISystemSink AddScope(Action<IScope> action = null);
        ISystemSink AddOutPort(Action<IOutPort> action = null);
        ISystemSink AddToWorkspace(Action<IToWorkspace> action = null);
        ISystemSink AddXYGraph(Action<IXYGraph> action = null);
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
        IXYGraph SetX(double xMin = -1, double xMax = 1);
        IXYGraph SetY(double yMin = -1, double yMax = 1);
        IXYGraph SetSampleTime(double sampleTime);
    }
}
