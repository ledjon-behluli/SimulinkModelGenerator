using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IPort : ISystemBlock
    {
        IPort SetPortNumber(int port);
        IPort WithIconDisplay(IconDisplay iconDisplay);
    }
}
