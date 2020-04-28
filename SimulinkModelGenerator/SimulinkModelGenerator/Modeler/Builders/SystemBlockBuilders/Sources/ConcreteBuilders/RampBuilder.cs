using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class RampBuilder : SystemBlockBuilder<RampBuilder>, IRamp
    {
        private string _Slope = "1";
        private string _StartTime = "0";
        private string _InitialOutput = "0";

        public RampBuilder(Model model)
            : base(model)
        {

        }

        
        public IRamp SetSlope(decimal slope)
        {
            _Slope = slope.ToString();
            return this;
        }

        public IRamp SetStartTime(decimal startTime)
        {
            _StartTime = startTime.ToString();
            return this;
        }

        public IRamp SetInitialOutput(decimal initialOutput)
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
                SID = base._SID,
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "ZOrder", Text = base._ZOrder },
                    new P() { Name = "Ports", Text = "[0, 1]" },
                    new P() { Name = "LibraryVersion", Text = "1.391" },
                    new P() { Name = "SourceBlock", Text = "simulink/Sources/Ramp" },
                    new P() { Name = "SourceType", Text = "Ramp" },
                    new P() { Name = "SourceProductName", Text = "Simulink" },
                    new P() { Name = "SourceProductBaseCode", Text = "SL" }
                },
                InstanceData = new InstanceData()
                {
                    P = new List<P>()
                    {
                        new P() { Name = "ContentPreviewEnabled", Text = "off" },
                        new P() { Name = "slope", Text = _Slope },
                        new P() { Name = "start", Text = _StartTime },
                        new P() { Name = "X0", Text = _InitialOutput },
                        new P() { Name = "VectorParams1D", Text = "on" }
                    }
                }
            });
        }
    }
}
