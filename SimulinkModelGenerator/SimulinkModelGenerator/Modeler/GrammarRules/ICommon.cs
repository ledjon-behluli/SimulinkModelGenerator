using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Common;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IPort : ISystemBlock
    {
        IPort SetPortNumber(int port);
        IPort WithIconDisplay(IconDisplay iconDisplay);
    }
}
