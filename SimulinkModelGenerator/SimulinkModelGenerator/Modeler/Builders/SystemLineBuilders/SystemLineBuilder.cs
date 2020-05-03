using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    public enum BranchType
    {
        Direct,
        RightTurn
    }

    public sealed class SystemLineBuilder : ISystemLine, IControlSystemLine
    {
        private readonly Model model;
        private readonly ControlSystemBuilder controlSystemBuilder;

        private string previousBlockName;
        private Line activeLine;

        private string _SourcBlockName;
        private string _DestinationBlockName;

        public SystemLineBuilder(ControlSystemBuilder controlSystemBuilder, Model model, string startingBlockName)
        {
            this.controlSystemBuilder = controlSystemBuilder;
            this.model = model;
            this.previousBlockName = startingBlockName;
        }

        public IControlSystemLine ThanConnect(string destinationBlockName) => Build(previousBlockName, destinationBlockName);

        public IControlSystemLine BranchTo(string destinationBlockName, BranchType type = BranchType.RightTurn)
        {
            if (string.IsNullOrEmpty(destinationBlockName))
                throw new ArgumentException("Destination block name can not be null or empty.");

            Block destBlock = this.model.System.Block.Find(b => b.Name == destinationBlockName);            

            if (destBlock == null)
                throw new ArgumentException($"Could not find block with name '{destinationBlockName}' in model.");

            if (type == BranchType.RightTurn)
            {
                Block prevBlock = this.model.System.Block.Find(b => b.Name == previousBlockName);

                Point destCenterPoint = destBlock.GetCenterPoint();
                Point prevCenterPoint = prevBlock.GetCenterPoint();

                int offsetY = -1 * (prevCenterPoint.Y - destCenterPoint.Y);

                this.activeLine.Branch.Add(new Branch()
                {
                    P = new List<P>()
                    {
                        new P() { Name = "DstBlock", Text = destinationBlockName },
                        new P() { Name = "Points", Text = $"[0, {offsetY}]" },
                        new P() { Name = "DstPort", Text = "1" }
                    }
                });
            }
            else
            {
                this.activeLine.Branch.Add(new Branch()
                {
                    P = new List<P>()
                    {
                        new P() { Name = "DstBlock", Text = destinationBlockName },
                        new P() { Name = "DstPort", Text = "1" }
                    }
                });
            }

            this.previousBlockName = destinationBlockName;

            return this;
        }


        public IControlSystemNewConnection Done()
        {
            return this.controlSystemBuilder;
        }


        internal IControlSystemLine Build(string sourceBlockName, string destinationBlockName)
        {
            if (string.IsNullOrEmpty(sourceBlockName))
                throw new ArgumentNullException("Source block name can not be null or empty.");

            if (string.IsNullOrEmpty(sourceBlockName))
                throw new ArgumentNullException("Destination block name can not be null or empty.");


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
            this.previousBlockName = destinationBlockName;
            this.activeLine = newLine;

            return this;
        }
    }
}
