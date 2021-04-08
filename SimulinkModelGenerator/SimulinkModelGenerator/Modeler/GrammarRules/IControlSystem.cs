using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IControlSystem
    {
        IControlSystem AddSources(Action<ISystemSource> action = null);
        IControlSystem AddSinks(Action<ISystemSink> action = null);
        IControlSystem AddMathOperations(Action<ISystemMathOperation> action = null);
        IControlSystem AddContinuous(Action<ISystemContinuous> action = null);
        IControlSystem AddConnections(string startingBlockName, Action<ISystemLine> action = null);
    }
}
