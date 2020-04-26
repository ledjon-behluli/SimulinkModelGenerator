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
        IStep SetStepTime(decimal stepTime);
        IStep SetInitialValue(decimal initialValue);
        IStep SetFinalValue(decimal finalValue);
        IStep SetSampleTime(decimal sampleTime);
    }

    public interface IRamp : ISystemBlock
    {
        IRamp SetSlope(decimal slope);
        IRamp SetStartTime(decimal startTime);
        IRamp SetInitialOutput(decimal initialOutput);
    }
}
