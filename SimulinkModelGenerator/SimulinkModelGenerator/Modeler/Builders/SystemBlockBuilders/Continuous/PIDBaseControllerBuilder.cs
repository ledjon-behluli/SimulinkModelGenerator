using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
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
        where T : PIDBaseControllerBuilder<T>, IPIDBaseController
    {
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


        public PIDBaseControllerBuilder(ModelInformation modelInformation)
            : base(modelInformation)
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
            if (_TimeDomain == TimeDomain.ContinuousTime)
                throw new SimulinkModelGeneratorException("SampleTime can only be set when TimeDomain is of type Discrete-time");

            if (sampleTime < 0 && sampleTime != -1)                
                throw new SimulinkModelGeneratorException("SampleTime can not be negative, besides -1 for inherited types");

            _SampleTime = sampleTime.ToString();

            return this;
        }


        internal override void Build()
        {
            base.modelInformation.Model.System.Block.Add(new Block()
            {
                BlockType = "Reference",
                Name = base.GetName("PID Controller"),
                SID = base._SID,
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "ZOrder", Text = base._ZOrder },
                    new P() { Name = "Ports", Text = "[1, 1]" },
                    new P() { Name = "LibraryVersion", Text = "1.391" },
                    new P() { Name = "SourceBlock", Text = "simulink/Continuous/PID Controller" },
                    new P() { Name = "SourceType", Text = "PID 1dof" },
                    new P() { Name = "SourceProductName", Text = "Simulink" },
                    new P() { Name = "SourceProductBaseCode", Text = "SL" }
                },
                InstanceData = new InstanceData()
                {
                    P = new List<P>()
                    {
                        // Customizable
                        new P() { Name = "Controller", Text = _ControllerType },
                        new P() { Name = "P", Text = _Proportional },
                        new P() { Name = "I", Text = _Integral },
                        new P() { Name = "D", Text = _Derivative },
                        new P() { Name = "N", Text = _FilterCoefficient },
                        new P() { Name = "InitialConditionForIntegrator", Text = _InitialConditionForIntegrator },
                        new P() { Name = "InitialConditionForFilter", Text = _InitialConditionForFilter },
                        new P() { Name = "Form", Text = _Form.GetDescription() },
                        new P() { Name = "TimeDomain", Text = _TimeDomain.GetDescription() },
                        new P() { Name = "IntegratorMethod", Text = _IntegratorMethod.GetDescription() },
                        new P() { Name = "FilterMethod", Text = _FilterMethod.GetDescription() },
                        new P() { Name = "SampleTime", Text = _SampleTime },
                        new P() { Name = "UseFilter", Text = _UseFilter ? "on" : "off" },
                        // Default
                        new P() { Name = "ContentPreviewEnabled", Text = "off" },     
                        new P() { Name = "ControllerParametersSource", Text = "internal" },
                        new P() { Name = "InitialConditionSource", Text = "internal" },
                        new P() { Name = "ExternalReset", Text = "none" },
                        new P() { Name = "IgnoreLimit", Text = "off" },
                        new P() { Name = "ZeroCross", Text = "on" },
                        new P() { Name = "LimitOutput", Text = "off" },
                        new P() { Name = "UpperSaturationLimit", Text = "inf" },
                        new P() { Name = "LowerSaturationLimit", Text = "-inf" },
                        new P() { Name = "LinearizeAsGain", Text = "on" },
                        new P() { Name = "AntiWindupMode", Text = "none" },
                        new P() { Name = "Kb", Text = "1" },
                        new P() { Name = "TrackingMode", Text = "off" },
                        new P() { Name = "Kt", Text = "1" },
                        new P() { Name = "RndMeth", Text = "Floor" },
                        new P() { Name = "SaturateOnIntegerOverflow", Text = "off" },
                        new P() { Name = "LockScale", Text = "off" },
                        new P() { Name = "PParamMin", Text = "[]" },
                        new P() { Name = "PParamMax", Text = "[]" },
                        new P() { Name = "PParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "IParamMin", Text = "[]" },
                        new P() { Name = "IParamMax", Text = "[]" },
                        new P() { Name = "IParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "DParamMin", Text = "[]" },
                        new P() { Name = "DParamMax", Text = "[]" },
                        new P() { Name = "DParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "NParamMin", Text = "[]" },
                        new P() { Name = "NParamMax", Text = "[]" },
                        new P() { Name = "NParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "KbParamMin", Text = "[]" },
                        new P() { Name = "KbParamMax", Text = "[]" },
                        new P() { Name = "KbParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "KtParamMin", Text = "[]" },
                        new P() { Name = "KtParamMax", Text = "[]" },
                        new P() { Name = "KtParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "POutMin", Text = "[]" },
                        new P() { Name = "POutMax", Text = "[]" },
                        new P() { Name = "POutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "PGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "PProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "IOutMin", Text = "[]" },
                        new P() { Name = "IOutMax", Text = "[]" },
                        new P() { Name = "IOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "IGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "IProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "DOutMin", Text = "[]" },
                        new P() { Name = "DOutMax", Text = "[]" },
                        new P() { Name = "DOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "DGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "DProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "NOutMin", Text = "[]" },
                        new P() { Name = "NOutMax", Text = "[]" },
                        new P() { Name = "NOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "NGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "NProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "KbOutMin", Text = "[]" },
                        new P() { Name = "KbOutMax", Text = "[]" },
                        new P() { Name = "KbOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "KtOutMin", Text = "[]" },
                        new P() { Name = "KtOutMax", Text = "[]" },
                        new P() { Name = "KtOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "IntegratorOutMin", Text = "[]" },
                        new P() { Name = "IntegratorOutMax", Text = "[]" },
                        new P() { Name = "IntegratorOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "FilterOutMin", Text = "[]" },
                        new P() { Name = "FilterOutMax", Text = "[]" },
                        new P() { Name = "FilterOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "SumOutMin", Text = "[]" },
                        new P() { Name = "SumOutMax", Text = "[]" },
                        new P() { Name = "SumOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "SumI1OutMin", Text = "[]" },
                        new P() { Name = "SumI1OutMax", Text = "[]" },
                        new P() { Name = "SumI1OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "SumI2OutMin", Text = "[]" },
                        new P() { Name = "SumI2OutMax", Text = "[]" },
                        new P() { Name = "SumI2OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "SumI3OutMin", Text = "[]" },
                        new P() { Name = "SumI3OutMax", Text = "[]" },
                        new P() { Name = "SumI3OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },                        
                        new P() { Name = "SumDOutMin", Text = "[]" },
                        new P() { Name = "SumDOutMax", Text = "[]" },
                        new P() { Name = "SumDOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },                        
                        new P() { Name = "SumAccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "SumI1AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "SumI2AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "SumI3AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "SumDAccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },                        
                        new P() { Name = "SaturationOutMin", Text = "[]" },
                        new P() { Name = "SaturationOutMax", Text = "[]" },
                        new P() { Name = "SaturationOutDataTypeStr", Text = "Inherit: Same as input" },
                        new P() { Name = "IntegratorContinuousStateAttributes", Text = "&apos;&apos;" },
                        new P() { Name = "IntegratorStateMustResolveToSignalObject", Text = "off" },
                        new P() { Name = "IntegratorRTWStateStorageClass", Text = "Auto" },
                        new P() { Name = "FilterContinuousStateAttributes", Text = "&apos;&apos;" },
                        new P() { Name = "FilterStateMustResolveToSignalObject", Text = "off" },
                        new P() { Name = "DifferentiatorICPrevScaledInput", Text = "0" },
                        new P() { Name = "DifferentiatorOutMin", Text = "[]" },
                        new P() { Name = "DifferentiatorOutMax", Text = "[]" },
                        new P() { Name = "DifferentiatorOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                        new P() { Name = "InitialConditionSetting", Text = "State (most efficient)" }                        
                    }
                }
            });
        }
    }
}
