using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{   
    public interface IGain : ISystemBlock
    {
        IGain SetGain(decimal gain);
    }

    public interface ISum : ISystemBlock
    {
        ISum WithIconShape(IconShape shape);
        ISum SetInputs(params InputType[] inputs);
    }
}
