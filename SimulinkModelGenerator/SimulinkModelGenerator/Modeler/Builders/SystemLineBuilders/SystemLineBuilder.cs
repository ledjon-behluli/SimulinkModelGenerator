﻿using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Models;
using System.Linq;
using Combination = SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders.LinePathBuilder.LinePath.Combination;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    internal class SystemLineBuilder : ISystemLine
    {
        private readonly Model model;
        private string previousBlockName;

        internal SystemLineBuilder(Model model, string startingBlockName)
        {            
            this.model = model;
            this.previousBlockName = startingBlockName;
        }

        public ISystemLine Connect(string sourceBlockName, string destinationBlockName, uint sourceBlockPort = 1, uint destinationBlockPort = 1, Action<IPathBuilder> action = null) 
            => Build(sourceBlockName, destinationBlockName, sourceBlockPort, destinationBlockPort, action);

        public ISystemLine ThanConnect(string destinationBlockName, uint destinationBlockPort = 1, Action<IPathBuilder> action = null)
            => Build(previousBlockName, destinationBlockName, 1, destinationBlockPort, action);

        public ISystemLine Branch(Action<ISystemBranch> action)
        {
            SystemBranchBuilder builder = new SystemBranchBuilder(model, previousBlockName);
            action?.Invoke(builder);
            return this;
        }

        internal ISystemLine Build(string sourceBlockName, string destinationBlockName, uint sourceBlockPort = 1, uint destinationBlockPort = 1, Action<IPathBuilder> action = null)
        {
            if (string.IsNullOrEmpty(sourceBlockName))
                throw new SimulinkModelGeneratorException("Source block name can not be null or empty.");

            if (string.IsNullOrEmpty(destinationBlockName))
                throw new SimulinkModelGeneratorException("Destination block name can not be null or empty.");

            if(sourceBlockPort == 0)
                throw new SimulinkModelGeneratorException("Source block port number can not be zero.");

            if(destinationBlockPort == 0)
                throw new SimulinkModelGeneratorException("Destination block port number can not be zero.");

            LinePathBuilder builder = new LinePathBuilder(model);
            Line newLine = new Line()
            {
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "SrcBlock", Text = sourceBlockName },
                    new Parameter() { Name = "SrcPort", Text = sourceBlockPort.ToString() },
                    builder.GetBranchPointParameter(previousBlockName, destinationBlockName, action),
                    new Parameter() { Name = "DstBlock", Text = destinationBlockName },
                    new Parameter() { Name = "DstPort", Text = destinationBlockPort.ToString() },
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
