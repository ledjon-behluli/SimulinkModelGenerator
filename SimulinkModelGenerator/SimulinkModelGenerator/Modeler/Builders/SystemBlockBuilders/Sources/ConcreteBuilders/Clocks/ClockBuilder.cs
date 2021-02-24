using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class ClockBuilder : SystemBlockBuilder<ClockBuilder>, IClock
    {
        internal override SizeU Size => new SizeU(20, 20);

        private bool _DisplayTime = false;
        private string _Decimation = "10";

        internal ClockBuilder(Model model)
            : base(model)
        {

        }

        public IClock ShowSimulationTime()
        {
            _DisplayTime = true;
            return this;
        }

        public IClock SetDecimation(int decimation)
        {
            if (decimation < 1)
                throw new ArgumentException("Decimation must be greater than or equal to 1.");

            _Decimation = decimation.ToString();
            return this;
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Clock",
                BlockName = GenerateUniqueName("Clock"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "DisplayTime", Text = _DisplayTime ? "on" : "off" },
                    new Parameter() { Name = "Decimation", Text = _Decimation }
                }
            });
        }
    }
}
