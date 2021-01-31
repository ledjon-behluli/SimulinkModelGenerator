using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class TwoDofPIControllerBuilder : TwoDofPIDBaseControllerBuilder<TwoDofPIControllerBuilder>, ITwoDofPIController
    {
        protected override string ControllerType => "PI";

        public TwoDofPIControllerBuilder(Model model)
            : base(model)
        {

        }

        public IPIController SetProportional(double value)
        {
            base._Proportional = value.ToString();
            return this;
        }

        public IPIController SetIntegral(double value)
        {
            base._Integral = value.ToString();
            return this;
        }

        public IPIController SetInitialConditionForIntegrator(double value)
        {
            base._InitialConditionForIntegrator = value.ToString();
            return this;
        }

        public IPIController SetIntegratorMethod(IntegratorMethod method)
        {
            base._TimeDomain = TimeDomain.DiscreteTime;
            base._IntegratorMethod = method;
            return this;
        }

        public ITwoDofPIController SetProportionalSetpointWeight(double value)
        {
            base._proportionalSetpointWeight = value.ToString();
            return this;
        }
    }
}
