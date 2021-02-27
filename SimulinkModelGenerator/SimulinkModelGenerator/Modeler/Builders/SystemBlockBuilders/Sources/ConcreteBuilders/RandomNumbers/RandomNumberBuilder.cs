using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class RandomNumberBuilder : BaseRandomNumberBuilder<RandomNumberBuilder>, IRandomNumber
    {
        internal override SizeU Size => new SizeU(30, 30);
        internal override string BlockType => "RandomNumber";
        internal override string BlockName => "Random\\nNumber";

        private string _Mean = "0";
        private string _Variance = "1";

        internal RandomNumberBuilder(Model model)
            : base(model)
        {

        }

        public IRandomNumber SetMean(double mean)
        {
            _Mean = mean.ToString();
            return this;
        }

        public IRandomNumber SetVariance(double variance)
        {
            if (variance < 0)
                throw new SimulinkModelGeneratorException("Variance must be greater than or equal to 0.");

            _Variance = variance.ToString();
            return this;
        }


        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "Mean", Text = _Mean });
            block.Parameters.Add(new Parameter() { Name = "Variance", Text = _Variance });

            model.System.Block.Add(block);
        }
    }
}
