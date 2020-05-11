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
        IControlSystem AddConnections(string startingBlockName, Action<SystemLineBuilder> action = null);
    }

    public interface IControlSystemLine
    {
        IControlSystemLine ThanConnect(string destinationBlockName, uint destinationBlockPort = 1);
        IControlSystemLine Connect(string sourceBlockName, string destinationBlockName, uint sourceBlockPort = 1, uint destinationBlockPort = 1);
        IControlSystemLine Branch(Action<SystemBranchBuilder> action);
    }

    public interface IControlSystemBranch
    {
        IControlSystemBranchNewLine Towards(string destinationBlockName, uint destinationBlockPort = 1);
    }

    public interface IControlSystemBranchNewLine
    {
        IControlSystemBranchNewLine ThanConnect(string destinationBlockName, uint destinationBlockPort = 1);
    }

    public interface ISystemBlock
    {
        ISystemBlock WithName(string name);
        ISystemBlock SetPosition(uint x, uint y);
        ISystemBlock FlipHorizontally();
    }

    public interface ISystemLine
    {

    }
}
