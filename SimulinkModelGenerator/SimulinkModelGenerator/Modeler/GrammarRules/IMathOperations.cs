using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{   
    public interface ISystemMathOperation
    {
        ISystemMathOperation AddSum(Action<SumBuilder> action = null);
        ISystemMathOperation AddAbs(Action<AbsBuilder> action = null);
        ISystemMathOperation AddAddition(Action<AddBuilder> action = null);
        ISystemMathOperation AddSubtraction(Action<SubtractBuilder> action = null);
        ISystemMathOperation AddDivision(Action<DivideBuilder> action = null);
        ISystemMathOperation AddProduct(Action<ProductBuilder> action = null);
        ISystemMathOperation AddDotProduct(Action<DotProductBuilder> action = null);
        ISystemMathOperation AddMathFunction(Action<MathFunctionBuilder> action = null);
        ISystemMathOperation AddMin(Action<MinBuilder> action = null);
        ISystemMathOperation AddMax(Action<MaxBuilder> action = null);
        ISystemMathOperation AddSign(Action<SignBuilder> action = null);
        ISystemMathOperation AddGain(Action<GainBuilder> action = null);
        ISystemMathOperation AddSliderGain(Action<SliderGainBuilder> action = null);
        ISystemMathOperation AddSquareRoot(Action<SquareRootBuilder> action = null);
        ISystemMathOperation AddSignedSquareRoot(Action<SignedSquareRootBuilder> action = null);
        ISystemMathOperation AddReciprocalSquareRoot(Action<ReciprocalSquareRootBuilder> action = null);
        ISystemMathOperation AddTrigonometricFunction(Action<TrigonometricFunctionBuilder> action = null);
    }

    public interface IMathOperation : ISystemBlock
    {
        IMathOperation SaturateOnIntegerOverflow();
        IMathOperation DepriveOnIntegerOverflow();
        IMathOperation LockOutputDataType();
        IMathOperation UnlockOutputDataType();
        IMathOperation WithRoundingMode(IntegerRoundingMode mode);
        IMathOperation WithOutputRangeChecking(double? outMin = null, double? outMax = null);
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
        ISliderGain SetGainLimits(double lowEnd = -1, double highEnd = 1);
        ISliderGain SetGain(double value);
        ISliderGain IncrementGainBy(double value);
        ISliderGain DecrementGainBy(double value);
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
