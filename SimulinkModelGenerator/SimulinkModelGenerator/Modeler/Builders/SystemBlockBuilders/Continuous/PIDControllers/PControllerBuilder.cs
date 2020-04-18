using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class PControllerBuilder : PIDBaseControllerBuilder<PControllerBuilder>, IPController
    {
        public override string _ControllerType { get => "P"; }

        public PControllerBuilder(ModelInformation modelInformation)
            : base(modelInformation)
        {

        }

        public IPController SetProportional(double value)
        {
            base._Proportional = value.ToString();
            return this;
        }
    }
}