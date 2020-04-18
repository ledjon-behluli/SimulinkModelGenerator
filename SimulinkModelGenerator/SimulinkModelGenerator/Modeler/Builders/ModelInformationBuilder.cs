using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed class ModelInformationBuilder : IModelInformation, IFinalizeModel
    {
        private readonly ModelInformation modelInformation = new ModelInformation();

        public ModelInformationBuilder()
        {
            modelInformation = new ModelInformation()
            {
                Version = "1.0"
            };
        }

        public IModelInformation WithVersion(string version)
        {
            if(!string.IsNullOrEmpty(version))
                modelInformation.Version = version;
            return this;
        }

        public IFinalizeModel AddModel(Action<ModelBuilder> action = null)
        {
            ModelBuilder builder = new ModelBuilder(this, modelInformation);
            action?.Invoke(builder);
            return builder.Build();
        }


        public void Build()
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }
    }
}
