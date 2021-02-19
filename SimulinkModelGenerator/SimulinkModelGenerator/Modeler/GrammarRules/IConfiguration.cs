using System;
using SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IConfiguration
    {
        IConfiguration ConfigureSolver(Action<SolverConfigurationBuilder> action = null);
    }

    public interface ISolverConfiguration
    {
        ISolverConfiguration ConfigureSimulationTime(Action<SimulationTimeBuilder> action = null);
        ISolverConfiguration ConfigureOptions(Action<OptionsBuilder> action = null);
    }

    public interface ISolverSimulationTime
    {
        void Set(double startTime = 0, double stopTime = 10);
    }

    public interface ISolverOptions
    {
        IVariableStepSolverOptions WithVariableStep();
        IFixedStepSolverOptions WithFixedStep();
    }


    public interface IFixedStepSolverOptions
    {
        IIntrapolatedFixedSolverType Auto();
        IIntrapolatedFixedSolverType Discrete();
        IIntrapolatedFixedSolverType Ode8();
        IIntrapolatedFixedSolverType Ode5();
        IIntrapolatedFixedSolverType Ode4();
        IIntrapolatedFixedSolverType Ode3();
        IIntrapolatedFixedSolverType Ode2();
        IIntrapolatedFixedSolverType Ode1();
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
        IExtrapolatedFixedSolverType WithNewtonInterations(int number = 1);
        IExtrapolatedFixedSolverType WithJacobian(Jacobian jacobian = Jacobian.Auto);
        IExtrapolatedFixedSolverType WithOrder(ExtrapolationOrder order = ExtrapolationOrder.Four);
    }

    #endregion

    public interface IVariableStepSolverOptions
    {
        IAutoVariableSolverType Auto();
        IDiscreteVariableSolverType Discrete();
        IOde45VariableSolverType Ode45();
        IOde23VariableSolverType Ode23();
        IOde113VariableSolverType Ode113();
        IOde15sVariableSolverType Ode15s();
        IOde23sVariableSolverType Ode23s();
        IOde23tVariableSolverType Ode23t();
        IOde23tbVariableSolverType Ode23tb();
    }

    #region Variable Solver Types

    public interface IAutoVariableSolverType
    {
        IAutoVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
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
        IOde45VariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
        IOde45VariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde45VariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde45VariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde45VariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
    }

    public interface IOde23VariableSolverType
    {
        IOde23VariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
        IOde23VariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde23VariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde23VariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde23VariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
    }

    public interface IOde113VariableSolverType
    {
        IOde113VariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
        IOde113VariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde113VariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde113VariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde113VariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
    }

    public interface IOde15sVariableSolverType
    {
        IOde15sVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
        IOde15sVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde15sVariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde15sVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde15sVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
        IOde15sVariableSolverType WithJacobian(Jacobian jacobian = Jacobian.Auto);
        IOde15sVariableSolverType WithMaximumOrder(MaximumOrder order = MaximumOrder.Five);
        IOde15sVariableSolverType WithReset(ResetMethod method = ResetMethod.Fast);
    }

    public interface IOde23sVariableSolverType
    {
        IOde23sVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
        IOde23sVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde23sVariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde23sVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde23sVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
        IOde23sVariableSolverType WithJacobian(Jacobian jacobian = Jacobian.Auto);
    }

    public interface IOde23tVariableSolverType
    {
        IOde23sVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
        IOde23sVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde23sVariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde23sVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde23sVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
        IOde23sVariableSolverType WithJacobian(Jacobian jacobian = Jacobian.Auto);
        IOde15sVariableSolverType WithReset(ResetMethod method = ResetMethod.Fast);
    }

    public interface IOde23tbVariableSolverType
    {
        IOde23tbVariableSolverType WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
        IOde23tbVariableSolverType WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IOde23tbVariableSolverType WithShapePreservation(ShapePreservation shape);
        IOde23tbVariableSolverType WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IOde23tbVariableSolverType WithZeroCrossingControl(ZeroCrossingControl control);
        IOde23tbVariableSolverType WithJacobian(Jacobian jacobian = Jacobian.Auto);
        IOde23tbVariableSolverType WithReset(ResetMethod method = ResetMethod.Fast);
    }

    #endregion
}
