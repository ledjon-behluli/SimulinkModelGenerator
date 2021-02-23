using SimulinkModelGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimulinkModelGenerator.Models
{
    public class ConfigSet
    {
        public Solver Solver { get; internal set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Solver.ToString());

            return sb.ToString();
        }
    }

    #region Solver

    public class Solver
    {
        internal List<Parameter> Parameters =>
            new List<Parameter>()
            {
                new Parameter() { Name = "StartTime", Text = SimulationTime.StartTime.ToString() },
                new Parameter() { Name = "StopTime", Text = SimulationTime.StopTime.ToString() },
                new Parameter() { Name = "Solver", Text = SolverOptions.Solver },
                new Parameter() { Name = "SolverName", Text = SolverOptions.SolverName },
                new Parameter() { Name = "MaxStep", Text = AdditionalSolverOptions.MaxStep == null ? "auto" : AdditionalSolverOptions.MaxStep.ToString() },
                new Parameter() { Name = "MinStep", Text = AdditionalSolverOptions.MinStep == null ? "auto" : AdditionalSolverOptions.MinStep.ToString() },
                new Parameter() { Name = "InitialStep", Text = AdditionalSolverOptions.InitialStep == null ? "auto" : AdditionalSolverOptions.InitialStep.ToString() },
                new Parameter() { Name = "FixedStep", Text = AdditionalSolverOptions.FixedStep == null ? "auto" : AdditionalSolverOptions.FixedStep.ToString() },
                new Parameter() { Name = "MaxConsecutiveMinStep", Text = AdditionalSolverOptions.MaxConsecutiveMinStep == null ? "auto" : AdditionalSolverOptions.MaxConsecutiveMinStep.ToString() },
                new Parameter() { Name = "RelTol", Text = AdditionalSolverOptions.RelativeTolerance == null ? "auto" : AdditionalSolverOptions.RelativeTolerance.ToString() },
                new Parameter() { Name = "AbsTol", Text = AdditionalSolverOptions.AbsoluteToterance == null ? "auto" : AdditionalSolverOptions.AbsoluteToterance.ToString() },
                new Parameter() { Name = "NumberNewtonIterations", Text = AdditionalSolverOptions.NumberNewtonIterations.ToString() },
                new Parameter() { Name = "SolverResetMethod", Text = AdditionalSolverOptions.SolverResetMethod.GetDescription() },
                new Parameter() { Name = "SolverJacobianMethodControl", Text = AdditionalSolverOptions.SolverJacobianMethodControl.GetDescription() },
                new Parameter() { Name = "MaxOrder", Text = AdditionalSolverOptions.MaxOrder.GetDescription() },
                new Parameter() { Name = "ExtrapolationOrder", Text = AdditionalSolverOptions.ExtrapolationOrder.GetDescription() },
                new Parameter() { Name = "ShapePreservation", Text = AdditionalSolverOptions.ShapePreservation.GetDescription() },
                new Parameter() { Name = "ZeroCrossingAlgorithm", Text = AdditionalSolverOptions.ZeroCrossingAlgorithm.GetDescription() },
                new Parameter() { Name = "ZeroCrossingControl", Text = AdditionalSolverOptions.ZeroCrossingControl.GetDescription() }
            };

        internal static Solver Default => new Solver()
        {
            SimulationTime = new SimulationTime()
            {
                StartTime = 0,
                StopTime = 10
            },
            SolverOptions = new SolverOptions()
            {
                Solver = VariableSolver.Auto.GetDescription(),
                SolverName = VariableSolver.Auto.GetDescription()
            },
            AdditionalSolverOptions = new AdditionalSolverOptions()
            {
                MaxStep = null,
                MinStep = null,
                InitialStep = null,
                FixedStep = null,
                MaxConsecutiveMinStep = 1,
                RelativeTolerance = 0.001,
                AbsoluteToterance = null,
                NumberNewtonIterations = 1,
                SolverResetMethod = ResetMethod.Fast,
                SolverJacobianMethodControl = Jacobian.FullPerturbation,
                MaxOrder = MaximumOrder.Five,
                ExtrapolationOrder = ExtrapolationOrder.Four,
                ShapePreservation = ShapePreservation.DisableAll,
                ZeroCrossingAlgorithm = ZeroCrossingAlgorithm.Nonadaptive,
                ZeroCrossingControl = ZeroCrossingControl.UseLocalSettings
            }
        };

        internal SimulationTime SimulationTime { get; set; }
        internal SolverOptions SolverOptions { get; set; }
        internal AdditionalSolverOptions AdditionalSolverOptions { get; set; }

        public override string ToString()
        {
            string properties = string.Empty;
            foreach (Parameter p in Parameters)
            {
                properties += $"\t\t\t\t\t{p.ToString() + Environment.NewLine}";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("\t\tSimulink.ConfigSet {");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t\tArray {");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t\t\tSimulink.SolverCC {");
            sb.Append(Environment.NewLine);
            sb.Append(properties);
            sb.Append("\t\t\t\t}");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t\t}");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t}");

            return sb.ToString();
        }
    }

    internal class SimulationTime
    {
        public double StartTime { get; internal set; }
        public double StopTime { get; internal set; }
    }

    internal class SolverOptions
    {
        public string Solver { get; internal set; }
        public string SolverName { get; internal set; }
    }

    internal class AdditionalSolverOptions
    {
        public double? MaxStep { get; internal set; }
        public double? MinStep { get; internal set; }
        public double? InitialStep { get; internal set; }
        public double? FixedStep { get; internal set; }
        public int? MaxConsecutiveMinStep { get; internal set; }
        public double? RelativeTolerance { get; internal set; }
        public double? AbsoluteToterance { get; internal set; }
        public ShapePreservation ShapePreservation { get; internal set; }
        public ZeroCrossingAlgorithm ZeroCrossingAlgorithm { get; internal set; }
        public ZeroCrossingControl ZeroCrossingControl { get; internal set; }
        public int NumberNewtonIterations { get; internal set; }
        public MaximumOrder MaxOrder { get; internal set; }
        public ResetMethod SolverResetMethod { get; internal set; }
        public Jacobian SolverJacobianMethodControl { get; internal set; }
        public ExtrapolationOrder ExtrapolationOrder { get; internal set; }

        #region Methods

        internal void SetSampleTime(double sampleTime)
        {
            if (sampleTime <= 0)
                throw new ArgumentException("Fundamental sample time can not be less than or equal to 0");

            FixedStep = sampleTime;
        }

        internal void SetStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1)
        {
            InitialStep = initialStep;
            MinStep = minStep;
            MaxStep = maxStep;
            MaxConsecutiveMinStep = numberOfConsecutiveMinSteps;
        }

        internal void SetTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            RelativeTolerance = relativeTolerance;
            AbsoluteToterance = absoluteTolerance;
        }

        internal void SetNewtonInterations(int number) => NumberNewtonIterations = number;

        #endregion
    }

    #endregion
}

