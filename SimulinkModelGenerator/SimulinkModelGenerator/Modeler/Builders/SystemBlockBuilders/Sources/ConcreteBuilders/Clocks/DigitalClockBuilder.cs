using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders.Clocks
{
    public sealed class DigitalClockBuilder : SystemBlockBuilder<DigitalClockBuilder>, IDigitalClock
    {
        internal override SizeU Size => new SizeU(65, 24);

        private string _SampleTime = "1";

        public DigitalClockBuilder(Model model)
            : base(model)
        {

        }

        public IDigitalClock SetSampleTime(double sampleTime)
        {
            if (sampleTime < 0)
                throw new ArgumentException("SampleTime must be greater than or equal to 0.");

            _SampleTime = sampleTime.ToString();
            return this;
        }


        internal override void Build()
        {
            model.System.Block.Add(new Block()
            {
                BlockType = "DigitalClock",
                Name = $"Digital Clock{GetBlockTypeCount("DigitalClock")}",
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = _Position },
                    new Parameter() { Name = "BlockMirror", Text = _BlockMirror },
                    new Parameter() { Name = "SampleTime", Text = _SampleTime }
                }
            });
        }
    }
}
