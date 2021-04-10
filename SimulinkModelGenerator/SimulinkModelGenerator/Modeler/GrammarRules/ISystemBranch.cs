using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemBranch : IControlSystemBranch, IControlSystemBranchNewLine
    {

    }

    public interface IControlSystemBranch
    {
        ISystemBranch Towards(string destinationBlockName, uint destinationBlockPort = 1, Action<IPathBuilder> action = null);
        //IDirection Towards(string destinationBlockName, uint destinationBlockPort = 1, int extra);
    }

    public interface IControlSystemBranchNewLine
    {
        ISystemBranch ThanConnect(string destinationBlockName, uint destinationBlockPort = 1, Action<IPathBuilder> action = null);
    }

    public interface IDirection
    {
        ISystemBranch Downwards();
        ISystemBranch Upwards();
        ISystemBranch Leftwards();
        ISystemBranch Rightwards();
    }
}
