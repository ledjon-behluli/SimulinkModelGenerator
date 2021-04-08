using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemLine : IControlSystemLine
    {

    }

    public interface IControlSystemLine
    {
        IControlSystemLine Connect(string sourceBlockName, string destinationBlockName, uint sourceBlockPort = 1, uint destinationBlockPort = 1);
        //IControlSystemLine Connect(Action<SystemLineOrientationBuilder> action);
        IControlSystemLine ThanConnect(string destinationBlockName, uint destinationBlockPort = 1);
        //IControlSystemLine ThanConnect(Action<SystemLineOrientationBuilder> action);
        IControlSystemLine Branch(Action<ISystemBranch> action);
    }

    public interface IControlSystemLineOrientation
    {
        IControlSystemLine Straight();
    }


   
}
