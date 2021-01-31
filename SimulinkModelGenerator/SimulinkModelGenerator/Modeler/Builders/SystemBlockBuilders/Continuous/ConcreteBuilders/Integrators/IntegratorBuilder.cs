using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class IntegratorBuilder : BaseIntegratorBuilder<IntegratorBuilder>, IIntegrator
    {
        internal override string BlockName => "Integrator";

        public IntegratorBuilder(Model model)
            : base(model)
        {
            
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "LimitOutput", Text = "off" });

            model.System.Block.Add(block);
        }
    }
}
