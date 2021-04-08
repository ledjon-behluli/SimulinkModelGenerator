using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemContinuous
    {
        ISystemContinuous AddIntegrator(Action<IIntegrator> action = null);
        ISystemContinuous AddLimitedIntegrator(Action<ILimitedIntegrator> action = null);
        ISystemContinuous AddTransferFunction(Action<ITransferFunction> action = null);
        ISystemContinuous AddZeroPole(Action<IZeroPole> action = null);
        ISystemContinuous AddDerivative(Action<IDerivative> action = null);
        ISystemContinuous AddStateSpace(Action<IStateSpace> action = null);
        ISystemContinuous AddTransportDelay(Action<ITransportDelay> action = null);
        ISystemContinuous AddPIDController(Action<IPIDController> action = null);
        ISystemContinuous AddPDController(Action<IPDController> action = null);
        ISystemContinuous AddPIController(Action<IPIController> action = null);
        ISystemContinuous AddIController(Action<IIController> action = null);
        ISystemContinuous AddPController(Action<IPController> action = null);
        ISystemContinuous Add2DofPIDController(Action<ITwoDofPIDController> action = null);
        ISystemContinuous Add2DofPDController(Action<ITwoDofPDController> action = null);
        ISystemContinuous Add2DofPIController(Action<ITwoDofPIController> action = null);
    }

    #region Uncategorized

    public interface IDerivative : ISystemBlock
    {
        IDerivative SetCoefficient(double coefficient);
        IDerivative WithPositiveInfiniteCoefficient();
        IDerivative WithNegativeInfiniteCoefficient();
    }

    public interface ITransportDelay : ISystemBlock
    {
        ITransportDelay SetTimeDelay(double delay);
        ITransportDelay SetInitialOutput(double output);
        ITransportDelay SetInitialBufferSize(int memoryInKB);
        ITransportDelay SetPadeOrder(int order);
        ITransportDelay WithFixedBufferSize();
        ITransportDelay WithDirectFeedthrough();
    }

    public interface IStateSpace : ISystemBlock
    {
        IStateSpaceCharacteristics WithStateSpaceCharacteristics(int numberOfInputs = 1, int numberOfOutputs = 1, int numberOfStates = 1);
    }

    public interface IStateSpaceCharacteristics : ISystemBlock
    {
        IStateSpaceCharacteristics SetMatrixCoefficient_A(double[,] coefficients);
        IStateSpaceCharacteristics SetMatrixCoefficient_B(double[,] coefficients);
        IStateSpaceCharacteristics SetMatrixCoefficient_C(double[,] coefficients);
        IStateSpaceCharacteristics SetMatrixCoefficient_D(double[,] coefficients);
        IStateSpaceCharacteristics SetInitialStateVector(double[] coefficients);
    }

    #endregion

    #region Integrators

    public interface IBaseIntegrator : ISystemBlock
    {
        IBaseIntegrator SetInitialCondition(double initialCondition);
        IBaseIntegrator ShowSaturationPort();
        IBaseIntegrator ShowStatePort();
    }

    public interface IIntegrator : IBaseIntegrator
    {

    }

    public interface ILimitedIntegrator : IBaseIntegrator
    {
        ILimitedIntegrator SetSaturationLimits(double lowerLimit = 0, double upperLimit = 1);
    }

    #endregion

    #region Transfer Functions

    public interface ITransferFunction : ISystemBlock
    {
        ITransferFunction SetNumerator(params double[] coefficients);
        ITransferFunction SetDenominator(params double[] coefficients);
    }

    public interface IZeroPole : ISystemBlock
    {
        IZeroPole SetZeros(params double[] coefficients);
        IZeroPole SetPoles(params double[] coefficients);
        IZeroPole SetGain(double gain);
    }


    #endregion

    #region PID Controllers

    public interface IPIDBaseController : ISystemBlock
    {
        IPIDBaseController SetForm(Form form);
        IPIDSampleTime SetTimeDomain(TimeDomain timeDomain);
    }

    public interface IPIDSampleTime
    {
        IPIDBaseController SetSampleTime(double sampleTime);
    }

    #region 1 DOF

    public interface IPIDController : IPIDBaseController
    {
        IPIDController SetProportional(double value);
        IPIDController SetIntegral(double value);
        IPIDController SetDerivative(double value);
        IPIDController SetFilterCoefficient(double value);
        IPIDController SetInitialConditionForIntegrator(double value);
        IPIDController SetInitialConditionForFilter(double value);
        IPIDController SetIntegratorMethod(IntegratorMethod method);
        IPIDController SetFilterMethod(FilterMethod method);
        IPIDController UseDerivativeFilter();
    }

    public interface IPDController : IPIDBaseController
    {
        IPDController SetProportional(double value);
        IPDController SetDerivative(double value);
        IPDController SetFilterCoefficient(double value);
        IPDController SetInitialConditionForFilter(double value);
        IPDController SetFilterMethod(FilterMethod method);
        IPDController UseDerivativeFilter();
    }

    public interface IPIController : IPIDBaseController
    {
        IPIController SetProportional(double value);
        IPIController SetIntegral(double value);
        IPIController SetInitialConditionForIntegrator(double value);
        IPIController SetIntegratorMethod(IntegratorMethod method);
    }

    public interface IIController : IPIDBaseController
    {
        IIController SetIntegral(double value);
        IIController SetInitialConditionForIntegrator(double value);
        IIController SetIntegratorMethod(IntegratorMethod method);
    }

    public interface IPController : IPIDBaseController
    {
        IPController SetProportional(double value);
    }

    #endregion

    #region 2 DOF

    public interface ITwoDofPIDController : IPIDController
    {
        ITwoDofPIDController SetProportionalSetpointWeight(double value);
        ITwoDofPIDController SetDerivativeSetpointWeight(double value);
    }

    public interface ITwoDofPDController : IPDController
    {
        ITwoDofPDController SetProportionalSetpointWeight(double value);
        ITwoDofPDController SetDerivativeSetpointWeight(double value);
    }

    public interface ITwoDofPIController : IPIController
    {
        ITwoDofPIController SetProportionalSetpointWeight(double value);
    }

    #endregion

    #endregion
}
