using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class IControllerBuilder : PIDBaseControllerBuilder<IControllerBuilder>, IIController
    {
        public override string _ControllerType { get => "I"; }

        public IControllerBuilder(ModelInformation modelInformation)
            : base(modelInformation)
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
            if (base._TimeDomain == TimeDomain.ContinuousTime)
                throw new SimulinkModelGeneratorException("IntegratorMethod can only be set when TimeDomain is of type Discrete-time");

            base._IntegratorMethod = method;
            return this;
        }
    }
}