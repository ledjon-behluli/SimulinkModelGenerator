using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Clocks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.RandomNumbers;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Generators;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Generators.Pulse;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Generators.SineWave;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemSource
    {
        ISystemSource AddConstant(Action<ConstantBuilder> action = null);
        ISystemSource AddRamp(Action<RampBuilder> action = null);
        ISystemSource AddStep(Action<StepBuilder> action = null);
        ISystemSource AddInPort(Action<InPortBuilder> action = null);
        ISystemSource AddRepeatingSequence(Action<RepeatingSequenceBuilder> action = null);
        ISystemSource AddFromWorkspace(Action<FromWorkspaceBuilder> action = null);
        ISystemSource AddClock(Action<ClockBuilder> action = null);
        ISystemSource AddDigitalClock(Action<DigitalClockBuilder> action = null);
        ISystemSource AddRandomNumber(Action<RandomNumberBuilder> action = null);
        ISystemSource AddUniformRandomNumber(Action<UniformRandomNumberBuilder> action = null);
        ISystemSource AddSignalGenerator(Action<SignalGeneratorBuilder> action = null);
        ISystemSource AddTimeBasedPulseGenerator(Action<TimeBasedPulseGeneratorBuilder> action = null);
        ISystemSource AddSampleBasedPulseGenerator(Action<SampleBasedPulseGeneratorBuilder> action = null);
        ISystemSource AddTimeBasedSineWaveGenerator(Action<TimeBasedSineWaveGeneratorBuilder> action = null);
        ISystemSource AddSampleBasedSineWaveGenerator(Action<SampleBasedSineWaveGeneratorBuilder> action = null);
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

    public interface IInPort : IPort
    {
      
    }

    public interface IRepeatingSequence : ISystemBlock
    {
        IRepeatingSequence SetTimeStamps(params double[] values);
        IRepeatingSequence SetOutputValues(params double[] values);
    }

    public interface IFromWorkspace : ISystemBlock
    {
        IFromWorkspace SetVariableName(string name);
        IFromWorkspace ExtrapolateData();
        IFromWorkspace DisableZeroCrossingDetection();
    }

    #endregion

    #region Clocks

    public interface IClock : ISystemBlock
    {
        
        IClock ShowSimulationTime();
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

    #region Generators

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


    public interface ISineWaveGenerator<out TResult> : IGenerator
        where TResult : IGenerator
    {
        TResult SetBias(double bias);
        TResult SetSampleTime(double sampleTime);
    }

    public interface ITimeBasedSineWaveGenerator : ISineWaveGenerator<ITimeBasedSineWaveGenerator>
    {
        ITimeBasedSineWaveGenerator SetFrequency(double frequency);     
        ITimeBasedSineWaveGenerator SetPhase(double phase);    
    }

    public interface ISampleBasedSineWaveGenerator : ISineWaveGenerator<ISampleBasedSineWaveGenerator>
    {
        ISampleBasedSineWaveGenerator SetSamples(int samplesPerPeriod);   
        ISampleBasedSineWaveGenerator SetOffset(double numOfOffsetSamples);    
    }

    #endregion
}
