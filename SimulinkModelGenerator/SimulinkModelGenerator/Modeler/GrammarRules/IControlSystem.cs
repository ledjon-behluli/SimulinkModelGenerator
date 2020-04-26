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
        IControlSystem SetLocation(int x1, int y1, int x2, int y2);
        IControlSystem SetTiledPaperMargins(uint x1, uint y1, uint x2, uint y2);
        IControlSystem WithReportName(string name);

        IControlSystem AddSources(Action<SystemSourcesBuilder> action = null);
        IControlSystem AddSinks(Action<SystemSinksBuilder> action = null);
        IControlSystem AddMathOperations(Action<SystemMathOperationsBuilder> action = null);
        IControlSystem AddContinuous(Action<SystemContinuousBuilder> action = null);
    }

    public interface ISystemBlock
    {
        ISystemBlock WithName(string name);
        ISystemBlock SetPosition(int x1, int y1, int x2, int y2);
    }

    public interface ISystemLine
    {

    }
}
