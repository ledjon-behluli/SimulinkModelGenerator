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

        public SliderGainBuilder(Model model)
            : base(model)
        {

        }

        public ISliderGain SetGain(double value)
        {
            if (value < double.Parse(_LowEnd) || value > double.Parse(_HighEnd))
                throw new ArgumentException("Gain must be inclusive within the bounds of LowEnd and HighEnd.");

            _Gain = value.ToString();
            return this;
        }

        public ISliderGain IncrementGainBy(double value)
        {
            double newGain = double.Parse(_Gain) + value;

            if(newGain >= double.Parse(_LowEnd) && newGain <= double.Parse(_HighEnd))
            {
                _Gain = newGain.ToString();
            }

            return this;
        }

        public ISliderGain DecrementGainBy(double value)
        {
            double newGain = double.Parse(_Gain) - value;

            if (newGain >= double.Parse(_LowEnd) && newGain <= double.Parse(_HighEnd))
            {
                _Gain = newGain.ToString();
            }

            return this;
        }

        public ISliderGain SetLowEnd(double value)
        {
            if (value >= double.Parse(_HighEnd))
                throw new ArgumentException("LowEnd must be less than HighEnd.");

            if (value > double.Parse(_Gain))
                throw new ArgumentException("LowEnd must be less than or equal to Gain.");

            _LowEnd = value.ToString();
            return this;
        }

        public ISliderGain SetHighEnd(double value)
        {
            if (value <= double.Parse(_LowEnd))
                throw new ArgumentException("HighEnd must be greater than LowEnd.");

            if (value < double.Parse(_Gain))
                throw new ArgumentException("HighEnd must be greater than or equal to Gain.");

            _HighEnd = value.ToString();
            return this;
        }


        internal override void Build()
        {
            model.System.Block.Add(new Block()
            {
                BlockType = "Reference",
                Name = $"Slider\\nGain{GetBlockTypeCount("Reference")}",
                P = new List<Parameter>()
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
