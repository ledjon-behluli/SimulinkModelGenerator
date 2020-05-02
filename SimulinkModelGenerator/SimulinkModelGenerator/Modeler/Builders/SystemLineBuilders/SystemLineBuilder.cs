
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    public sealed class SystemLineBuilder : IControlSystemLine, ISystemLine
    {
        private readonly Model model;

        private string _SourcBlockName;
        private string _DestinationBlockName;

        public SystemLineBuilder(Model model)
        {
            this.model = model;
        }

        public IControlSystemLine ThanConnect(string sourceBlockName, string destinationBlockName)
            => this.Build(sourceBlockName, destinationBlockName);

        public IControlSystemLine AddBranch()
        {
            return this;
        }

        internal IControlSystemLine Build(string sourceBlockName, string destinationBlockName)
        {
            Line newLine = new Line()
            {
                P = new List<P>()
                {
                    new P() { Name = "SrcBlock", Text = sourceBlockName },
                    new P() { Name = "DstBlock", Text = destinationBlockName }
                }
            };

            if (this.model.System.Line.Contains(newLine))
                throw new SimulinkModelGeneratorException("Connection already defined!");

            this.model.System.Line.Add(newLine);

            return this;
        }
    }
}
