using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class PIControllerBuilder : PIDBaseControllerBuilder<PIControllerBuilder>, IPIController
    {
        public override string _ControllerType { get => "PI"; }

        public PIControllerBuilder(Model model)
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
    }
}
