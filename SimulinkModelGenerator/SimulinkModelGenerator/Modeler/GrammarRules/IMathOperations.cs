using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{   
    public interface ISystemMathOperation
    {
        ISystemMathOperation AddSum(Action<ISum> action = null);
        ISystemMathOperation AddAbs(Action<IAbs> action = null);
        ISystemMathOperation AddAddition(Action<IAdd> action = null);
        ISystemMathOperation AddSubtraction(Action<ISubtract> action = null);
        ISystemMathOperation AddDivision(Action<IDivide> action = null);
        ISystemMathOperation AddProduct(Action<IProduct> action = null);
        ISystemMathOperation AddDotProduct(Action<IDotProduct> action = null);
        ISystemMathOperation AddMathFunction(Action<IMathFunction> action = null);
        ISystemMathOperation AddMin(Action<IMin> action = null);
        ISystemMathOperation AddMax(Action<IMax> action = null);
        ISystemMathOperation AddSign(Action<ISign> action = null);
        ISystemMathOperation AddGain(Action<IGain> action = null);
        ISystemMathOperation AddSliderGain(Action<ISliderGain> action = null);
        ISystemMathOperation AddSquareRoot(Action<ISqrt> action = null);
        ISystemMathOperation AddSignedSquareRoot(Action<ISignedSqrt> action = null);
        ISystemMathOperation AddReciprocalSquareRoot(Action<IReciprocalSqrt> action = null);
        ISystemMathOperation AddTrigonometricFunction(Action<ITrigonometricFunction> action = null);
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

    public interface IMin : IMinMax
    {

    }

    public interface IMax : IMinMax
    {

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
