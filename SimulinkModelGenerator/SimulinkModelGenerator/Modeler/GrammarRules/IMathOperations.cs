using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Common;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{   
    public interface ISystemMathOperation
    {
        ISystemMathOperation AddGain(Action<GainBuilder> action = null);
        ISystemMathOperation AddSum(Action<SumBuilder> action = null);
    }

    public interface IMathOperation : ISystemBlock
    {
        IMathOperation SaturateOnIntegerOverflow();
        IMathOperation DepriveOnIntegerOverflow();
        IMathOperation LockOutputDataType();
        IMathOperation UnlockOutputDataType();
        IMathOperation WithRoundingMode(IntegerRoundingMode mode);
        IMathOperation SetMinimumOutputForRangeChecking(double value);
        IMathOperation SetMaximumOutputForRangeChecking(double value);
    }

    public interface IGain : IMathOperation
    {
        IGain SetGain(double gain);
    }

    public interface IBaseSum : IMathOperation
    {
        IBaseSum WithIconShape(IconShape shape);
        IBaseSum SetInputs(params InputType[] inputs);
    }

    public interface ISum : IBaseSum
    {
      
    }

    public interface IAdd : IBaseSum
    {

    }

    public interface ISubtract : IBaseSum
    {
     
    }


    public interface IAbs : IMathOperation
    {
        IAbs DisableZeroCrossingDetection();
    }

    public interface IProduct : IMathOperation
    {
        IProduct SetNumberOfInputs(int count);
    }

    public interface IDotProduct : IMathOperation
    {

    }

    public interface IDivide : IMathOperation
    {
        IDivide SetNumberOfInputs(int count);
    }

    public interface IMinMax : IMathOperation
    {
        IMinMax DisableZeroCrossingDetection();
        IMinMax SetNumberOfInputs(int count);
    }

    public interface ISign : ISystemBlock
    {
        ISign DisableZeroCrossingDetection();
    }

    public interface ISqrt : IMathOperation
    {
        ISqrt WithOutputSignal(OutputSignalType type);
    }

    public interface ISignedSqrt : IMathOperation
    {
        ISignedSqrt WithOutputSignal(OutputSignalType type);
    }

    public interface IReciprocalSqrt : IMathOperation
    {
        IReciprocalSqrt WithAlgorithm(RootFindingAlgorithm algorithm);
        IReciprocalSqrt SetNumberOfIterations(int count);
    }

    public interface ISliderGain : ISystemBlock
    {
        ISliderGain SetGain(double value);
        ISliderGain IncrementGainBy(double value);
        ISliderGain DecrementGainBy(double value);
        ISliderGain SetLowEnd(double value);
        ISliderGain SetHighEnd(double value);
    }

    public interface ITrigonometricFunction : ISystemBlock
    {
        ITrigonometricFunction WithFunctionType(TrigonometricFunctionType type);
        IWithNoneApproximation WithNoneApproximation();
        IWithCordicApproximation WithCordicApproximation();
    }

    public interface IWithNoneApproximation
    {
        ITrigonometricFunction WithOutputSignalType(OutputSignalType type);
    }

    public interface IWithCordicApproximation
    {
        ITrigonometricFunction SetNumberOfIterations(int count);
    }


    public interface IMathFunction : IMathOperation
    {
        IMathFunction WithFunctionType(MathFunctionType type);
        IMathFunction WithOutputSignalType(OutputSignalType type);
    }
}
