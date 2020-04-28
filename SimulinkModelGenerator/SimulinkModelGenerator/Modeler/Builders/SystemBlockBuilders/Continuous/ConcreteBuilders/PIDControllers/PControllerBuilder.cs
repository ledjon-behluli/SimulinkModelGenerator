using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public sealed class PControllerBuilder : PIDBaseControllerBuilder<PControllerBuilder>, IPController
    {
        public override string _ControllerType { get => "P"; }

        public PControllerBuilder(Model model)
            : base(model)
        {

        }

        public IPController SetProportional(double value)
        {
            base._Proportional = value.ToString();
            return this;
        }
    }
}