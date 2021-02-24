using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class SystemContinuousBuilder : ISystemContinuous
    {
        private readonly Model model;

        internal SystemContinuousBuilder(Model model) 
        {
            this.model = model;
        }

        public ISystemContinuous AddIntegrator(Action<IntegratorBuilder> action = null) => AddContinous<IntegratorBuilder>(action);
        public ISystemContinuous AddLimitedIntegrator(Action<LimitedIntegratorBuilder> action = null) => AddContinous<LimitedIntegratorBuilder>(action);
        public ISystemContinuous AddTransferFunction(Action<TransferFunctionBuilder> action = null) => AddContinous<TransferFunctionBuilder>(action);
        public ISystemContinuous AddZeroPole(Action<ZeroPoleBuilder> action = null) => AddContinous<ZeroPoleBuilder>(action);
        public ISystemContinuous AddDerivative(Action<DerivativeBuilder> action = null) => AddContinous<DerivativeBuilder>(action);
        public ISystemContinuous AddStateSpace(Action<StateSpaceBuilder> action = null) => AddContinous<StateSpaceBuilder>(action);
        public ISystemContinuous AddTransportDelay(Action<TransportDelayBuilder> action = null) => AddContinous<TransportDelayBuilder>(action);
        public ISystemContinuous AddPIDController(Action<PIDControllerBuilder> action = null) => AddContinous<PIDControllerBuilder>(action);
        public ISystemContinuous AddPDController(Action<PDControllerBuilder> action = null) => AddContinous<PDControllerBuilder>(action);
        public ISystemContinuous AddPIController(Action<PIControllerBuilder> action = null) => AddContinous<PIControllerBuilder>(action);
        public ISystemContinuous AddIController(Action<IControllerBuilder> action = null) => AddContinous<IControllerBuilder>(action);
        public ISystemContinuous AddPController(Action<PControllerBuilder> action = null) => AddContinous<PControllerBuilder>(action);
        public ISystemContinuous Add2DofPIDController(Action<TwoDofPIDControllerBuilder> action = null) => AddContinous<TwoDofPIDControllerBuilder>(action);
        public ISystemContinuous Add2DofPDController(Action<TwoDofPDControllerBuilder> action = null) => AddContinous<TwoDofPDControllerBuilder>(action);
        public ISystemContinuous Add2DofPIController(Action<TwoDofPIControllerBuilder> action = null) => AddContinous<TwoDofPIControllerBuilder>(action);

        private ISystemContinuous AddContinous<T>(dynamic action)
        {
            Type blockType = typeof(T);
            SystemBlockBuilder builder;

            if (blockType == typeof(IntegratorBuilder))
                builder = new IntegratorBuilder(model);
            else if (blockType == typeof(LimitedIntegratorBuilder))
                builder = new LimitedIntegratorBuilder(model);
            else if (blockType == typeof(TransferFunctionBuilder))
                builder = new TransferFunctionBuilder(model);
            else if (blockType == typeof(ZeroPoleBuilder))
                builder = new ZeroPoleBuilder(model);
            else if (blockType == typeof(DerivativeBuilder))
                builder = new DerivativeBuilder(model);
            else if (blockType == typeof(StateSpaceBuilder))
                builder = new StateSpaceBuilder(model);
            else if (blockType == typeof(TransportDelayBuilder))
                builder = new TransportDelayBuilder(model);
            else if (blockType == typeof(PIDControllerBuilder))
                builder = new PIDControllerBuilder(model);
            else if (blockType == typeof(PDControllerBuilder))
                builder = new PDControllerBuilder(model);
            else if (blockType == typeof(PIControllerBuilder))
                builder = new PIControllerBuilder(model);
            else if (blockType == typeof(IControllerBuilder))
                builder = new IControllerBuilder(model);
            else if (blockType == typeof(PControllerBuilder))
                builder = new PControllerBuilder(model);
            else if (blockType == typeof(TwoDofPIDControllerBuilder))
                builder = new TwoDofPIDControllerBuilder(model);
            else if (blockType == typeof(TwoDofPDControllerBuilder))
                builder = new TwoDofPDControllerBuilder(model);
            else if (blockType == typeof(TwoDofPIControllerBuilder))
                builder = new TwoDofPIControllerBuilder(model);
            else
                throw new SimulinkModelGeneratorException("Unsupported continuous builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
