using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class IControllerBuilder : PIDBaseControllerBuilder<IControllerBuilder>, IIController
    {
        public override string _ControllerType { get => "I"; }

        public IControllerBuilder(Model model)
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