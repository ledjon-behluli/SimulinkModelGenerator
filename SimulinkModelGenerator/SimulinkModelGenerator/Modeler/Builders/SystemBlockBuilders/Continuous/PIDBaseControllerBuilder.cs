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
                        new P() { Name = "", Text = "" },
                        new P() { Name = "", Text = "" }
                    }
                }
            });
        }
    }
}
