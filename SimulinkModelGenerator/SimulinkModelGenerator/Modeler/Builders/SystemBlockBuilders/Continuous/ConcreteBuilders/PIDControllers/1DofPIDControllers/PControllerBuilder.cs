using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class PControllerBuilder : OneDofPIDBaseControllerBuilder<PControllerBuilder>, IPController
    {
        protected override string ControllerType => "P";

        internal PControllerBuilder(Model model)
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