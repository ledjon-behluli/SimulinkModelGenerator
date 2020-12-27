using System.Collections.Generic;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class GainBuilder : SystemBlockBuilder<GainBuilder>, IGain
    {
        internal override SizeU Size => new SizeU(30, 30);

        private string _Gain = "1";

        public GainBuilder(Model model)
            : base(model)
        {

        }
        

        public IGain SetGain(double gain)
        {
            _Gain = gain.ToString();
            return this;
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Gain",
                Name = base.GetName("Gain"),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "Gain", Text = _Gain },                    
                }
            });
        }
    }
}
