namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemBlock
    {
        ISystemBlock WithName(string name);
        ISystemBlock SetPosition(uint x, uint y);
        ISystemBlock FlipHorizontally();
    }
}
