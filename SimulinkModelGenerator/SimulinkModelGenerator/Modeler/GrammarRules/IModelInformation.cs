using SimulinkModelGenerator.Modeler.Builders;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IModelInformation
    {
        IFinalizeModel AddModel(Action<ModelBuilder> action = null);       
    }


    public interface IFinalizeModel
    {
        void Build();
        void Save(string path);
    }
}
