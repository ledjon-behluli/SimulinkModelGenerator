﻿using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.Generators.SineWave
{
    public sealed class SampleBasedSineWaveGeneratorBuilder : SineWaveGeneratorBuilder<SampleBasedSineWaveGeneratorBuilder>, ISampleBasedSineWaveGenerator
    {
        protected override string SineType => "Time based";

        private string _Samples = "10";
        private string _Offset = "0";
        private string _SampleTime = "1";
        protected override string SampleTime => _SampleTime;

        public SampleBasedSineWaveGeneratorBuilder(Model model)
            : base(model)
        {

        }

        public new ISampleBasedSineWaveGenerator SetBias(double bias)
        {
            base.SetBias(bias);
            return this;
        }

        public ISampleBasedSineWaveGenerator SetSamples(int samplesPerPeriod)
        {
            if (samplesPerPeriod < 0)
                throw new ArgumentException("Frequency must be greater than or equal to 0.");

            _Samples = samplesPerPeriod.ToString();
            return this;
        }

        public ISampleBasedSineWaveGenerator SetOffset(double numOfOffsetSamples)
        {
            _Offset = numOfOffsetSamples.ToString();
            return this;
        }

        public ISampleBasedSineWaveGenerator SetSampleTime(double sampleTime)
        {
            if (sampleTime <= 0)
                throw new ArgumentException("Frequency must be greater than 0.");

            _SampleTime = sampleTime.ToString();
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "Samples", Text = _Samples });
            block.P.Add(new Parameter() { Name = "Offset", Text = _Offset });

            model.System.Block.Add(block);
        }
    }
}