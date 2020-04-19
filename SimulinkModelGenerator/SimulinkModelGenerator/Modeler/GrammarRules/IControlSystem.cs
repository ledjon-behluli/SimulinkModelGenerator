using System;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IControlSystem
    {
        IControlSystem SetLocation(int x1, int y1, int x2, int y2);
        IControlSystem SetTiledPaperMargins(uint x1, uint y1, uint x2, uint y2);
        IControlSystem WithReportName(string name);
        ISystemBlock AddBlock(Action<SystemBlockBuilder> action = null);
        ISystemLine AddLine(Action<SystemLineBuilder> action = null);
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
