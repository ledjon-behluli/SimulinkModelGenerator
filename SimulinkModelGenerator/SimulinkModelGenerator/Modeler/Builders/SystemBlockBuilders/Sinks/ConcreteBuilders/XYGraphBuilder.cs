using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    internal class XYGraphBuilder : SystemBlockBuilder<XYGraphBuilder>, IXYGraph
    {
        internal override SizeU Size => new SizeU(30, 35);

        private string _XMin = "-1";
        private string _XMax = "1";
        private string _YMin = "-1";
        private string _YMax = "1";
        private string _SampleTime = "-1";

        internal XYGraphBuilder(Model model)
            : base(model)
        {

        }

        public IXYGraph SetX(double xMin = -1, double xMax = 1)
        {
            if (xMin >= xMax)
                throw new SimulinkModelGeneratorException("Input (X) min value can not be greater or equal to (X) max value.");

            _XMin = xMin.ToString();
            _XMax = xMax.ToString();

            return this;
        }

        public IXYGraph SetY(double yMin = -1, double yMax = 1)
        {
            if (yMin >= yMax)
                throw new SimulinkModelGeneratorException("Input (Y) min value can not be greater or equal to (Y) max value.");

            _YMin = yMin.ToString();
            _YMax = yMax.ToString();

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
                Parameters = new List<Parameter>()
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
