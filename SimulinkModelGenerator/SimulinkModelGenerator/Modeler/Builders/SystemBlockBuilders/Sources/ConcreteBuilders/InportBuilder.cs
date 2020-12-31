using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Common;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources.ConcreteBuilders
{
    public sealed class InPortBuilder : PortBuilder<InPortBuilder>, IInPort
    {
        protected override string BlockType => "Inport";
        protected override string BlockName => "In";

        public InPortBuilder(Model model)
            : base(model)
        {

        }

        internal override void Build()
        {
            Block block = GetBlock();
            model.System.Block.Add(block);
        }
    }
}
