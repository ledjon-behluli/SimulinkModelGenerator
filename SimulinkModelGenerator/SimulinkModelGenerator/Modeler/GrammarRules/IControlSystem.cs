using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IControlSystem
    {
        IControlSystem AddSources(Action<SystemSourcesBuilder> action = null);
        IControlSystem AddSinks(Action<SystemSinksBuilder> action = null);
        IControlSystem AddMathOperations(Action<SystemMathOperationsBuilder> action = null);
        IControlSystem AddContinuous(Action<SystemContinuousBuilder> action = null);

        IControlSystemLine Connect(string sourceBlockName, string destinationBlockName);
    }

    public interface IControlSystemLine
    {
        IControlSystemLine ThanConnect(string destinationBlockName);
        IControlSystemLine BranchTo(string destinationBlockName, BranchType type = BranchType.RightTurn);
        IControlSystemNewConnection Done();
    }

    public interface IControlSystemNewConnection
    {
        IControlSystemLine Connect(string sourceBlockName, string destinationBlockName);
    }

    public interface ISystemBlock
    {
        ISystemBlock WithName(string name);
        ISystemBlock SetPosition(uint x, uint y, uint width, uint height);
        ISystemBlock FlipHorizontally();
    }

    public interface ISystemLine
    {

    }
}
