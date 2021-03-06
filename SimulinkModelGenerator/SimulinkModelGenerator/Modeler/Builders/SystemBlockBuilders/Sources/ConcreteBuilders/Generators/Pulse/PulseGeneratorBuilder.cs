﻿using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    internal abstract class PulseGeneratorBuilder<T> : GeneratorBuilder<T>
        where T : PulseGeneratorBuilder<T>
    {
        protected override string BlockType => "DiscretePulseGenerator";
        protected override string BlockName => "Pulse\\nGenerator";
        protected abstract string PulseType { get;}

        protected string _Period = "2";
        protected string _PulseWidth = "1";
        protected string _PhaseDelay = "0";
        protected string _SampleTime = "1";


        internal PulseGeneratorBuilder(Model model)
            : base(model)
        {

        }


        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "PulseType", Text = PulseType });
            block.Parameters.Add(new Parameter() { Name = "Period", Text = _Period });
            block.Parameters.Add(new Parameter() { Name = "PulseWidth", Text = _PulseWidth });
            block.Parameters.Add(new Parameter() { Name = "PhaseDelay", Text = _PhaseDelay });
            block.Parameters.Add(new Parameter() { Name = "SampleTime", Text = _SampleTime });

            model.System.Block.Add(block);
        }
    }
}
