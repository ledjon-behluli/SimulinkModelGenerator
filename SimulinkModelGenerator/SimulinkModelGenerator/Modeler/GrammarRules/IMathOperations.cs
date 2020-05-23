using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{   
    public interface ISystemMathOperation
    {
        ISystemMathOperation AddGain(Action<GainBuilder> action = null);
        ISystemMathOperation AddSum(Action<SumBuilder> action = null);
    }

    public interface IGain : ISystemBlock
    {
        IGain SetGain(double gain);
    }

    public interface ISum : ISystemBlock
    {
        ISum WithIconShape(IconShape shape);
        ISum SetInputs(params InputType[] inputs);
    }
}
