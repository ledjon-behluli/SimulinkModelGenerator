using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources
{
    internal partial class RepeatingSequenceBuilder : SystemBlockBuilder<RepeatingSequenceBuilder>, IRepeatingSequence
    {
        internal override SizeU Size => new SizeU(30, 30);

        private TimeStamp _TimeStamp = TimeStamp.Default;
        private OutputValue _OutputValue = OutputValue.Default;

        internal RepeatingSequenceBuilder(Model model)
            : base(model)
        {

        }

        public IRepeatingSequence SetTimeStamps(params double[] values)
        {
            var timeStamp = new TimeStamp(values);
            timeStamp.ThrowIfInvalid();

            _TimeStamp = timeStamp;
            return this;
        }

        public IRepeatingSequence SetOutputValues(params double[] values)
        {
            OutputValue outputValue = new OutputValue(values);

            _OutputValue = outputValue;
            return this;
        }

        internal override void Build()
        {
            if (_TimeStamp.Count != _OutputValue.Count)
                throw new SimulinkModelGeneratorException("TimeStamps count needs to be the same as OutputValues count.");

            model.System.Block.Add(new Block()
            {
                BlockType = "Reference",
                BlockName = GenerateUniqueName("Repeating\\nSequence"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "Ports", Text = "[0 1]" },
                    new Parameter() { Name = "LibraryVersion", Text = "1.391" },
                    new Parameter() { Name = "SourceType", Text = "Repeating table" },
                    new Parameter() { Name = "SourceBlock", Text = "simulink/Sources/Repeating\\nSequence" },
                    new Parameter() { Name = "rep_seq_t", Text = _TimeStamp.ToString() },
                    new Parameter() { Name = "rep_seq_y", Text = _OutputValue.ToString() }
                }
            });
        }
    }

    internal partial class RepeatingSequenceBuilder
    {
        private class RepeatingSequence
        {
            protected double[] _values;
            public int Count => _values.Length;

            public RepeatingSequence(params double[] values)
            {
                _values = values.Length > 0 ? values : new double[] { 0 };
            }

            public override string ToString()
            {
                string returnValue = "[0]";

                if (_values.Length > 0)
                {
                    returnValue = "[";

                    foreach (var value in _values)
                    {
                        returnValue += $"{value}, ";
                    }

                    returnValue = $"{returnValue.Substring(0, returnValue.Length - 2)}]";
                }

                return returnValue;
            }
        }

        private class TimeStamp : RepeatingSequence
        {
            public static TimeStamp Default => new TimeStamp(0, 2);

            public TimeStamp(params double[] values)
                : base(values)
            {

            }

            public void ThrowIfInvalid()
            {
                if (_values.Any(s => s < 0))
                    throw new SimulinkModelGeneratorException("Only positive numbers are allowed for time sequence.");

                bool isMontonicallyIncreasing = !_values.SkipWhile((x, i) => i == 0 || _values[i - 1] <= x).Any();

                if (!isMontonicallyIncreasing)
                    throw new SimulinkModelGeneratorException("Time sequence values must be montonically increasing.");
            }
        }

        private class OutputValue : RepeatingSequence
        {
            public static OutputValue Default => new OutputValue(0, 2);

            public OutputValue(params double[] values)
                : base(values)
            {

            }
        }
    }
}
