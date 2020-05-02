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

        public override ISystemBlock SetPosition(uint x, uint y, uint width = 30, uint height = 30)
        {
            return base.SetPosition(x, y, width, height);
        }


        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Reference",
                Name = base.GetName("Ramp"),
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "BlockMirror", Text = base.BlockMirror }
                },
                InstanceData = new InstanceData()
                {
                    P = new List<P>()
                    {
                        new P() { Name = "slope", Text = _Slope },
                        new P() { Name = "start", Text = _StartTime },
                        new P() { Name = "X0", Text = _InitialOutput }
                    }
                }
            });
        }
    }
}
