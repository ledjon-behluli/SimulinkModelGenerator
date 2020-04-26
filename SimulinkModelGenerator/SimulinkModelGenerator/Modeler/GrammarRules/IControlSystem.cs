using System;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface IControlSystem
    {
        IControlSystem SetLocation(int x1, int y1, int x2, int y2);
        IControlSystem SetTiledPaperMargins(uint x1, uint y1, uint x2, uint y2);
        IControlSystem WithReportName(string name);

        #region System Blocks

        #region Continous

        #region PID Controllers

        IControlSystem AddPIDControler(Action<PIDControllerBuilder> action = null);
        IControlSystem AddPDControler(Action<PDControllerBuilder> action = null);
        IControlSystem AddPIControler(Action<PIControllerBuilder> action = null);
        IControlSystem AddIControler(Action<IControllerBuilder> action = null);
        IControlSystem AddPControler(Action<PControllerBuilder> action = null);

        #endregion

        IControlSystem AddIntegrator(Action<IntegratorBuilder> action = null);
        IControlSystem AddTransferFunction(Action<TransferFunctionBuilder> action = null);

        #endregion
        #region Math Operations

        IControlSystem AddGain(Action<GainBuilder> action = null);
        IControlSystem AddSum(Action<SumBuilder> action = null);

        #endregion
        #region Sinks

        IControlSystem AddDisplay(Action<DisplayBuilder> action = null);
        IControlSystem AddScope(Action<ScopeBuilder> action = null);

        #endregion
        #region Sources

        IControlSystem AddConstant(Action<ConstantBuilder> action = null);
        IControlSystem AddRamp(Action<RampBuilder> action = null);
        IControlSystem AddStep(Action<StepBuilder> action = null);

        #endregion

        #endregion

        #region System Liness



        #endregion
    }


    public interface ISystemBlock
    {
        ISystemBlock WithName(string name);
        ISystemBlock SetPosition(int x1, int y1, int x2, int y2);
    }

    public interface ISystemLine
    {

    }
}
