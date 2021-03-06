﻿using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    internal class IControllerBuilder : OneDofPIDBaseControllerBuilder<IControllerBuilder>, IIController
    {
        protected override string ControllerType => "I";

        internal IControllerBuilder(Model model)
            : base(model)
        {

        }

        public IIController SetIntegral(double value)
        {
            base._Integral = value.ToString();
            return this;
        }

        public IIController SetInitialConditionForIntegrator(double value)
        {
            base._InitialConditionForIntegrator = value.ToString();
            return this;
        }

        public IIController SetIntegratorMethod(IntegratorMethod method)
        {
            base._TimeDomain = TimeDomain.DiscreteTime;              
            base._IntegratorMethod = method;
            return this;
        }
    }
}