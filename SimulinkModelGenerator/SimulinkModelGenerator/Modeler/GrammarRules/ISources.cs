using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders.Generators;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemSource
    {
        ISystemSource AddConstant(Action<ConstantBuilder> action = null);
        ISystemSource AddRamp(Action<RampBuilder> action = null);
        ISystemSource AddStep(Action<StepBuilder> action = null);
    }

    #region Uncategorized

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

    public interface IInport : ISystemBlock
    {
        IInport SetPortNumber(int port);
        IInport WithIconDisplay(IconDisplay iconDisplay);
    }

    #endregion

    #region Clocks

    public interface IClock : ISystemBlock
    {
        
        IClock HideSimulationTime();
        IClock SetDecimation(int decimation);
    }

    public interface IDigitalClock : ISystemBlock
    {
        IDigitalClock SetSampleTime(double sampleTime);
    }

    #endregion

    #region Random Numbers

    public interface IBaseRandomNumber : ISystemBlock
    {
        IBaseRandomNumber SetSeed(double seed);
        IBaseRandomNumber SetSampleTime(double sampleTime);
    }

    public interface IRandomNumber : IBaseRandomNumber
    {
        IRandomNumber SetMean(double mean);
        IRandomNumber SetVariance(double variance);
    }

    public interface IUniformRandomNumber : IBaseRandomNumber
    {
        IUniformRandomNumber SetMinimum(double min);
        IUniformRandomNumber SetMaximum(double max);
    }

    #endregion

    #region Signal Generators

    public interface IGenerator : ISystemBlock
    {
        IGenerator WithTimeSource(TimeSourceType type);
        IGenerator SetAmplitude(double amplitude);
    }

    public interface ISignalGenerator : IGenerator
    {
        ISignalGenerator WithUnit(FrequencyUnit unit);
        ISignalGenerator WithWaveForm(WaveForm waveForm);
        ISignalGenerator SetFrequency(double frequency);
    }

    public interface ISineWaveGenerator : IGenerator
    {

    }

    public interface IPulseGenerator<in TParam, out TResult> : IGenerator
        where TParam : struct
        where TResult : IGenerator
    {
        TResult SetPeriod(TParam period);
        TResult SetPulseWidth(TParam width);
        TResult SetPhaseDelay(TParam delay);
    }

    public interface ITimeBasedPulseGenerator : IPulseGenerator<double, ITimeBasedPulseGenerator>
    {
        
    }

    public interface ISampleBasedPulseGenerator : IPulseGenerator<int, ISampleBasedPulseGenerator>
    {
        ISampleBasedPulseGenerator SetSampleTime(double sampleTime);
    }


    #endregion
}
