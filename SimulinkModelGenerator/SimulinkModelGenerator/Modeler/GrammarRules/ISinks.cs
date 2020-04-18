namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IScope : ISystemBlock
    {
        IScope SetInputPorts(uint numberOfPorts);
    }

    public interface IDisplay : ISystemBlock
    {

    }
}
