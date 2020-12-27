using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public enum Form
    {
        [Description("Ideal")]
        Ideal,

        [Description("Parallel")]
        Parallel
    }

    public enum TimeDomain
    {
        [Description("Continuous-time")]
        ContinuousTime,

        [Description("Discrete-time")]
        DiscreteTime
    }

    public enum IntegratorMethod
    {
        [Description("Forward Euler")]
        ForwardEuler,

        [Description("Backward Euler")]
        BackwardEuler,

        [Description("Trapezoidal")]
        Trapezoidal
    }

    public enum FilterMethod
    {
        [Description("Forward Euler")]
        ForwardEuler,

        [Description("Backward Euler")]
        BackwardEuler,

        [Description("Trapezoidal")]
        Trapezoidal
    }

    public abstract class PIDBaseControllerBuilder<T> : SystemBlockBuilder<T>, IPIDBaseController, IPIDSampleTime
        where T : PIDBaseControllerBuilder<T>
    {
        internal override SizeU Size => new SizeU(40, 36);

        public abstract string _ControllerType { get; }

        protected string _Proportional = "1";
        protected string _Integral = "1";
        protected string _Derivative = "0";
        protected string _FilterCoefficient = "100";
        protected string _InitialConditionForIntegrator = "0";
        protected string _InitialConditionForFilter = "0";
        protected Form _Form = Form.Parallel;
        protected TimeDomain _TimeDomain = TimeDomain.ContinuousTime;        
        protected IntegratorMethod _IntegratorMethod;
        protected FilterMethod _FilterMethod;
        protected string _SampleTime = "-1";
        protected bool _UseFilter = false;


        public PIDBaseControllerBuilder(Model model)
            : base(model)
        {

        }

        public IPIDBaseController SetForm(Form form)
        {
            _Form = form;
            return this;
        }

        public IPIDSampleTime SetTimeDomain(TimeDomain timeDomain)
        {
            _TimeDomain = timeDomain;
            return this;
        }

        public IPIDBaseController SetSampleTime(double sampleTime)
        {
            _TimeDomain = TimeDomain.DiscreteTime;

            if (sampleTime < 0 && sampleTime != -1)                
                throw new SimulinkModelGeneratorException("SampleTime can not be negative, besides -1 for inherited types");

            _SampleTime = sampleTime.ToString();

            return this;
        }


        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Reference",
                Name = $"PID Controller{GetBlockTypeCount("Reference")}",
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror }
                },
                InstanceData = new InstanceData()
                {
                    P = new List<Parameter>()
                    {
                        new Parameter() { Name = "Controller", Text = _ControllerType },
                        new Parameter() { Name = "P", Text = _Proportional },
                        new Parameter() { Name = "I", Text = _Integral },
                        new Parameter() { Name = "D", Text = _Derivative },
                        new Parameter() { Name = "N", Text = _FilterCoefficient },
                        new Parameter() { Name = "InitialConditionForIntegrator", Text = _InitialConditionForIntegrator },
                        new Parameter() { Name = "InitialConditionForFilter", Text = _InitialConditionForFilter },
                        new Parameter() { Name = "Form", Text = _Form.GetDescription() },
                        new Parameter() { Name = "TimeDomain", Text = _TimeDomain.GetDescription() },
                        new Parameter() { Name = "IntegratorMethod", Text = _IntegratorMethod.GetDescription() },
                        new Parameter() { Name = "FilterMethod", Text = _FilterMethod.GetDescription() },
                        new Parameter() { Name = "SampleTime", Text = _SampleTime },
                        new Parameter() { Name = "UseFilter", Text = _UseFilter ? "on" : "off" },
                        new Parameter() { Name = "SourceBlock", Text = "simulink/Continuous/PID Controller" },
                        new Parameter() { Name = "SourceType", Text = "PID 1dof" },
                        new Parameter() { Name = "Ports", Text = "[1, 1]" },
                        new Parameter() { Name = "LibraryVersion", Text = "1.391" },
                        new Parameter() { Name = "ContentPreviewEnabled", Text = "off" },
                        new Parameter() { Name = "ControllerParametersSource", Text = "internal" },
                        new Parameter() { Name = "InitialConditionSource", Text = "internal" },
                        new Parameter() { Name = "ExternalReset", Text = "none" },
                        new Parameter() { Name = "IgnoreLimit", Text = "off" },
                        new Parameter() { Name = "ZeroCross", Text = "on" },
                        new Parameter() { Name = "LimitOutput", Text = "off" },
                        new Parameter() { Name = "UpperSaturationLimit", Text = "inf" },
                        new Parameter() { Name = "LowerSaturationLimit", Text = "-inf" },
                        new Parameter() { Name = "LinearizeAsGain", Text = "on" },
                        new Parameter() { Name = "AntiWindupMode", Text = "none" },
                        new Parameter() { Name = "Kb", Text = "1" },
                        new Parameter() { Name = "TrackingMode", Text = "off" },
                        new Parameter() { Name = "Kt", Text = "1" },
                        new Parameter() { Name = "RndMeth", Text = "Floor" },
                        new Parameter() { Name = "SaturateOnIntegerOverflow", Text = "off" },
                        new Parameter() { Name = "LockScale", Text = "off" },
                        new Parameter() { Name = "PParamMin", Text = "[]" },
                        new Parameter() { Name = "PParamMax", Text = "[]" },
                        new Parameter() { Name = "PParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "IParamMin", Text = "[]" },
                        new Parameter() { Name = "IParamMax", Text = "[]" },
                        new Parameter() { Name = "IParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "DParamMin", Text = "[]" },
                        new Parameter() { Name = "DParamMax", Text = "[]" },
                        new Parameter() { Name = "DParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "NParamMin", Text = "[]" },
                        new Parameter() { Name = "NParamMax", Text = "[]" },
                        new Parameter() { Name = "NParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "KbParamMin", Text = "[]" },
                        new Parameter() { Name = "KbParamMax", Text = "[]" },
                        new Parameter() { Name = "KbParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "KtParamMin", Text = "[]" },
                        new Parameter() { Name = "KtParamMax", Text = "[]" },
                        new Parameter() { Name = "KtParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "POutMin", Text = "[]" },
                        new Parameter() { Name = "POutMax", Text = "[]" },
                        new Parameter() { Name = "POutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "PGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "PProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "IOutMin", Text = "[]" },
                        new Parameter() { Name = "IOutMax", Text = "[]" },
                        new Parameter() { Name = "IOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "IGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "IProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "DOutMin", Text = "[]" },
                        new Parameter() { Name = "DOutMax", Text = "[]" },
                        new Parameter() { Name = "DOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "DGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "DProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "NOutMin", Text = "[]" },
                        new Parameter() { Name = "NOutMax", Text = "[]" },
                        new Parameter() { Name = "NOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "NGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "NProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "KbOutMin", Text = "[]" },
                        new Parameter() { Name = "KbOutMax", Text = "[]" },
                        new Parameter() { Name = "KbOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "KtOutMin", Text = "[]" },
                        new Parameter() { Name = "KtOutMax", Text = "[]" },
                        new Parameter() { Name = "KtOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "IntegratorOutMin", Text = "[]" },
                        new Parameter() { Name = "IntegratorOutMax", Text = "[]" },
                        new Parameter() { Name = "IntegratorOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "FilterOutMin", Text = "[]" },
                        new Parameter() { Name = "FilterOutMax", Text = "[]" },
                        new Parameter() { Name = "FilterOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumOutMin", Text = "[]" },
                        new Parameter() { Name = "SumOutMax", Text = "[]" },
                        new Parameter() { Name = "SumOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumI1OutMin", Text = "[]" },
                        new Parameter() { Name = "SumI1OutMax", Text = "[]" },
                        new Parameter() { Name = "SumI1OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumI2OutMin", Text = "[]" },
                        new Parameter() { Name = "SumI2OutMax", Text = "[]" },
                        new Parameter() { Name = "SumI2OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumI3OutMin", Text = "[]" },
                        new Parameter() { Name = "SumI3OutMax", Text = "[]" },
                        new Parameter() { Name = "SumI3OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumDOutMin", Text = "[]" },
                        new Parameter() { Name = "SumDOutMax", Text = "[]" },
                        new Parameter() { Name = "SumDOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumAccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumI1AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumI2AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumI3AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SumDAccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "SaturationOutMin", Text = "[]" },
                        new Parameter() { Name = "SaturationOutMax", Text = "[]" },
                        new Parameter() { Name = "SaturationOutDataTypeStr", Text = "Inherit: Same as input" },
                        new Parameter() { Name = "IntegratorStateMustResolveToSignalObject", Text = "off" },
                        new Parameter() { Name = "IntegratorRTWStateStorageClass", Text = "Auto" },
                        new Parameter() { Name = "FilterStateMustResolveToSignalObject", Text = "off" },
                        new Parameter() { Name = "DifferentiatorICPrevScaledInput", Text = "0" },
                        new Parameter() { Name = "DifferentiatorOutMin", Text = "[]" },
                        new Parameter() { Name = "DifferentiatorOutMax", Text = "[]" },
                        new Parameter() { Name = "DifferentiatorOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new Parameter() { Name = "InitialConditionSetting", Text = "State (most efficient)" }
                    }
                }
            });
        }
    }
}
