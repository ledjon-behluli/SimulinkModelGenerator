namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IConstant : ISystemBlock
    {
        IConstant SetValue(decimal value);
    }

    public interface IStep : ISystemBlock
    {
        IStep SetStepTime(decimal stepTime);
        IStep SetInitialValue(decimal initialValue);
        IStep SetFinalValue(decimal finalValue);
        IStep SetSampleTime(decimal sampleTime);
    }

    public interface IRamp : ISystemBlock
    {
        IRamp SetSlope(decimal slope);
        IRamp SetStartTime(decimal startTime);
        IRamp SetInitialOutput(decimal initialOutput);
    }
}
