using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public enum OutputAfterFinalValue
    {
        [Description("Extrapolation")]
        Extrapolation,
        [Description("Setting to zero")]
        SettingToZero,
        [Description("Holding final value")]
        HoldingFinalValue,
        [Description("Cyclic repetition")]
        CyclicRepetition
    }

    public sealed class FromWorkspaceBuilder : SystemBlockBuilder<FromWorkspaceBuilder>, IFromWorkspace
    {
        internal override SizeU Size => new SizeU(65, 24);

        private string _VariableName = "simin";
        private bool _InterpolateData = true;
        private bool _EnableZeroCrossingDetection = true;
        private OutputAfterFinalValue _OutputAfterFinalValue = OutputAfterFinalValue.Extrapolation;

        public FromWorkspaceBuilder(Model model)
            : base(model)
        {

        }

        public IFromWorkspace SetVariableName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _VariableName = name;

            return this;
        }

        public IFromWorkspace ExtrapolateData()
        {
            _InterpolateData = false;
            return this;
        }

        public IFromWorkspace DisableZeroCrossingDetection()
        {
            _EnableZeroCrossingDetection = false;
            return this;
        }

        internal override void Build()
        {
            model.System.Block.Add(new Block()
            {
                BlockType = "FromWorkspace",
                BlockName = GenerateUniqueName("From\\nWorkspace"),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "VariableName", Text = _VariableName },
                    new Parameter() { Name = "OutDataTypeStr", Text = "Inherit: auto" },
                    new Parameter() { Name = "SampleTime", Text = "-1" },
                    new Parameter() { Name = "Interpolate", Text = _InterpolateData ? "on" : "off" },
                    new Parameter() { Name = "ZeroCross", Text = _EnableZeroCrossingDetection ? "on" : "off" },
                    new Parameter() { Name = "OutputAfterFinalValue", Text = _OutputAfterFinalValue.GetDescription() },
                }
            });
        }
    }
}
