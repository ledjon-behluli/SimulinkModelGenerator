using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class PDControllerBuilder : PIDBaseControllerBuilder<PIDControllerBuilder>, IPDController
    {
        public override string _ControllerType { get => "PD"; }

        public PDControllerBuilder(ModelInformation modelInformation)
            : base(modelInformation)
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
            if (base._TimeDomain == TimeDomain.ContinuousTime)
                throw new SimulinkModelGeneratorException("FilterMethod can only be set when TimeDomain is of type Discrete-time");

            base._FilterMethod = method;
            return this;
        }

        public IPDController UseDerivativeFilter()
        {
            if (base._TimeDomain == TimeDomain.ContinuousTime)
                throw new SimulinkModelGeneratorException("DerivativeFilter can only be set to true when TimeDomain is of type Discrete-time");

            base._UseFilter = true;
            return this;
        }
    }
}
