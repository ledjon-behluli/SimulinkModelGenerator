using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
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
}
