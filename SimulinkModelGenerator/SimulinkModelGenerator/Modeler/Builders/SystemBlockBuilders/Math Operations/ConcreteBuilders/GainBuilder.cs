using System.Collections.Generic;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class GainBuilder : SystemBlockBuilder<GainBuilder>, IGain
    {
        private string _Gain = "1";

        public GainBuilder(Model model)
            : base(model)
        {

        }


        public IGain SetGain(decimal gain)
        {
            _Gain = gain.ToString();
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
                BlockType = "Gain",
                Name = base.GetName("Gain"),
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "BlockMirror", Text = base.BlockMirror },
                    new P() { Name = "Gain", Text = _Gain },                    
                }
            });
        }
    }
}
