using System;
using SimulinkModelGenerator.Modeler.Builders;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IModel
    {
        IModel WithName(string name);
        IFinalizeModel AddControlSystem(Action<ControlSystemBuilder> action = null);
    }

    public interface IFinalizeModel
    {
        string Build();
        void Save(string path);
    }
}
