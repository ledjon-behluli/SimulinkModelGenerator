using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    internal class SystemBranchBuilder : ISystemBranch
    {        
        private readonly Model model;
        private string previousBlockName;

        internal SystemBranchBuilder(Model model, string previousBlockName)
        {
            this.model = model;
            this.previousBlockName = previousBlockName;
        }

        public ISystemBranch Towards(string destinationBlockName, uint destinationBlockPort = 1, Action<IPathBuilder> action = null)
        {
            LinePathBuilder builder = new LinePathBuilder(model);
            Line matchedLine = this.model.System.Line.FirstOrDefault(l => l.P.Any(p => p.Name == "SrcBlock" && p.Text == previousBlockName));
            if (matchedLine == null)
            {
                this.model.System.Line.Add(new Line()
                {
                    P = new List<Parameter>()
                    {
                        new Parameter() { Name = "SrcBlock", Text = previousBlockName },
                        new Parameter() { Name = "SrcPort", Text = "1" },
                        new Parameter() { Name = "Points", Text = CalculateMidPoint(previousBlockName, destinationBlockName) }
                    },
                    Branch = new List<Branch>()
                    {
                        new Branch()
                        {
                            Parameters = new List<Parameter>()
                            {
                                builder.GetBranchPointParameter(previousBlockName, destinationBlockName, action),  // Important: 'Points' needs to be the first parameter in the list
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
                    Parameters = new List<Parameter>()
                    {
                        builder.GetBranchPointParameter(previousBlockName, destinationBlockName, action), // Important: 'Points' needs to be the first parameter in the list
                        new Parameter() { Name = "DstBlock", Text = destinationBlockName },
                        new Parameter() { Name = "DstPort", Text = destinationBlockPort.ToString() }
                    }
                });
            }

            this.previousBlockName = destinationBlockName;
            return this;
        }

        public ISystemBranch ThanConnect(string destinationBlockName, uint destinationBlockPort = 1, Action<IPathBuilder> action = null)
        {            
            if (string.IsNullOrEmpty(destinationBlockName))
                throw new SimulinkModelGeneratorException("Destination block name can not be null or empty.");

            if (destinationBlockPort == 0)
                throw new SimulinkModelGeneratorException("Destination block port number can not be zero.");

            LinePathBuilder builder = new LinePathBuilder(model);
            Line newLine = new Line()
            {
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "SrcBlock", Text = previousBlockName },
                    new Parameter() { Name = "SrcPort", Text = "1" },
                    builder.GetBranchPointParameter(previousBlockName, destinationBlockName, action),
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


        public ISystemBranch Downwards() { throw new NotImplementedException(); }
        public ISystemBranch Upwards() { throw new NotImplementedException(); }
        public ISystemBranch Leftwards() { throw new NotImplementedException(); }
        public ISystemBranch Rightwards() { throw new NotImplementedException(); }


        private string CalculateMidPoint(string sourceBlockName, string destinationBlockName)
        {
            string @default = "[0, 0]";

            Block srcBlock = this.model.System.Block.FirstOrDefault(b => b.BlockName == sourceBlockName);
            if (srcBlock != null)
            {
                Block destBlock = this.model.System.Block.FirstOrDefault(b => b.BlockName == destinationBlockName);
                if (destBlock != null)
                {
                    int distance = BlockExtensions.GetHorizontalDistance(srcBlock, destBlock) / 2;
                    @default = $"[{distance}, 0]";
                }
            }

            return @default;
        }
    }
}
