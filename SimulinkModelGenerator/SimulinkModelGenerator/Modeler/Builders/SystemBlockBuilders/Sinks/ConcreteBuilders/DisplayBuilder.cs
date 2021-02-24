using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class DisplayBuilder : SystemBlockBuilder<DisplayBuilder>, IDisplay
    {
        internal override SizeU Size => new SizeU(90, 30);

        internal DisplayBuilder(Model model)
            : base(model)
        {

        }


        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Display",
                BlockName = GenerateUniqueName("Display"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror }
                }
            });
        }
    }
}
