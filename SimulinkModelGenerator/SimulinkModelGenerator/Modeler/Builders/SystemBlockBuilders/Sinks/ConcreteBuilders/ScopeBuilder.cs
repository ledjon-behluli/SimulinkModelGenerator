using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class ScopeBuilder : SystemBlockBuilder<ScopeBuilder>, IScope
    {
        internal override SizeU Size => new SizeU(30, 32);

        private string _NumInputPorts = "1";
        private string _Ports = "[1]";

        public ScopeBuilder(Model model)
            : base(model)
        {

        }

        public IScope SetInputPorts(uint numberOfPorts)
        {
            if (numberOfPorts > 0)
            {
                _NumInputPorts = numberOfPorts.ToString();
                _Ports = $"[{numberOfPorts}]";
            }
            else
                throw new ArgumentException("Scope can not have less than 1 port!");

            return this;
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Scope",
                BlockName = GenerateUniqueName("Scope"),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Ports", Text = _Ports },
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "NumInputPorts", Text = _NumInputPorts }
                }
            });
        }
    }
}