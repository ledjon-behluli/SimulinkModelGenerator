using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class UniformRandomNumberBuilder : BaseRandomNumberBuilder<UniformRandomNumberBuilder>, IUniformRandomNumber
    {
        internal override SizeU Size => new SizeU(30, 30);
        internal override string BlockType => "UniformRandomNumber";
        internal override string BlockName => "Uniform Random\\nNumber";

        private string _Minimum = "-1";
        private string _Maximum = "1";

        internal UniformRandomNumberBuilder(Model model)
            : base(model)
        {

        }

        public IUniformRandomNumber SetRange(double min = -1, double max = 1)
        {
            if (min >= max)
                throw new SimulinkModelGeneratorException("Minimum must be less than Maximum.");

            _Minimum = min.ToString();
            _Maximum = max.ToString();

            return this;

        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "Minimum", Text = _Minimum });
            block.Parameters.Add(new Parameter() { Name = "Maximum", Text = _Maximum });

            model.System.Block.Add(block);
        }
    }
}
