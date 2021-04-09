namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ILinePath
    {
        IHorizontalPath GoUp();
        IHorizontalPath GoDown();
        IVerticalPath GoLeft();
        IVerticalPath GoRight();
    }

    public interface IHorizontalPath
    {
        void ThanLeft();
        void ThanRight();
    }

    public interface IVerticalPath
    {
        void ThanUp();
        void ThanDown();
    }
}
