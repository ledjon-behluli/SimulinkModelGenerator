using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class SliderGainBuilder : SystemBlockBuilder<SliderGainBuilder>, ISliderGain
    {
        internal override SizeU Size => new SizeU(30, 30);

        private string _Gain = "0.0";
        private string _LowEnd = "-1";
        private string _HighEnd = "2";

        internal SliderGainBuilder(Model model)
            : base(model)
        {

        }


        public ISliderGain SetGainLimits(double lowEnd = -1, double highEnd = 1)
        {
            if (lowEnd >= highEnd)
                throw new ArgumentException("LowEnd must be less than HighEnd.");

            if (lowEnd > double.Parse(_Gain))
                throw new ArgumentException("LowEnd must be less than or equal to Gain.");

            if (highEnd < double.Parse(_Gain))
                throw new ArgumentException("HighEnd must be greater than or equal to Gain.");

            _LowEnd = lowEnd.ToString();
            _HighEnd = highEnd.ToString();

            return this;
        }


        public ISliderGain SetGain(double value)
        {
            _Gain = value.ToString();
            return this;
        }

        public ISliderGain IncrementGainBy(double value)
        {
            _Gain = (double.Parse(_Gain) + value).ToString();
            return this;
        }

        public ISliderGain DecrementGainBy(double value)
        {
            _Gain = (double.Parse(_Gain) - value).ToString();
            return this;
        }


        internal override void Build()
        {
            if (double.Parse(_Gain) < double.Parse(_LowEnd) || double.Parse(_Gain) > double.Parse(_HighEnd))
                throw new ArgumentException("Gain must be inclusive between the bounds of LowEnd and HighEnd.");

            model.System.Block.Add(new Block()
            {
                BlockType = "Reference",
                BlockName = GenerateUniqueName("Slider\\nGain"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "Ports", Text = "[1 1]" },
                    new Parameter() { Name = "LibraryVersion", Text = "1.391" },
                    new Parameter() { Name = "SourceType", Text = "Slider Gain" },
                    new Parameter() { Name = "SourceBlock", Text = "simulink/Math\\nOperations/Slider\nGain" },
                    new Parameter() { Name = "gain", Text = _Gain },
                    new Parameter() { Name = "low", Text = _LowEnd },
                    new Parameter() { Name = "high", Text = _HighEnd },
                }
            });
        }
    }
}
