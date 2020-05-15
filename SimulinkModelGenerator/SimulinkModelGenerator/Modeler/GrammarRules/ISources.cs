using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemSource
    {
        ISystemSource AddConstant(Action<ConstantBuilder> action = null);
        ISystemSource AddRamp(Action<RampBuilder> action = null);
        ISystemSource AddStep(Action<StepBuilder> action = null);
    }

    public interface IConstant : ISystemBlock
    {
        IConstant SetValue(decimal value);
    }

    public interface IStep : ISystemBlock
    {
        IStep SetStepTime(double stepTime);
        IStep SetInitialValue(double initialValue);
        IStep SetFinalValue(double finalValue);
        IStep SetSampleTime(double sampleTime);
    }

    public interface IRamp : ISystemBlock
    {
        IRamp SetSlope(double slope);
        IRamp SetStartTime(double startTime);
        IRamp SetInitialOutput(double initialOutput);
    }
}
