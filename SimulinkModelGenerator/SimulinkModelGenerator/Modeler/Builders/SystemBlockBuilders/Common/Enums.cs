using System.ComponentModel;


namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders
{
    public enum IconDisplay
    {
        [Description("Port number")]
        PortNumber,
        [Description("Signal name")]
        SignalName,
        [Description("Port number and signal name")]
        Both
    }

    public enum OutputSignalType
    {
        [Description("auto")]
        Auto,
        [Description("real")]
        Real,
        [Description("complex")]
        Complex
    }

    public enum RootFindingAlgorithm
    {
        [Description("Excat")]
        Exact,
        [Description("Newton-Raphson")]
        Newton_Raphson
    }
}
