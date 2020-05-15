﻿using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class PDControllerBuilder : PIDBaseControllerBuilder<PDControllerBuilder>, IPDController
    {
        public override string _ControllerType { get => "PD"; }

        public PDControllerBuilder(Model model)
            : base(model)
        {

        }

        public IPDController SetProportional(double value)
        {
            base._Proportional = value.ToString();
            return this;
        }

        public IPDController SetDerivative(double value)
        {
            base._Derivative = value.ToString();
            return this;
        }

        public IPDController SetFilterCoefficient(double value)
        {
            base._FilterCoefficient = value.ToString();
            return this;
        }

        public IPDController SetInitialConditionForFilter(double value)
        {
            base._InitialConditionForFilter = value.ToString();
            return this;
        }


        public IPDController SetFilterMethod(FilterMethod method)
        {
            base._TimeDomain = TimeDomain.DiscreteTime;
            base._FilterMethod = method;
            return this;
        }

        public IPDController UseDerivativeFilter()
        {
            base._TimeDomain = TimeDomain.DiscreteTime;
            base._UseFilter = true;
            return this;
        }
    }
}
