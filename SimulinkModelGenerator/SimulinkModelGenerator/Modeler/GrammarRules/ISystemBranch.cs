using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemBranch : IControlSystemBranch, IControlSystemBranchNewLine
    {

    }

    public interface IControlSystemBranch
    {
        ISystemBranch Towards(string destinationBlockName, uint destinationBlockPort = 1, Action<ILinePath> path = null);
    }

    public interface IControlSystemBranchNewLine
    {
        ISystemBranch ThanConnect(string destinationBlockName, uint destinationBlockPort = 1, Action<ILinePath> path = null);
    }
}
