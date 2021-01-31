using System;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class LimitedIntegratorBuilder : BaseIntegratorBuilder<LimitedIntegratorBuilder>, ILimitedIntegrator
    {
        internal override string BlockName => "Integrator\\nLimited";

        private string _UpperSaturationLimit = "1";
        private string _LowerSaturationLimit = "0";

        public LimitedIntegratorBuilder(Model model)
            : base(model)
        {

        }

        public ILimitedIntegrator SetUpperSaturationLimit(double limit)
        {
            if (limit < 0)
                throw new ArgumentException("Upper limit must be a positive number.");

            if (limit <= double.Parse(_LowerSaturationLimit))
                throw new ArgumentException("Upper limit must be greater than the lower limit.");

            _UpperSaturationLimit = limit.ToString();
            return this;
        }

        public ILimitedIntegrator SetLowerSaturationLimit(double limit)
        {
            if (limit >= double.Parse(_UpperSaturationLimit))
                throw new ArgumentException("Lower limit must be less than the upper limit.");

            _LowerSaturationLimit = limit.ToString();
            return this;
        }


        internal override void Build()
        {
            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "LimitOutput", Text = "on" });

            model.System.Block.Add(block);
        }
    }
}
