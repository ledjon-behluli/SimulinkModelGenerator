using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    public sealed class StepBuilder : SystemBlockBuilder<StepBuilder>, IStep
    {
        private string _StepTime = "1";
        private string _InitialValue = "0";
        private string _FinalValue = "1";
        private string _SampleTime = "0";

        public StepBuilder(ModelInformation modelInformation)
            : base(modelInformation)
        {

        }


        public IStep SetStepTime(decimal stepTime)
        {
            _StepTime = stepTime.ToString();
            return this;
        }

        public IStep SetInitialValue(decimal initialValue)
        {
            _InitialValue = initialValue.ToString();
            return this;
        }

        public IStep SetFinalValue(decimal finalValue)
        {
            _FinalValue = finalValue.ToString();
            return this;
        }

        public IStep SetSampleTime(decimal sampleTime)
        {
            if (sampleTime < 0)
                throw new SimulinkModelGeneratorException("SampleTime must be a positive number!");

            _SampleTime = sampleTime.ToString();
            return this;
        }


        internal override void Build()
        {
            base.modelInformation.Model.System.Block.Add(new Block()
            {
                BlockType = "Step",
                Name = base.GetName("Step"),
                SID = base._SID,
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "ZOrder", Text = base._ZOrder },
                    new P() { Name = "Time", Text = _StepTime },
                    new P() { Name = "Before", Text = _InitialValue },
                    new P() { Name = "After", Text = _FinalValue },
                    new P() { Name = "SampleTime", Text = _SampleTime }
                }
            });
        }
    }
}
