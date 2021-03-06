﻿using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    internal abstract class BaseRandomNumberBuilder<T> : SystemBlockBuilder<T>, IBaseRandomNumber
        where T : BaseRandomNumberBuilder<T>
    {
        internal override SizeU Size => new SizeU(30, 30);
        internal abstract string BlockType { get; }
        internal abstract string BlockName { get; }

        protected string _Seed = "0";
        protected string _SampleTime = "0.1";

        internal BaseRandomNumberBuilder(Model model)
            : base(model)
        {

        }

        public IBaseRandomNumber SetSeed(double seed)
        {
            _Seed = seed.ToString();
            return this;
        }

        public IBaseRandomNumber SetSampleTime(double sampleTime)
        {
            if (sampleTime < 0)
                throw new SimulinkModelGeneratorException("SampleTime must be greater than or equal to 0.");

            _SampleTime = sampleTime.ToString();
            return this;
        }


        internal Block GetBlock()
        {
            return new Block()
            {
                BlockType = BlockType,
                BlockName = GenerateUniqueName(BlockName),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = _Position },
                    new Parameter() { Name = "BlockMirror", Text = _BlockMirror },
                    new Parameter() { Name = "Seed", Text = _Seed },
                    new Parameter() { Name = "SampleTime", Text = _SampleTime },
                    new Parameter() { Name = "VectorParams1D", Text = "on" }
                }
            };
        }
    }
}
