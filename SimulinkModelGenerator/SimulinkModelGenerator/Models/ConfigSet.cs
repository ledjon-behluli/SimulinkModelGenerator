using SimulinkModelGenerator.Extensions;
using System;
using System.ComponentModel;

namespace SimulinkModelGenerator.Models
{
    public class ConfigSet
    {
        public Solver Solver { get; internal set; }
    }

    #region Solver

    #region Enums

    internal enum VariableSolver
    {
        /// <summary>
        /// Automatic solver
        /// </summary>
        [Description("VariableStepAuto")]
        Auto,
        /// <summary>
        /// No continous states
        /// </summary>
        [Description("VariableStepDiscrete")]
        Discrete,
        /// <summary>
        /// Dormand-Prince
        /// </summary>
        [Description("ode45")]
        Ode45,
        /// <summary>
        /// Bogacki-Shampine
        /// </summary>
        [Description("ode23")]
        Ode23,
        /// <summary>
        /// Adams
        /// </summary>
        [Description("ode113")]
        Ode113,
        /// <summary>
        /// stiff/NDF
        /// </summary>
        [Description("ode15s")]
        Ode15s,
        /// <summary>
        /// stiff/Mod. Rosenbrock
        /// </summary>
        [Description("ode23s")]
        Ode23s,
        /// <summary>
        /// mod. stiff/Trapezoidal
        /// </summary>
        [Description("ode23t")]
        Ode23t,
        /// <summary>
        /// stiff/TR-BDF2
        /// </summary>
        [Description("ode23tb")]
        Ode23tb
    }
    internal enum FixedSolver
    {
        /// <summary>
        /// Automatic solver
        /// </summary>
        [Description("FixedStepAuto")]
        Auto,
        /// <summary>
        /// No continous states
        /// </summary>
        [Description("FixedStepDiscrete")]
        Discrete,
        /// <summary>
        /// Dormand-Prince
        /// </summary>
        [Description("ode8")]
        Ode8,
        /// <summary>
        /// Dormand-Prince
        /// </summary>
        [Description("ode5")]
        Ode5,
        /// <summary>
        /// Runge-Kutta
        /// </summary>
        [Description("ode4")]
        Ode4,
        /// <summary>
        /// Bogacki-Shampine
        /// </summary>
        [Description("ode3")]
        Ode3,
        /// <summary>
        /// Heun
        /// </summary>
        [Description("ode2")]
        Ode2,
        /// <summary>
        /// Euler
        /// </summary>
        [Description("ode1")]
        Ode1,
        /// <summary>
        /// Extrapolation
        /// </summary>
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

    #endregion

    public class Solver
    {
        internal static Solver Default => new Solver()
        {
            SimulationTime = new SimulationTime()
            {
                StartTime = "0.0",
                StopTime = "10.0"
            },
            SolverOptions = new SolverOptions()
            {
                Solver = VariableSolver.Auto.GetDescription(),
                SolverName = VariableSolver.Auto.GetDescription()
            },
            AdditionalSolverOptions = new AdditionalSolverOptions()
            {
                MaxStep = "auto",
                MinStep = "auto",
                InitialStep = "auto",
                FixedStep = "auto",
                MaxConsecutiveMinStep = "1",
                RelativeTolerance = "1e-3",
                AbsoluteToterance = "auto",
                NumberNewtonIterations = "1",
                SolverResetMethod = ResetMethod.Fast.GetDescription(),
                SolverJacobianMethodControl = Jacobian.FullPerturbation.GetDescription(),
                MaxOrder = MaximumOrder.Five.GetDescription(),
                ExtrapolationOrder = ExtrapolationOrder.Four.GetDescription(),
                ShapePreservation = ShapePreservation.DisableAll.GetDescription(),
                ZeroCrossingAlgorithm = ZeroCrossingAlgorithm.Nonadaptive.GetDescription(),
                ZeroCrossingControl = ZeroCrossingControl.UseLocalSettings.GetDescription()
            }
        };

        public SimulationTime SimulationTime { get; internal set; }
        public SolverOptions SolverOptions { get; internal set; }
        public AdditionalSolverOptions AdditionalSolverOptions { get; internal set; }
    }

    public class SimulationTime
    {
        public string StartTime { get; internal set; }
        public string StopTime { get; internal set; }
    }

    public class SolverOptions
    {
        public string Solver { get; internal set; }
        public string SolverName { get; internal set; }
    }

    public class AdditionalSolverOptions
    {
        public string MaxStep { get; internal set; }
        public string MinStep { get; internal set; }
        public string InitialStep { get; internal set; }
        public string FixedStep { get; internal set; }
        public string MaxConsecutiveMinStep { get; internal set; }
        public string RelativeTolerance { get; internal set; }
        public string AbsoluteToterance { get; internal set; }
        public string ShapePreservation { get; internal set; }
        public string ZeroCrossingAlgorithm { get; internal set; }
        public string ZeroCrossingControl { get; internal set; }
        public string NumberNewtonIterations { get; internal set; }
        public string MaxOrder { get; internal set; }
        public string SolverResetMethod { get; internal set; }
        public string SolverJacobianMethodControl { get; internal set; }
        public string ExtrapolationOrder { get; internal set; }

        #region Methods

        internal void SetSampleTime(double sampleTime)
        {
            if (sampleTime <= 0)
                throw new ArgumentException("Fundamental sample time can not be less than or equal to 0");

            FixedStep = sampleTime.ToString();
        }

        internal void SetStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1)
        {
            InitialStep = initialStep == null ? "auto" : initialStep.ToString();
            MinStep = minStep == null ? "auto" : minStep.ToString();
            MaxStep = maxStep == null ? "auto" : maxStep.ToString();
            MaxConsecutiveMinStep = numberOfConsecutiveMinSteps.ToString();
        }

        internal void SetTolerance(double? relativeTolerance = null, double? absoluteTolerance = null)
        {
            RelativeTolerance = relativeTolerance == null ? "auto" : relativeTolerance.ToString();
            AbsoluteToterance = absoluteTolerance == null ? "auto" : absoluteTolerance.ToString();
        }

        internal void SetShapePreservation(ShapePreservation shape) => ShapePreservation = shape.GetDescription();

        internal void SetJacobian(Jacobian jacobian) => SolverJacobianMethodControl = jacobian.GetDescription();

        internal void SetNewtonInterations(int number) => NumberNewtonIterations = number.ToString();

        internal void SetExtrapolationOrder(ExtrapolationOrder order) => ExtrapolationOrder = order.GetDescription();

        internal void SetMaximumOrder(MaximumOrder order) => MaxOrder = order.GetDescription();

        internal void SetResetMethod(ResetMethod method) => SolverResetMethod = method.GetDescription();

        internal void SetZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm) => ZeroCrossingAlgorithm = algorithm.GetDescription();

        internal void SetZeroCrossingControl(ZeroCrossingControl control) => ZeroCrossingControl = control.GetDescription();

        #endregion
    }

    #endregion
}
