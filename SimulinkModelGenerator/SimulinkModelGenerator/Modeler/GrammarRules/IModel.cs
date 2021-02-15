using System;
using SimulinkModelGenerator.Modeler.Builders;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IModel
    {
        IModel WithName(string name);
        IModel WithSimulationMode(SimulationMode mode = SimulationMode.Normal);
        IModel AddConfigurations(Action<ConfigurationBuilder> action = null);
        IFinalizeModel AddControlSystem(Action<ControlSystemBuilder> action = null);
    }

    public interface IFinalizeModel
    {
        string Build();
        void Save(string path);
    }
}
