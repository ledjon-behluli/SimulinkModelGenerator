using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class PIDControllerBuilder : PIDBaseControllerBuilder<PIDControllerBuilder>, IPIDController
    {
        public override string _ControllerType => "PID";

        public PIDControllerBuilder(ModelInformation modelInformation)
            : base(modelInformation)
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
            if (base._TimeDomain == TimeDomain.ContinuousTime)
                throw new SimulinkModelGeneratorException("IntegratorMethod can only be set when TimeDomain is of type Discrete-time");

            base._IntegratorMethod = method;
            return this;
        }

        public IPIDController SetFilterMethod(FilterMethod method)
        {
            if (base._TimeDomain == TimeDomain.ContinuousTime)
                throw new SimulinkModelGeneratorException("FilterMethod can only be set when TimeDomain is of type Discrete-time");

            base._FilterMethod = method;
            return this;
        }

        public IPIDController UseDerivativeFilter()
        {
            if (base._TimeDomain == TimeDomain.ContinuousTime)
                throw new SimulinkModelGeneratorException("DerivativeFilter can only be set to true when TimeDomain is of type Discrete-time");

            base._UseFilter = true;
            return this;
        }
    }
}