namespace SimulinkModelGenerator
{
    internal enum VariableSolver
    {
        [Description("VariableStepAuto")]
        Auto,
        [Description("VariableStepDiscrete")]
        Discrete,
        [Description("ode45")]
        Ode45,
        [Description("ode23")]
        Ode23,
        [Description("ode113")]
        Ode113,
        [Description("ode15s")]
        Ode15s,
        [Description("ode23s")]
        Ode23s,
        [Description("ode23t")]
        Ode23t,
        [Description("ode23tb")]
        Ode23tb
    }
    internal enum FixedSolver
    {
        [Description("FixedStepAuto")]
        Auto,
        [Description("FixedStepDiscrete")]
        Discrete,
        [Description("ode8")]
        Ode8,
        [Description("ode5")]
        Ode5,
        [Description("ode4")]
        Ode4,
        [Description("ode3")]
        Ode3,
        [Description("ode2")]
        Ode2,
        [Description("ode1")]
        Ode1,
        [Description("ode14x")]
        Ode14x
    }

    public enum ShapePreservation
    {
        [Description("EnableAll")]
        EnableAll,
        [Description("DisableAll")]
        DisableAll
    }
    public enum ZeroCrossingAlgorithm
    {
        [Description("Adaptive")]
        Adaptive,
        [Description("Nonadaptive")]
        Nonadaptive
    }
    public enum ZeroCrossingControl
    {
        [Description("UseLocalSettings")]
        UseLocalSettings,
        [Description("EnableAll")]
        EnableAll,
        [Description("DisableAll")]
        DisableAll
    }
    public enum Jacobian
    {
        [Description("auto")]
        Auto,
        [Description("SparsePerturbation")]
        SparsePerturbation,
        [Description("FullPerturbation")]
        FullPerturbation,
        [Description("SparseAnalytical")]
        SparseAnalytical,
        [Description("FullAnalytical")]
        FullAnalytical
    }
    public enum ExtrapolationOrder
    {
        [Description("1")]
        One,
        [Description("2")]
        Two,
        [Description("3")]
        Three,
        [Description("4")]
        Four
    }
    public enum MaximumOrder
    {
        [Description("1")]
        One,
        [Description("2")]
        Two,
        [Description("3")]
        Three,
        [Description("4")]
        Four,
        [Description("5")]
        Five
    }
    public enum ResetMethod
    {
        [Description("Fast")]
        Fast,
        [Description("Robust")]
        Robust
    }
}