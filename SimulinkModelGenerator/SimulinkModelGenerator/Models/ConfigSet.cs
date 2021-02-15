using SimulinkModelGenerator.Extensions;
using System.ComponentModel;

namespace SimulinkModelGenerator.Models
{
    public class ConfigSet
    {
        public Solver _Solver { get; internal set; }

        #region Solver

        public class Solver
        {
            internal static Solver Default => new Solver()
            {
                _SimulationTime = new SimulationTime()
                {
                    StartTime = "0.0",
                    StopTime = "10.0"
                },
                _SolverOptions = new SolverOptions()
                {
                    SoverName = "VariableStepAuto",
                    StepType = SolverOptions.SolverStepType.VariableStep.GetDescription()
                },
                _AdditionalOptions = new AdditionalOptions()
                {
                    MaxStepSize = "auto",
                    MinStepSize = "auto",
                    InitialStepSize = "auto",
                    RelativeTolerance = "1e-3",
                    AbsoluteToterance = "auto",
                    Preservation = AdditionalOptions.ShapePreservation.DisableAll.GetDescription(),
                    NumberOfConsecutiveMinSteps = 1,
                    _ZeroCrossingOptions = new AdditionalOptions.ZeroCrossingOptions()
                    {
                        Algorithm = AdditionalOptions.ZeroCrossingOptions.ZeroCrossingAlgorithm.Nonadaptive.GetDescription()
                    }
                }
            };

            public SimulationTime _SimulationTime { get; set; }
            public SolverOptions _SolverOptions { get; set; }
            public AdditionalOptions _AdditionalOptions { get; set; }

            public class SimulationTime
            {
                public string StartTime { get; set; }
                public string StopTime { get; set; }
            }

            public class SolverOptions
            {
                public enum SolverStepType
                {
                    [Description("variable")]
                    VariableStep,
                    [Description("fixed")]
                    FixedStep
                }

                public enum SolverType
                {
                    /// <summary>
                    /// Automatic solver
                    /// </summary>
                    [Description("")]
                    Auto,
                    /// <summary>
                    /// No continous states
                    /// </summary>
                    [Description("")]
                    Discrete,
                    /// <summary>
                    /// Dormand-Prince
                    /// </summary>
                    [Description("")]
                    Ode45,
                    /// <summary>
                    /// Bogacki-Shampine
                    /// </summary>
                    [Description("")]
                    Ode23,
                    /// <summary>
                    /// Adams
                    /// </summary>
                    [Description("")]
                    Ode113,
                    /// <summary>
                    /// stiff/NDF
                    /// </summary>
                    [Description("")]
                    Ode15s,
                    /// <summary>
                    /// stiff/Mod. Rosenbrock
                    /// </summary>
                    [Description("")]
                    Ode23s,
                    /// <summary>
                    /// mod. stiff/Trapezoidal
                    /// </summary>
                    [Description("")]
                    Ode23t,
                    /// <summary>
                    /// stiff/TR-BDF2
                    /// </summary>
                    [Description("")]
                    Ode23tb
                }

                public string SoverName { get; set; }
                public string StepType { get; set; }
            }

            public class AdditionalOptions
            {
                public enum ShapePreservation
                {
                    [Description("EnableAll")]
                    EnableAll,
                    [Description("DisableAll")]
                    DisableAll
                }

                public string MaxStepSize { get; set; }
                public string MinStepSize { get; set; }
                public string InitialStepSize { get; set; }
                public string RelativeTolerance { get; set; }
                public string AbsoluteToterance { get; set; }
                public string Preservation { get; set; }
                public int NumberOfConsecutiveMinSteps { get; set; }
                public ZeroCrossingOptions _ZeroCrossingOptions { get; set; }

                public class ZeroCrossingOptions
                {
                    public enum ZeroCrossingAlgorithm
                    {
                        [Description("Adaptive")]
                        Adaptive,
                        [Description("Nonadaptive")]
                        Nonadaptive
                    }

                    public string Algorithm { get; set; }
                }
            }
        }

        #endregion
    }
}
