using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed class ModelBuilder : IModel
    {
        private readonly ModelInformation modelInformation;
        private readonly ModelInformationBuilder modelInformationBuilder;

        private string modelName;

        public ModelBuilder(ModelInformationBuilder modelInformationBuilder, ModelInformation modelInformation)
        {
            this.modelInformation = modelInformation;
            this.modelInformationBuilder = modelInformationBuilder;
        }

        public IModel WithName(string name)
        {
            modelName = name;
            return this;
        }

        public IControlSystem AddControlSystem(Action<ControlSystemBuilder> action = null)
        {
            ControlSystemBuilder builder = new ControlSystemBuilder(modelInformation);
            action?.Invoke(builder);
            return builder.Build();
        }

        internal IFinalizeModel Build()
        {
            this.modelInformation.Model = new Model()
            {
                Name = modelName,
                P = new List<P>()
                {
                    new P(){ Name = "Version", Text = "8.9" },
                    new P(){ Name = "SavedCharacterEncoding", Text = "windows-1252" },
                    new P(){ Name = "LogicAnalyzerGraphicalSettings", Text = "" },
                    new P(){ Name = "LogicAnalyzerPlugin", Text = "on" },
                    new P(){ Name = "LogicAnalyzerSignalOrdering", Text = "" },
                    new P(){ Name = "DiagnosticSuppressor", Text = "on" },
                    new P(){ Name = "SuppressorTable", Text = "22 serialization::archive 11 0 6 0 0 0 8 0" },
                    new P(){ Name = "SLCCPlugin", Text = "on" },
                    new P(){ Name = "ScopeRefreshTime", Text = "0.035000" },
                    new P(){ Name = "OverrideScopeRefreshTime", Text = "on" },
                    new P(){ Name = "DisableAllScopes", Text = "off" },
                    new P(){ Name = "DataTypeOverride", Text = "UseLocalSettings" },
                    new P(){ Name = "DataTypeOverrideAppliesTo", Text = "AllNumericTypes" },
                    new P(){ Name = "MinMaxOverflowLogging", Text = "UseLocalSettings" },
                    new P(){ Name = "MinMaxOverflowArchiveMode", Text = "Overwrite" },
                    new P(){ Name = "FPTRunName", Text = "Run 1" },
                    new P(){ Name = "MaxMDLFileLineLength", Text = "120" },
                    new P(){ Name = "LastSavedArchitecture", Text = "win64" },
                    new P(){ Name = "HideAutomaticNames", Text = "on" }                    
                }
            };

            return modelInformationBuilder;
        }
    }
}
