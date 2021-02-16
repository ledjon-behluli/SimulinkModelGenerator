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
        IConfiguration Done();
    }

    public interface ISolverSimulationTime
    {
        ISolverOptions Set(double startTime = 0.0, double stopTime = 10.0);
        ISolverConfiguration Done();
    }

    public interface ISolverOptions
    {
        IVariableStepSolverOptions WithVariableStep();
        IFixedStepSolverOptions WithFixedStep();
        ISolverConfiguration Done();
    }

    public interface IVariableStepSolverOptions
    {
        IVariableStepSolverOptions WithSolver(VariableSolver solver);
        IVariableStepSolverOptions WithStepSize(double? initialStep = null, double? minStep = null, double? maxStep = null, int numberOfConsecutiveMinSteps = 1);
        IVariableStepSolverOptions WithTolerance(double? relativeTolerance = null, double? absoluteTolerance = null);
        IVariableStepSolverOptions WithShapePreservation(ShapePreservation shape);
        IVariableStepSolverOptions WithZeroCrossingAlgorithm(ZeroCrossingAlgorithm algorithm);
        IVariableStepSolverOptions WithZeroCrossingControl(ZeroCrossingControl control);
        ISolverConfiguration Done();
    }

    public interface IFixedStepSolverOptions
    {
        IFixedStepSolverOptions WithSolver(FixedSolver solver);
        IFixedStepSolverOptions SetStepSize(double? stepSize = null);
        ISolverConfiguration Done();
    }
}
