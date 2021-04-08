using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    internal class SignBuilder : SystemBlockBuilder<SignBuilder>, ISign
    {
        internal override SizeU Size => new SizeU(30, 30);

        private bool _EnableZeroCrossingDetection = true;

        internal SignBuilder(Model model)
            : base(model)
        {

        }

        public ISign DisableZeroCrossingDetection()
        {
            _EnableZeroCrossingDetection = false;
            return this;
        }

        internal override void Build()
        {
            model.System.Block.Add(new Block()
            {
                BlockType = "Signum",
                BlockName = GenerateUniqueName("Sign"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "ZeroCross", Text = _EnableZeroCrossingDetection ? "on" : "off" },
                    new Parameter() { Name = "SampleTime", Text = "-1" }
                }
            });
        }
    }
}
