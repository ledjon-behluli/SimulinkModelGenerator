using SimulinkModelGenerator.Extensions;
using System.ComponentModel;

namespace SimulinkModelGenerator.Models
{
    public class ConfigSet
    {
        public Solver Solver { get; internal set; }
    }

    #region Solver

    #region Enums

    public enum VariableSolver
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
    public enum FixedSolver
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
                MaxStepSize = "auto",
                MinStepSize = "auto",
                InitialStepSize = "auto",
                FixedStepSize = "auto",
                NumberOfConsecutiveMinSteps = 1,
                RelativeTolerance = "1e-3",
                AbsoluteToterance = "auto",
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
        public string MaxStepSize { get; internal set; }
        public string MinStepSize { get; internal set; }
        public string InitialStepSize { get; internal set; }
        public string FixedStepSize { get; set; }
        public int NumberOfConsecutiveMinSteps { get; internal set; }
        public string RelativeTolerance { get; internal set; }
        public string AbsoluteToterance { get; internal set; }
        public string ShapePreservation { get; internal set; }
        public string ZeroCrossingAlgorithm { get; internal set; }
        public string ZeroCrossingControl { get; internal set; }
    }

    #endregion
}
