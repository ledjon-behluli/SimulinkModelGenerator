using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class RampBuilder : SystemBlockBuilder<RampBuilder>, IRamp
    {
        internal override SizeU Size => new SizeU(30, 30);

        private string _Slope = "1";
        private string _StartTime = "0";
        private string _InitialOutput = "0";

        public RampBuilder(Model model)
            : base(model)
        {

        }

        
        public IRamp SetSlope(double slope)
        {
            _Slope = slope.ToString();
            return this;
        }

        public IRamp SetStartTime(double startTime)
        {
            _StartTime = startTime.ToString();
            return this;
        }

        public IRamp SetInitialOutput(double initialOutput)
        {
            _InitialOutput = initialOutput.ToString();
            return this;
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Reference",
                Name = base.GetName("Ramp"),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror }
                },
                InstanceData = new InstanceData()
                {
                    P = new List<Parameter>()
                    {
                        new Parameter() { Name = "slope", Text = _Slope },
                        new Parameter() { Name = "start", Text = _StartTime },
                        new Parameter() { Name = "X0", Text = _InitialOutput },
                        new Parameter() { Name = "SourceBlock", Text = "simulink/Sources/Ramp" },
                        new Parameter() { Name = "SourceType", Text = "Ramp" },
                        new Parameter() { Name = "Ports", Text = "[0, 1]" },
                        new Parameter() { Name = "LibraryVersion", Text = "1.391" },
                    }
                }
            });
        }
    }
}
