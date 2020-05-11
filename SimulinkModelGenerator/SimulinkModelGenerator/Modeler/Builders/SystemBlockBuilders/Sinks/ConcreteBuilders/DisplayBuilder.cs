using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class DisplayBuilder : SystemBlockBuilder<DisplayBuilder>, IDisplay
    {
        internal override SizeU Size => new SizeU(90, 30);

        public DisplayBuilder(Model model)
            : base(model)
        {

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
