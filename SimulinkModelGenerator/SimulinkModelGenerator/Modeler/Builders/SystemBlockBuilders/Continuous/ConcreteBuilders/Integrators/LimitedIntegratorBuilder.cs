﻿using System;
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class LimitedIntegratorBuilder : BaseIntegratorBuilder<LimitedIntegratorBuilder>, ILimitedIntegrator
    {
        internal override string BlockName => "Integrator\\nLimited";

        public LimitedIntegratorBuilder(Model model)
            : base(model)
        {
            _LowerSaturationLimit = "0";
            _UpperSaturationLimit = "1";
        }

        public ILimitedIntegrator SetSaturationLimits(double lowerLimit = 0, double upperLimit = 1)
        {
            if (upperLimit < 0)
                throw new ArgumentException("Upper limit must be a positive number.");

            if (upperLimit <= lowerLimit)
                throw new ArgumentException("Upper limit must be greater than the lower limit.");

            _LowerSaturationLimit = lowerLimit.ToString();
            _UpperSaturationLimit = upperLimit.ToString();

            return this;
        }


        internal override void Build()
        {
            if (double.Parse(_LowerSaturationLimit) > double.Parse(_InitialCondition) ||
                double.Parse(_UpperSaturationLimit) < double.Parse(_InitialCondition))
            {
                throw new SimulinkModelGeneratorException("Initial condition must be inclusive between the lower and upper saturation limits.");
            }

            Block block = GetBlock();

            block.P.Add(new Parameter() { Name = "LimitOutput", Text = "on" });
            block.P.Add(new Parameter() { Name = "UpperSaturationLimit", Text = _UpperSaturationLimit });
            block.P.Add(new Parameter() { Name = "LowerSaturationLimit", Text = _LowerSaturationLimit });

            model.System.Block.Add(block);
        }
    }
}
