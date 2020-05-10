﻿using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    public sealed class SystemLineBuilder : ISystemLine, IControlSystemLine
    {
        private readonly Model model;
        private string previousBlockName;

        public SystemLineBuilder(Model model, string startingBlockName)
        {            
            this.model = model;
            this.previousBlockName = startingBlockName;
        }

        public IControlSystemLine Connect(string sourceBlockName, string destinationBlockName, uint sourceBlockPort = 1, uint destinationBlockPort = 1) =>
            Build(sourceBlockName, destinationBlockName, sourceBlockPort, destinationBlockPort);

        public IControlSystemLine ThanConnect(string destinationBlockName, uint destinationBlockPort = 1) =>
            Build(previousBlockName, destinationBlockName, 1, destinationBlockPort);        

        public IControlSystemLine Branch(Action<SystemBranchBuilder> action)
        {
            SystemBranchBuilder builder = new SystemBranchBuilder(this, model, previousBlockName);
            action?.Invoke(builder);
            return this;
        }

        internal IControlSystemLine Build(string sourceBlockName, string destinationBlockName, uint sourceBlockPort = 1, uint destinationBlockPort = 1)
        {
            if (string.IsNullOrEmpty(sourceBlockName))
                throw new ArgumentNullException("Source block name can not be null or empty.");

            if (string.IsNullOrEmpty(destinationBlockName))
                throw new ArgumentNullException("Destination block name can not be null or empty.");

            if(sourceBlockPort == 0)
                throw new ArgumentException("Source block port number can not be zero.");

            if(destinationBlockPort == 0)
                throw new ArgumentException("Destination block port number can not be zero.");

            Line newLine = new Line()
            {
                P = new List<P>()
                {
                    new P() { Name = "SrcBlock", Text = sourceBlockName },
                    new P() { Name = "DstBlock", Text = destinationBlockName },
                    new P() { Name = "SrcPort", Text = sourceBlockPort.ToString() },
                    new P() { Name = "DstPort", Text = destinationBlockPort.ToString() },
                }
            };

            if (this.model.System.Line.Exists(newLine))
                throw new SimulinkModelGeneratorException("Connection already exists!");

            this.model.System.Line.Add(newLine);
            this.previousBlockName = destinationBlockName;            

            return this;
        }
    }
}
