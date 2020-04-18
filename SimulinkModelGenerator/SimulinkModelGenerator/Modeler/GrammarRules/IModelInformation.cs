using SimulinkModelGenerator.Modeler.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IModelInformation
    {
        IModelInformation WithVersion(string version);
        IFinalizeModel AddModel(Action<ModelBuilder> action = null);       
    }


    public interface IFinalizeModel
    {
        void Build();
        void Save(string path);
    }
}
