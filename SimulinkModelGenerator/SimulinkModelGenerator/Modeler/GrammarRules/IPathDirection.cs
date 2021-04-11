namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IPathDirection
    {
        IPathDirectionDistance Upward();
        IPathDirectionDistance Downward();
        IPathDirectionDistance Leftward();
        IPathDirectionDistance Rightward();
    }

    public interface IPathDirectionDistance
    {
        void Lengthen(uint distance);
        void Shorten(uint distance);
    }
}
