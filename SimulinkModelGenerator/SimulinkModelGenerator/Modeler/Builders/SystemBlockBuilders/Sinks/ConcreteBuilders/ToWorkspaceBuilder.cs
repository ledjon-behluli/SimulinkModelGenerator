using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimulinkModelGenerator
{
    public enum SaveFormat
    {
        [Description("Structure with time")]
        StructureWithTime,
        [Description("Structure")]
        Structure,
        [Description("Array")]
        Array,
        [Description("Timeseries")]
        Timeseries
    }

    public enum SignalSaveType
    {
        /// <summary>
        /// 2-D array (concatenate along first dimension)
        /// </summary>
        [Description("2-D array (concatenate along first dimension)")]
        _2DArray,
        /// <summary>
        /// 3-D array (concatenate along third dimension)
        /// </summary>
        [Description("3-D array (concatenate along third dimension)")]
        _3DArray
    }
}

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    internal class ToWorkspaceBuilder : SystemBlockBuilder<ToWorkspaceBuilder>, IToWorkspace
    {
        internal override SizeU Size => new SizeU(60, 30);

        private string _VariableName = "simout";
        private string _MaxDataPoints = "inf";
        private string _Decimation = "1";
        private bool _FixptAsFi = false;
        private SignalSaveType _SignalSaveType = SignalSaveType._3DArray;
        private SaveFormat _SaveFormat = SaveFormat.Timeseries;

        internal ToWorkspaceBuilder(Model model)
            : base(model)
        {

        }

        public IToWorkspace SetVariableName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _VariableName = name;

            return this;
        }

        public IToWorkspace SetMaxDataPoints(int points)
        {
            if (points < 1)
                throw new SimulinkModelGeneratorException("Maximum data points must be greater than 0.");

            _MaxDataPoints = points.ToString();
            return this;
        }

        public IToWorkspace SetDecimation(int decimation)
        {
            if (decimation < 1)
                throw new SimulinkModelGeneratorException("Decimation must be greater than 0.");

            _Decimation = decimation.ToString();
            return this;
        }

        public IToWorkspace WithSignalSaveType(SignalSaveType type)
        {
            _SignalSaveType = type;
            return this;
        }

        public IToWorkspace WithSaveFormat(SaveFormat format)
        {
            _SaveFormat = format;
            return this;
        }

        public IToWorkspace LogFixedPointDataAsFiObject()
        {
            _FixptAsFi = true;
            return this;
        }


        internal override void Build()
        {
            model.System.Block.Add(new Block()
            {
                BlockType = "ToWorkspace",
                BlockName = GenerateUniqueName("To\\nWorkspace"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "VariableName", Text = _VariableName },
                    new Parameter() { Name = "MaxDataPoints", Text = _MaxDataPoints },
                    new Parameter() { Name = "Decimation", Text = _Decimation },
                    new Parameter() { Name = "SaveFormat", Text = _SaveFormat.GetDescription() },
                    new Parameter() { Name = "Save2DSignal", Text = _SignalSaveType.GetDescription() },
                    new Parameter() { Name = "FixptAsFi", Text = _FixptAsFi ? "on" : "off" },
                }
            });
        }
    }
}
