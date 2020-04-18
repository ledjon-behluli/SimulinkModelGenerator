using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed class ControlSystemBuilder : IControlSystem
    {
        private readonly ModelInformation modelInformation;

        private string _Location = "[-1139, 185, -81, 718]";
        private string _Open = "on";
        private string _PortBlocksUseCompactNotation = "off";
        private string _TiledPaperMargins = "[0.500000, 0.500000, 0.500000, 0.500000]";
        private string _ReportName = "simulink-default.rpt";
        private string _SIDHighWatermark = "6";

        public ControlSystemBuilder(ModelInformation modelInformation)
        {
            this.modelInformation = modelInformation;
        }

        public IControlSystem SetLocation(int x1, int y1, int x2, int y2)
        {
            _Location = $"[{x1}, {y1}, {x2}, {y2}]";
            return this;
        }

        public IControlSystem Closed()
        {
            _Open = "off";
            return this;
        }

        public IControlSystem PortBlocksUseCompactNotation()
        {
            _PortBlocksUseCompactNotation = "on";
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

        public IControlSystem SetSIDHighWatermarkLevel(uint level)
        {
            _SIDHighWatermark = level.ToString();
            return this;
        }

        public ISystemBlock AddBlock<BlockType>(Action<SystemBlockBuilder> action = null)
        {
            SystemBlockBuilder builder = new SystemBlockBuilder(modelInformation);
            action?.Invoke(builder);
            return builder.Build();
        }

        public ISystemLine AddLine(Action<SystemLineBuilder> action = null)
        {
            SystemLineBuilder builder = new SystemLineBuilder(modelInformation);
            action?.Invoke(builder);
            return builder.Build();
        }


        internal IControlSystem Build()
        {
            this.modelInformation.Model.System = new System()
            {
                P = new List<P>()
                {
                    new P(){ Name = "Location", Text = _Location },
                    new P(){ Name = "Open", Text = _Open },
                    new P(){ Name = "PortBlocksUseCompactNotation", Text = _PortBlocksUseCompactNotation },
                    new P(){ Name = "TiledPaperMargins", Text = _TiledPaperMargins },
                    new P(){ Name = "ReportName", Text = _ReportName },
                    new P(){ Name = "SIDHighWatermark", Text = _SIDHighWatermark }
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
