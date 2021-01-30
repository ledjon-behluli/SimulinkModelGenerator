using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers;
using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemContinuous
    {
        ISystemContinuous AddIntegrator(Action<IntegratorBuilder> action = null);
        ISystemContinuous AddTransferFunction(Action<TransferFunctionBuilder> action = null);
        ISystemContinuous AddPIDController(Action<PIDControllerBuilder> action = null);
        ISystemContinuous AddPDController(Action<PDControllerBuilder> action = null);
        ISystemContinuous AddPIController(Action<PIControllerBuilder> action = null);
        ISystemContinuous AddIController(Action<IControllerBuilder> action = null);
        ISystemContinuous AddPController(Action<PControllerBuilder> action = null);
    }

    public interface IPIDBaseController : ISystemBlock
    {
        IPIDBaseController SetForm(Form form);
        IPIDSampleTime SetTimeDomain(TimeDomain timeDomain);
    }

    public interface IPIDSampleTime
    {
        IPIDBaseController SetSampleTime(double sampleTime);
    }


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


    public interface IIntegrator : ISystemBlock
    {
        IIntegrator SetInitialCondition(double initialCondition);
    }

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
}
