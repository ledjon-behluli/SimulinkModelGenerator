using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    internal class GainBuilder : MathOperationBuilder<GainBuilder>, IGain
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected override string BlockType => "Gain";
        protected override string BlockName => "Gain";
        protected override string OutDataTypeStr => "Inherit: Same as input";


        private string _Gain = "1";

        internal GainBuilder(Model model)
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
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "Gain", Text = _Gain });

            model.System.Block.Add(block);
        }
    }
}
