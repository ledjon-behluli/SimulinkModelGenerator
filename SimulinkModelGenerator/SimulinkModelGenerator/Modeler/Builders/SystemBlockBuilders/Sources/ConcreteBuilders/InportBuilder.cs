using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    internal class InPortBuilder : PortBuilder<InPortBuilder>, IInPort
    {
        protected override string BlockType => "Inport";
        protected override string BlockName => "In";

        private bool _InterpolateData = true;

        internal InPortBuilder(Model model)
            : base(model)
        {

        }

        public IInPort ExtrapolateData()
        {
            _InterpolateData = false;
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "Interpolate", Text = _InterpolateData ? "on" : "off" });

            model.System.Block.Add(block);
        }
    }
}
