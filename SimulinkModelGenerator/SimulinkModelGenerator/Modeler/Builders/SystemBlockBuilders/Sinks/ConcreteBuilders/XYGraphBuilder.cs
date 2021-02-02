using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class XYGraphBuilder : SystemBlockBuilder<XYGraphBuilder>, IXYGraph
    {
        internal override SizeU Size => new SizeU(30, 35);

        private string _XMin = "-1";
        private string _XMax = "1";
        private string _YMin = "-1";
        private string _YMax = "1";
        private string _SampleTime = "-1";

        public XYGraphBuilder(Model model)
            : base(model)
        {

        }

        public IXYGraph SetXMin(double value)
        {
            if (value >= double.Parse(_XMax))
                throw new ArgumentException("First input (X) min value can not be greater or equal to its max value.");

            _XMin = value.ToString();
            return this;
        }

        public IXYGraph SetXMax(double value)
        {
            if (value < double.Parse(_XMin))
                throw new ArgumentException("First input (X) max value can not be less than its min value.");

            _XMax = value.ToString();
            return this;
        }

        public IXYGraph SetYMin(double value)
        {
            if (value >= double.Parse(_YMax))
                throw new ArgumentException("Second input (Y) min value can not be greater or equal to its max value.");

            _YMin = value.ToString();
            return this;
        }

        public IXYGraph SetYMax(double value)
        {
            if (value < double.Parse(_YMin))
                throw new ArgumentException("Second input (Y) max value can not be less than its min value.");

            _YMax = value.ToString();
            return this;
        }

        public IXYGraph SetSampleTime(double sampleTime)
        {
            _SampleTime = sampleTime.ToString();
            return this;
        }


        internal override void Build()
        {
            model.System.Block.Add(new Block()
            {
                BlockType = "Reference",
                BlockName = GenerateUniqueName("XY Graph"),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "Ports", Text = "[2]" },
                    new Parameter() { Name = "LibraryVersion", Text = "1.391" },
                    new Parameter() { Name = "SourceType", Text = "XY scope." },
                    new Parameter() { Name = "SourceBlock", Text = "simulink/Sinks/XY Graph" },
                    new Parameter() { Name = "xmin", Text = _XMin },
                    new Parameter() { Name = "xmax", Text = _XMax },
                    new Parameter() { Name = "ymin", Text = _YMin },
                    new Parameter() { Name = "ymax", Text = _YMax },
                    new Parameter() { Name = "st", Text = _SampleTime },
                }
            });
        }
    }
}
