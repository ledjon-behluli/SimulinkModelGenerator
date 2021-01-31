using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class PIDControllerBuilder : OneDofPIDBaseControllerBuilder<PIDControllerBuilder>, IPIDController
    {
        protected override string ControllerType => "PID";

        public PIDControllerBuilder(Model model)
            : base(model)
        {
                 
        }

        public IPIDController SetProportional(double value)
        {
            base._Proportional = value.ToString();
            return this;
        }

        public IPIDController SetIntegral(double value)
        {
            base._Integral = value.ToString();
            return this;
        }

        public IPIDController SetDerivative(double value)
        {
            base._Derivative = value.ToString();
            return this;
        }

        public IPIDController SetFilterCoefficient(double value)
        {
            base._FilterCoefficient = value.ToString();
            return this;
        }

        public IPIDController SetInitialConditionForIntegrator(double value)
        {
            base._InitialConditionForIntegrator = value.ToString();
            return this;
        }

        public IPIDController SetInitialConditionForFilter(double value)
        {
            base._InitialConditionForFilter = value.ToString();
            return this;
        }

        public IPIDController SetIntegratorMethod(IntegratorMethod method)
        {
            base._TimeDomain = TimeDomain.DiscreteTime;
            base._IntegratorMethod = method;
            return this;
        }

        public IPIDController SetFilterMethod(FilterMethod method)
        {
            base._TimeDomain = TimeDomain.DiscreteTime;             
            base._FilterMethod = method;
            return this;
        }

        public IPIDController UseDerivativeFilter()
        {
            base._TimeDomain = TimeDomain.DiscreteTime;            
            base._UseFilter = true;
            return this;
        }
    }
}
