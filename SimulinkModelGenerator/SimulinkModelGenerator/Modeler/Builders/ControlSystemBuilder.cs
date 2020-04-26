using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sources;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed class ControlSystemBuilder : IControlSystem
    {
        private readonly ModelInformation modelInformation;

        private string _Location = "[-1139, 185, -81, 718]";
        private string _TiledPaperMargins = "[0.500000, 0.500000, 0.500000, 0.500000]";
        private string _ReportName = "simulink-default.rpt";

        public ControlSystemBuilder(ModelInformation modelInformation)
        {
            this.modelInformation = modelInformation;
        }

        public IControlSystem SetLocation(int x1, int y1, int x2, int y2)
        {
            _Location = $"[{x1}, {y1}, {x2}, {y2}]";
            return this;
        }

        public IControlSystem SetTiledPaperMargins(uint x1, uint y1, uint x2, uint y2)
        {
            _TiledPaperMargins = $"[{x1}, {y1}, {x2}, {y2}]";
            return this;
        }

        public IControlSystem WithReportName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _ReportName = name;
            return this;
        }

        #region System Blocks

        #region Continous

        private IControlSystem AddContinous<T>(dynamic action)
        {
            Type blockType = typeof(T);            
            SystemBlockBuilder builder = null;

            if (blockType == typeof(PIDControllerBuilder))
                builder = new PIDControllerBuilder(modelInformation);
            else if (blockType == typeof(PDControllerBuilder))
                builder = new PDControllerBuilder(modelInformation);
            else if (blockType == typeof(PIControllerBuilder))
                builder = new PIControllerBuilder(modelInformation);
            else if (blockType == typeof(IControllerBuilder))
                builder = new IControllerBuilder(modelInformation);
            else if (blockType == typeof(PControllerBuilder))
                builder = new PControllerBuilder(modelInformation);
            else if (blockType == typeof(IntegratorBuilder))
                builder = new IntegratorBuilder(modelInformation);
            else if (blockType == typeof(TransferFunctionBuilder))
                builder = new TransferFunctionBuilder(modelInformation);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported continous builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }

        public IControlSystem AddIntegrator(Action<IntegratorBuilder> action = null) => AddContinous<PDControllerBuilder>(action);
        public IControlSystem AddTransferFunction(Action<TransferFunctionBuilder> action = null) => AddContinous<TransferFunctionBuilder>(action);

        #region PID Controllers

        public IControlSystem AddPIDControler(Action<PIDControllerBuilder> action = null) => AddContinous<PIDControllerBuilder>(action);
        public IControlSystem AddPDControler(Action<PDControllerBuilder> action = null) => AddContinous<PDControllerBuilder>(action = null);
        public IControlSystem AddPIControler(Action<PIControllerBuilder> action = null) => AddContinous<PIControllerBuilder>(action = null);
        public IControlSystem AddIControler(Action<IControllerBuilder> action = null) => AddContinous<IControllerBuilder>(action = null);
        public IControlSystem AddPControler(Action<PControllerBuilder> action = null) => AddContinous<PControllerBuilder>(action = null);

        #endregion

        #endregion

        #region Math Operations

        private IControlSystem AddMathOperation<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(GainBuilder))
                builder = new GainBuilder(modelInformation);
            else if (systemBlockType == typeof(SumBuilder))
                builder = new SumBuilder(modelInformation);
            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported math operation builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }

        public IControlSystem AddGain(Action<GainBuilder> action = null) => AddMathOperation<GainBuilder>(action);
        public IControlSystem AddSum(Action<SumBuilder> action = null) => AddMathOperation<SumBuilder>(action);

        #endregion

        #region Sinks

        private IControlSystem AddSink<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(DisplayBuilder))
                builder = new DisplayBuilder(modelInformation);
            else if (systemBlockType == typeof(ScopeBuilder))
                builder = new ScopeBuilder(modelInformation);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported sink builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }

        public IControlSystem AddDisplay(Action<DisplayBuilder> action = null) => AddSink<DisplayBuilder>(action);
        public IControlSystem AddScope(Action<ScopeBuilder> action = null) => AddSink<ScopeBuilder>(action);

        #endregion

        #region Sources

        private IControlSystem AddSource<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(ConstantBuilder))
                builder = new ConstantBuilder(modelInformation);
            else if (systemBlockType == typeof(RampBuilder))
                builder = new RampBuilder(modelInformation);
            else if (systemBlockType == typeof(StepBuilder))
                builder = new StepBuilder(modelInformation);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported source builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }

        public IControlSystem AddConstant(Action<ConstantBuilder> action = null) => AddSource<ConstantBuilder>(action);
        public IControlSystem AddRamp(Action<RampBuilder> action = null) => AddSource<RampBuilder>(action);
        public IControlSystem AddStep(Action<StepBuilder> action = null) => AddSource<StepBuilder>(action);

        #endregion

        #endregion

        #region System Lines


        #endregion

        internal IControlSystem Build()
        {
            this.modelInformation.Model.System = new System()
            {
                P = new List<P>()
                {
                    // Customizable
                    new P(){ Name = "Location", Text = _Location },                    
                    new P(){ Name = "TiledPaperMargins", Text = _TiledPaperMargins },
                    new P(){ Name = "ReportName", Text = _ReportName },
                    // Default
                    new P(){ Name = "Open", Text = "on" },
                    new P(){ Name = "PortBlocksUseCompactNotation", Text = "off" },                    
                    new P(){ Name = "SIDHighWatermark", Text = "6" }
                },
                Block = new List<Block>()
                {

                },
                Line = new List<Line>()
                {

                }
            };

            return this;
        }        
    }
}
