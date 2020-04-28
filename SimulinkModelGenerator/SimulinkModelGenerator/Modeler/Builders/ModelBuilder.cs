﻿using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed class ModelBuilder : IModel, IFinalizeModel
    {
        private Model model;
        public string MDL { get; private set; }

        private string _ModelName;

        public ModelBuilder()
        {
     
        }

        public IModel WithName(string name)
        {
            _ModelName = name;
            return this;
        }

        public IFinalizeModel AddControlSystem(Action<ControlSystemBuilder> action = null)
        {
            ControlSystemBuilder builder = new ControlSystemBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public string Build()
        {
            this.model = new Model()
            {
                Name = _ModelName,
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

            //TODO: Convert to MDL
            MDL = "test";

            return MDL;
        }

        public void Save(string path)
        {
            if (this.model == null)
                this.Build();

            //TODO: Save content of 'MDL' locally
        }
    }
}
