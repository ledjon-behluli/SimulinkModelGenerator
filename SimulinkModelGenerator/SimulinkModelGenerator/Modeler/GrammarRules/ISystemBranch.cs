namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemBranch : IControlSystemBranch, IControlSystemBranchNewLine
    {

    }

    public interface IControlSystemBranch
    {
        IControlSystemBranchNewLine Towards(string destinationBlockName, uint destinationBlockPort = 1);
    }

    public interface IControlSystemBranchNewLine
    {
        IControlSystemBranchNewLine ThanConnect(string destinationBlockName, uint destinationBlockPort = 1);
    }
}
