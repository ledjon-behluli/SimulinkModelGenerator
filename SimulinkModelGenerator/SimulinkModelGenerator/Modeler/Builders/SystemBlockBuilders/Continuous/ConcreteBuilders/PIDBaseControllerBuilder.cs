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
                Name = base.GetName("PID Controller"),
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "BlockMirror", Text = base.BlockMirror }
                },
                InstanceData = new InstanceData()
                {
                    P = new List<P>()
                    {
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
                        new P() { Name = "SourceBlock", Text = "simulink/Continuous/PID Controller" },
                        new P() { Name = "SourceType", Text = "PID 1dof" }
                    }
                }
            });
        }
    }
}
