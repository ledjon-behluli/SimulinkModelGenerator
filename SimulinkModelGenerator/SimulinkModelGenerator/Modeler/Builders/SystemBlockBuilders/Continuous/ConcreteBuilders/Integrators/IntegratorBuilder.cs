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
            _LowerSaturationLimit = "-inf";
            _UpperSaturationLimit = "inf";
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "LimitOutput", Text = "off" });
            block.P.Add(new Parameter() { Name = "UpperSaturationLimit", Text = "inf" });
            block.P.Add(new Parameter() { Name = "LowerSaturationLimit", Text = "-inf" });

            model.System.Block.Add(block);
        }
    }
}
