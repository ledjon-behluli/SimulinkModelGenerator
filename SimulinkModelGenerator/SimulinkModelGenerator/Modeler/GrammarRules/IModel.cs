using System;
using SimulinkModelGenerator.Modeler.Builders;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IModel
    {
        IModel WithName(string name);
        IControlSystem AddSystem(Action<ControlSystemBuilder> action = null);
    }
}
