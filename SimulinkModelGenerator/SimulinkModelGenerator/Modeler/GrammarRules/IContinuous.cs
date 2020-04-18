using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ITransferFunction : ISystemBlock
    {
        ITransferFunction SetNumerator(params decimal[] coefficients);
        ITransferFunction SetDenominator(params decimal[] coefficients);
    }

    public interface IIntegrator : ISystemBlock
    {
        IIntegrator SetInitialCondition(decimal initialCondition);
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
}
