using System.ComponentModel;


namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Common
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
}
