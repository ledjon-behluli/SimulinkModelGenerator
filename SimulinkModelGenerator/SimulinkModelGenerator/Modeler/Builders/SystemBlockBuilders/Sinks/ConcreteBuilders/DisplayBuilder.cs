﻿using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class DisplayBuilder : SystemBlockBuilder<DisplayBuilder>, IDisplay
    {     
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
                SID = base._SID,
                P = new List<P>()
                {
                    new P() { Name = "Ports", Text = "[1]" },
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "ZOrder", Text = base._ZOrder }
                }
            });
        }
    }
}