using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class IntegratorBuilder : BaseIntegratorBuilder<IntegratorBuilder>, IIntegrator
    {
        internal override string BlockName => "Integrator";

        internal IntegratorBuilder(Model model)
            : base(model)
        {
            _LowerSaturationLimit = "-inf";
            _UpperSaturationLimit = "inf";
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "LimitOutput", Text = "off" });
            block.Parameters.Add(new Parameter() { Name = "UpperSaturationLimit", Text = "inf" });
            block.Parameters.Add(new Parameter() { Name = "LowerSaturationLimit", Text = "-inf" });

            model.System.Block.Add(block);
        }
    }
}
