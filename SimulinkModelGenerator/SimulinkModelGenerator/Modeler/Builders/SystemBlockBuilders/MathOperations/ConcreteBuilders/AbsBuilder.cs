using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class AbsBuilder : MathOperationBuilder<AbsBuilder>, IAbs
    {
        internal override SizeU Size => new SizeU(30, 30);

        protected override string BlockType => "Abs";
        protected override string BlockName => "Abs";
        protected override string OutDataTypeStr => "Inherit: Same as input";


        private bool _EnableZeroCrossingDetection = true;

        internal AbsBuilder(Model model)
            : base(model)
        {

        }

        public IAbs DisableZeroCrossingDetection()
        {
            _EnableZeroCrossingDetection = false;
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "ZeroCross", Text = _EnableZeroCrossingDetection ? "on" : "off" });

            model.System.Block.Add(block);
        }
    }
}
