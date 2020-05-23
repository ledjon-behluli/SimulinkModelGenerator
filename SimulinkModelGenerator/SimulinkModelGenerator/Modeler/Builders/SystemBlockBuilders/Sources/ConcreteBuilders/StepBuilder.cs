using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class StepBuilder : SystemBlockBuilder<StepBuilder>, IStep
    {
        internal override SizeU Size => new SizeU(30, 30);

        private string _StepTime = "1";
        private string _InitialValue = "0";
        private string _FinalValue = "1";
        private string _SampleTime = "0";

        public StepBuilder(Model model)
            : base(model)
        {

        }


        public IStep SetStepTime(double stepTime)
        {
            _StepTime = stepTime.ToString();
            return this;
        }

        public IStep SetInitialValue(double initialValue)
        {
            _InitialValue = initialValue.ToString();
            return this;
        }

        public IStep SetFinalValue(double finalValue)
        {
            _FinalValue = finalValue.ToString();
            return this;
        }

        public IStep SetSampleTime(double sampleTime)
        {
            if (sampleTime < 0)
                throw new ArgumentException("SampleTime must be a positive number!");

            _SampleTime = sampleTime.ToString();
            return this;
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Step",
                Name = base.GetName("Step"),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base.BlockMirror },
                    new Parameter() { Name = "Time", Text = _StepTime },
                    new Parameter() { Name = "Before", Text = _InitialValue },
                    new Parameter() { Name = "After", Text = _FinalValue },
                    new Parameter() { Name = "SampleTime", Text = _SampleTime }
                }
            });
        }
    }
}
