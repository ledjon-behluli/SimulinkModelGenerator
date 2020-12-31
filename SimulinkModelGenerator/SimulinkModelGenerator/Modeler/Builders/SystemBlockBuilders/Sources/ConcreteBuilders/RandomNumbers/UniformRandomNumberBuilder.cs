using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.RandomNumbers
{
    public sealed class UniformRandomNumberBuilder : BaseRandomNumberBuilder<RandomNumberBuilder>, IUniformRandomNumber
    {
        internal override SizeU Size => new SizeU(30, 30);
        internal override string BlockType => "UniformRandomNumber";
        internal override string BlockName => "Uniform Random\\nNumber";

        private string _Minimum = "-1";
        private string _Maximum = "1";

        public UniformRandomNumberBuilder(Model model)
            : base(model)
        {

        }

        public IUniformRandomNumber SetMinimum(double min)
        {
            if (min >= double.Parse(_Maximum))
                throw new ArgumentException("Minimum must be less than Maximum.");

            _Minimum = min.ToString();
            return this;
        }

        public IUniformRandomNumber SetMaximum(double max)
        {
            if (max <= double.Parse(_Minimum))
                throw new ArgumentException("Maximum must be greater than Minimum.");

            _Maximum = max.ToString();
            return this;
        }


        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "Minimum", Text = _Minimum });
            block.P.Add(new Parameter() { Name = "Maximum", Text = _Maximum });

            model.System.Block.Add(block);
        }
    }
}
