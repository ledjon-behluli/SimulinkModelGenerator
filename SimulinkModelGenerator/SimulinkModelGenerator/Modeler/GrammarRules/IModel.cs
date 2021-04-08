using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IModel
    {
        IModel WithName(string name);
        IModel WithSimulationMode(SimulationMode mode = SimulationMode.Normal);
        IModel Configure(Action<IConfiguration> action = null);
        IFinalizeModel AddControlSystem(Action<IControlSystem> action = null);
    }

    public interface IFinalizeModel
    {
        string Build();
        void Save(string path);
    }
}
