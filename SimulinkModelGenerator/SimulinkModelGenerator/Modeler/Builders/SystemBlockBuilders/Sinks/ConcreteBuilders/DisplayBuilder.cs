using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class DisplayBuilder : SystemBlockBuilder<DisplayBuilder>, IDisplay
    {     
        public DisplayBuilder(Model model)
            : base(model)
        {

        }

        public override ISystemBlock SetPosition(uint x, uint y, uint width = 90, uint height = 30)
        {
            return base.SetPosition(x, y, width, height);
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Display",
                Name = base.GetName("Display"),
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "BlockMirror", Text = base.BlockMirror }
                }
            });
        }
    }
}
