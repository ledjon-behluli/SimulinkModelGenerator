using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    public sealed class SystemBranchBuilder : IControlSystemBranch, IControlSystemBranchNewLine
    {        
        private readonly Model model;
        private string previousBlockName;

        public SystemBranchBuilder(SystemLineBuilder systemLineBuilder, Model model, string previousBlockName)
        {
            this.model = model;
            this.previousBlockName = previousBlockName;
        }

        public IControlSystemBranchNewLine Towards(string destinationBlockName, uint destinationBlockPort = 1)
        {
            Line matchedLine = this.model.System.Line.FirstOrDefault(l => l.P.Any(p => p.Name == "SrcBlock" && p.Text == previousBlockName));

            if (matchedLine == null)
            {
                this.model.System.Line.Add(new Line()
                {
                    P = new List<Parameter>()
                    {
                        new Parameter() { Name = "SrcBlock", Text = previousBlockName },
                        new Parameter() { Name = "SrcPort", Text = "1" },
                        new Parameter() { Name = "Points", Text = "[0, 0]" }
                    },
                    Branch = new List<Branch>()
                    {
                        new Branch()
                        {
                            P = new List<Parameter>()
                            {
                                new Parameter() { Name = "DstBlock", Text = destinationBlockName },
                                new Parameter() { Name = "DstPort", Text = destinationBlockPort.ToString() }
                            }
                        }
                    }
                });
            }
            else
            {
                matchedLine.Branch.Add(new Branch()
                {
                    P = new List<Parameter>()
                    {
                        new Parameter() { Name = "DstBlock", Text = destinationBlockName },
                        new Parameter() { Name = "DstPort", Text = destinationBlockPort.ToString() }
                    }
                });
            }


            this.previousBlockName = destinationBlockName;
            return this;
        }

        public IControlSystemBranchNewLine ThanConnect(string destinationBlockName, uint destinationBlockPort = 1)
        {            
            if (string.IsNullOrEmpty(destinationBlockName))
                throw new ArgumentNullException("Destination block name can not be null or empty.");

            if (destinationBlockPort == 0)
                throw new ArgumentException("Destination block port number can not be zero.");

            Line newLine = new Line()
            {
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "SrcBlock", Text = previousBlockName },
                    new Parameter() { Name = "SrcPort", Text = "1" },
                    new Parameter() { Name = "DstBlock", Text = destinationBlockName },
                    new Parameter() { Name = "DstPort", Text = destinationBlockPort.ToString() }
                }
            };                                

            if (this.model.System.Line.Contains(newLine))
                throw new SimulinkModelGeneratorException("Connection already defined!");

            this.model.System.Line.Add(newLine);
            this.previousBlockName = destinationBlockName;

            return this;
        }     
    }
}
