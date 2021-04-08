using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    internal class SystemSourcesBuilder : ISystemSource
    {
        private readonly Model model;

        internal SystemSourcesBuilder(Model model)
        {
            this.model = model;
        }

       
        public ISystemSource AddConstant(Action<IConstant> action = null) => AddSource<ConstantBuilder>(action);
        public ISystemSource AddRamp(Action<IRamp> action = null) => AddSource<RampBuilder>(action);
        public ISystemSource AddStep(Action<IStep> action = null) => AddSource<StepBuilder>(action);
        public ISystemSource AddInPort(Action<IInPort> action = null) => AddSource<InPortBuilder>(action);
        public ISystemSource AddRepeatingSequence(Action<IRepeatingSequence> action = null) => AddSource<RepeatingSequenceBuilder>(action);
        public ISystemSource AddFromWorkspace(Action<IFromWorkspace> action = null) => AddSource<FromWorkspaceBuilder>(action);
        public ISystemSource AddClock(Action<IClock> action = null) => AddSource<ClockBuilder>(action);
        public ISystemSource AddDigitalClock(Action<IDigitalClock> action = null) => AddSource<DigitalClockBuilder>(action);
        public ISystemSource AddRandomNumber(Action<IRandomNumber> action = null) => AddSource<RandomNumberBuilder>(action);
        public ISystemSource AddUniformRandomNumber(Action<IUniformRandomNumber> action = null) => AddSource<UniformRandomNumberBuilder>(action);
        public ISystemSource AddSignalGenerator(Action<ISignalGenerator> action = null) => AddSource<SignalGeneratorBuilder>(action);
        public ISystemSource AddTimeBasedPulseGenerator(Action<ITimeBasedPulseGenerator> action = null) => AddSource<TimeBasedPulseGeneratorBuilder>(action);
        public ISystemSource AddSampleBasedPulseGenerator(Action<ISampleBasedPulseGenerator> action = null) => AddSource<SampleBasedPulseGeneratorBuilder>(action);
        public ISystemSource AddTimeBasedSineWaveGenerator(Action<ITimeBasedSineWaveGenerator> action = null) => AddSource<TimeBasedSineWaveGeneratorBuilder>(action);
        public ISystemSource AddSampleBasedSineWaveGenerator(Action<ISampleBasedSineWaveGenerator> action = null) => AddSource<SampleBasedSineWaveGeneratorBuilder>(action);


        private ISystemSource AddSource<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder;

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
                builder = new ClockBuilder(model);
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
            else if (systemBlockType == typeof(SampleBasedPulseGeneratorBuilder))
                builder = new SampleBasedPulseGeneratorBuilder(model);
            else if (systemBlockType == typeof(TimeBasedSineWaveGeneratorBuilder))
                builder = new TimeBasedSineWaveGeneratorBuilder(model);
            else if (systemBlockType == typeof(SampleBasedSineWaveGeneratorBuilder))
                builder = new SampleBasedSineWaveGeneratorBuilder(model);
            else
                throw new SimulinkModelGeneratorException("Unsupported source builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
