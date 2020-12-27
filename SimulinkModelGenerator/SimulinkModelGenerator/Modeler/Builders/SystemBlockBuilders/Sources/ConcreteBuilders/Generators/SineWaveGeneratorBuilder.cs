using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders.Generators
{
    public sealed class SineWaveGeneratorBuilder : GeneratorBuilder<SineWaveGeneratorBuilder>, ISineWaveGenerator
    {
        internal override string BlockType => "Sin";
        internal override string BlockName => "Sine Wave";

        public SineWaveGeneratorBuilder(Model model)
            : base(model)
        {

        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "", Text = "" });

            model.System.Block.Add(block);
        }
    }
}
