using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Clocks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Generators;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Generators.Pulse;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Generators.SineWave;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.RandomNumbers;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class SystemSourcesBuilder : ISystemSource
    {
        private readonly Model model;

        public SystemSourcesBuilder(Model model)
        {
            this.model = model;
        }

       
        public ISystemSource AddConstant(Action<ConstantBuilder> action = null) => AddSource<ConstantBuilder>(action);
        public ISystemSource AddRamp(Action<RampBuilder> action = null) => AddSource<RampBuilder>(action);
        public ISystemSource AddStep(Action<StepBuilder> action = null) => AddSource<StepBuilder>(action);
        public ISystemSource AddInPort(Action<InPortBuilder> action = null) => AddSource<InPortBuilder>(action);
        public ISystemSource AddRepeatingSequence(Action<RepeatingSequenceBuilder> action = null) => AddSource<RepeatingSequenceBuilder>(action);
        public ISystemSource AddFromWorkspace(Action<FromWorkspaceBuilder> action = null) => AddSource<FromWorkspaceBuilder>(action);
        public ISystemSource AddClock(Action<ClockBuilder> action = null) => AddSource<ClockBuilder>(action);
        public ISystemSource AddDigitalClock(Action<DigitalClockBuilder> action = null) => AddSource<DigitalClockBuilder>(action);
        public ISystemSource AddRandomNumber(Action<RandomNumberBuilder> action = null) => AddSource<RandomNumberBuilder>(action);
        public ISystemSource AddUniformRandomNumber(Action<UniformRandomNumberBuilder> action = null) => AddSource<UniformRandomNumberBuilder>(action);
        public ISystemSource AddSignalGenerator(Action<SignalGeneratorBuilder> action = null) => AddSource<SignalGeneratorBuilder>(action);
        public ISystemSource AddTimeBasedPulseGenerator(Action<TimeBasedPulseGeneratorBuilder> action = null) => AddSource<TimeBasedPulseGeneratorBuilder>(action);
        public ISystemSource AddSampleBasedPulseGenerator(Action<SampleBasedPulseGeneratorBuilder> action = null) => AddSource<SampleBasedPulseGeneratorBuilder>(action);
        public ISystemSource AddTimeBasedSineWaveGenerator(Action<TimeBasedSineWaveGeneratorBuilder> action = null) => AddSource<TimeBasedSineWaveGeneratorBuilder>(action);
        public ISystemSource AddSampleBasedSineWaveGenerator(Action<SampleBasedSineWaveGeneratorBuilder> action = null) => AddSource<SampleBasedSineWaveGeneratorBuilder>(action);


        private ISystemSource AddSource<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(ConstantBuilder))
                builder = new ConstantBuilder(model);
            else if (systemBlockType == typeof(RampBuilder))
                builder = new RampBuilder(model);
            else if (systemBlockType == typeof(StepBuilder))
                builder = new StepBuilder(model);
            else if (systemBlockType == typeof(InPortBuilder))
                builder = new InPortBuilder(model);
            else if (systemBlockType == typeof(RepeatingSequenceBuilder))
                builder = new RepeatingSequenceBuilder(model);
            else if (systemBlockType == typeof(FromWorkspaceBuilder))
                builder = new FromWorkspaceBuilder(model);
            else if (systemBlockType == typeof(ClockBuilder))
                builder = new StepBuilder(model);
            else if (systemBlockType == typeof(DigitalClockBuilder))
                builder = new DigitalClockBuilder(model);
            else if (systemBlockType == typeof(RandomNumberBuilder))
                builder = new RandomNumberBuilder(model);
            else if (systemBlockType == typeof(UniformRandomNumberBuilder))
                builder = new UniformRandomNumberBuilder(model);
            else if (systemBlockType == typeof(SignalGeneratorBuilder))
                builder = new SignalGeneratorBuilder(model);
            else if (systemBlockType == typeof(TimeBasedPulseGeneratorBuilder))
                builder = new TimeBasedPulseGeneratorBuilder(model);
            else if (systemBlockType == typeof(TimeBasedSineWaveGeneratorBuilder))
                builder = new TimeBasedSineWaveGeneratorBuilder(model);
            else if (systemBlockType == typeof(SampleBasedSineWaveGeneratorBuilder))
                builder = new SampleBasedSineWaveGeneratorBuilder(model);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported source builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
