using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class TwoDofPDControllerBuilder : TwoDofPIDBaseControllerBuilder<TwoDofPDControllerBuilder>, ITwoDofPDController
    {
        protected override string ControllerType => "PD";

        public TwoDofPDControllerBuilder(Model model)
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

        public ITwoDofPDController SetProportionalSetpointWeight(double value)
        {
            base._proportionalSetpointWeight = value.ToString();
            return this;
        }

        public ITwoDofPDController SetDerivativeSetpointWeight(double value)
        {
            base._derivativeSetpointWeight = value.ToString();
            return this;
        }
    }
}
