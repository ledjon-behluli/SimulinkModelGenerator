using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders
{  
    public sealed class ControlSystemBuilder : IControlSystem
    {
        private readonly Model model;

        private string _Location = "[-1139, 185, -81, 718]";
        private string _TiledPaperMargins = "[0.500000, 0.500000, 0.500000, 0.500000]";
        private string _ReportName = "simulink-default.rpt";

        public ControlSystemBuilder(Model model)
        {
            this.model = model;
        }

        public IControlSystem SetLocation(int x1, int y1, int x2, int y2)
        {
            _Location = $"[{x1}, {y1}, {x2}, {y2}]";
            return this;
        }

        public IControlSystem SetTiledPaperMargins(uint x1, uint y1, uint x2, uint y2)
        {
            _TiledPaperMargins = $"[{x1}, {y1}, {x2}, {y2}]";
            return this;
        }

        public IControlSystem WithReportName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _ReportName = name;
            return this;
        }

     
        #region System Blocks

        public IControlSystem AddSources(Action<SystemSourcesBuilder> action = null)
        {
            SystemSourcesBuilder builder = new SystemSourcesBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public IControlSystem AddSinks(Action<SystemSinksBuilder> action = null)
        {
            SystemSinksBuilder builder = new SystemSinksBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public IControlSystem AddMathOperations(Action<SystemMathOperationsBuilder> action = null)
        {
            SystemMathOperationsBuilder builder = new SystemMathOperationsBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public IControlSystem AddContinuous(Action<SystemContinuousBuilder> action = null)
        {
            SystemContinuousBuilder builder = new SystemContinuousBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        #endregion

        #region System Lines


        #endregion

        internal IControlSystem Build()
        {
            this.model.System = new System()
            {
                P = new List<P>()
                {
                    // Customizable
                    new P(){ Name = "Location", Text = _Location },                    
                    new P(){ Name = "TiledPaperMargins", Text = _TiledPaperMargins },
                    new P(){ Name = "ReportName", Text = _ReportName },
                    // Default
                    new P(){ Name = "Open", Text = "on" },
                    new P(){ Name = "PortBlocksUseCompactNotation", Text = "off" },                    
                    new P(){ Name = "SIDHighWatermark", Text = "6" }
                },
                Block = new List<Block>()
                {

                },
                Line = new List<Line>()
                {

                }
            };

            return this;
        }        
    }
}
