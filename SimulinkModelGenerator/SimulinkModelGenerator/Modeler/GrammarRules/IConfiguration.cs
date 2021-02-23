using System;
using SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IConfiguration
    {
        IConfiguration Solver(Action<SolverConfigurationBuilder> action = null);
    }

    public interface ISolverConfiguration
    {
        ISolverConfiguration SetSimulationTimes(double startTime = 0, double stopTime = 10);
        ISolverConfiguration Options(Action<OptionsBuilder> action = null);
    }

    public interface ISolverOptions
    {
        IVariableStepSolverOptions AsVariableStepSolver();
        IFixedStepSolverOptions AsFixedStepSolver();
    }

    #region Fixed Solver

    public interface IFixedStepSolverOptions
    {
        /// <summary>
        /// Automatic solver
        /// </summary>
        IIntrapolatedFixedSolverType Auto();
        /// <summary>
        /// No continous states
        /// </summary>
        IIntrapolatedFixedSolverType Discrete();
        /// <summary>
        /// Dormand-Prince
        /// </summary>
        IIntrapolatedFixedSolverType Ode8();
        /// <summary>
        /// Dormand-Prince
        /// </summary>
        IIntrapolatedFixedSolverType Ode5();
        /// <summary>
        /// Runge-Kutta
        /// </summary>
        IIntrapolatedFixedSolverType Ode4();
        /// <summary>
        /// Bogacki-Shampine
        /// </summary>
        IIntrapolatedFixedSolverType Ode3();
        /// <summary>
        /// Heun
        /// </summary>
        IIntrapolatedFixedSolverType Ode2();
        /// <summary>
        /// Euler
        /// </summary>
        IIntrapolatedFixedSolverType Ode1();
        /// <summary>
        /// Extrapolation
        /// </summary>
        IExtrapolatedFixedSolverType Ode14x();
    }

    #region Fixed Solver Types

    public interface IIntrapolatedFixedSolverType
    {
        void WithSampleTime(double sampleTime = 0.001);
    }

    public interface IExtrapolatedFixedSolverType
    {
        IExtrapolatedFixedSolverType WithSampleTime(double sampleTime = 0.001);
        IExtrapolatedFixedSolverType WithNewtonInterations(int numberOfIterations = 1);
        IExtrapolatedFixedSolverType WithJacobian(Jacobian jacobian);
        IExtrapolatedFixedSolverType WithOrder(ExtrapolationOrder order);
    }

    #endregion

    #endregion

    #region Variable Solver

    public interface IVariableStepSolverOptions
    {
        /// <summary>
        /// Automatic solver
        /// </summary>
        IAutoVariableSolverType Auto();
        /// <summary>
        /// No continous states
        /// </summary>
        IDiscreteVariableSolverType Discrete();
        /// <summary>
        /// Dormand-Prince
        /// </summary>
        IOde45VariableSolverType Ode45();
        /// <summary>
        /// Bogacki-Shampine
        /// </summary>
        IOde23VariableSolverType Ode23();
        /// <summary>
        /// Adams
        /// </summary>
        IOde113VariableSolverType Ode113();
        /// <summary>
        /// stiff/NDF
        /// </summary>
        IOde15sVariableSolverType Ode15s();
        /// <summary>
        /// stiff/Mod. Rosenbrock
        /// </summary>
        IOde23sVariableSolverType Ode23s();
        /// <summary>
        /// mod. stiff/Trapezoidal
        /// </summary>
        IOde23tVariableSolverType Ode23t();
        /// <summary>
        /// stiff/TR-BDF2
        /// </summary>
        IOde23tbVariableSolverType Ode23tb();
    }

    #region Variable Solver Types

    public interface IAutoVariableSolverType
    {
        IAutoVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1);
        IAutoVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IAutoVariableSolverType WithShapePreservation(ShapePreservation shape);
        IAutoVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IAutoVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
    }

    public interface IDiscreteVariableSolverType
    {
        IDiscreteVariableSolverType WithStepSize(double? maxStep = null);
        IDiscreteVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IDiscreteVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
    }

    public interface IOde45VariableSolverType
    {
        IOde45VariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1);
        IOde45VariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde45VariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde45VariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde45VariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
    }

    public interface IOde23VariableSolverType
    {
        IOde23VariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1);
        IOde23VariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde23VariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde23VariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde23VariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
    }

    public interface IOde113VariableSolverType
    {
        IOde113VariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1);
        IOde113VariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde113VariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde113VariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde113VariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
    }

    public interface IOde15sVariableSolverType
    {
        IOde15sVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1);
        IOde15sVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde15sVariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde15sVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde15sVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
        IOde15sVariableSolverType WithJacobian(Jacobian jacobian);
        IOde15sVariableSolverType WithOrder(MaximumOrder order);
        IOde15sVariableSolverType WithReset(ResetMethod method);
    }

    public interface IOde23sVariableSolverType
    {
        IOde23sVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1);
        IOde23sVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde23sVariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde23sVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde23sVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
        IOde23sVariableSolverType WithJacobian(Jacobian jacobian);
    }

    public interface IOde23tVariableSolverType
    {
        IOde23tVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1);
        IOde23tVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde23tVariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde23tVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde23tVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
        IOde23tVariableSolverType WithJacobian(Jacobian jacobian);
        IOde23tVariableSolverType WithReset(ResetMethod method);
    }

    public interface IOde23tbVariableSolverType
    {
        IOde23tbVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int? numberOfConsecutiveMinSteps = 1);
        IOde23tbVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde23tbVariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde23tbVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde23tbVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
        IOde23tbVariableSolverType WithJacobian(Jacobian jacobian);
        IOde23tbVariableSolverType WithReset(ResetMethod method);
    }

    #endregion

    #endregion
}
