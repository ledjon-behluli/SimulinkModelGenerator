using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class SystemContinuousBuilder : ISystemContinuous
    {
        private readonly Model model;

        public SystemContinuousBuilder(Model model) 
        {
            this.model = model;
        }

        public ISystemContinuous AddIntegrator(Action<IntegratorBuilder> action = null) => AddContinous<IntegratorBuilder>(action);       
        public ISystemContinuous AddTransferFunction(Action<TransferFunctionBuilder> action = null) => AddContinous<TransferFunctionBuilder>(action);
        public ISystemContinuous AddPIDController(Action<PIDControllerBuilder> action = null) => AddContinous<PIDControllerBuilder>(action);
        public ISystemContinuous AddPDController(Action<PDControllerBuilder> action = null) => AddContinous<PDControllerBuilder>(action);
        public ISystemContinuous AddPIController(Action<PIControllerBuilder> action = null) => AddContinous<PIControllerBuilder>(action);
        public ISystemContinuous AddIController(Action<IControllerBuilder> action = null) => AddContinous<IControllerBuilder>(action);
        public ISystemContinuous AddPController(Action<PControllerBuilder> action = null) => AddContinous<PControllerBuilder>(action);

        private ISystemContinuous AddContinous<T>(dynamic action)
        {
            Type blockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (blockType == typeof(PIDControllerBuilder))
                builder = new PIDControllerBuilder(model);
            else if (blockType == typeof(PDControllerBuilder))
                builder = new PDControllerBuilder(model);
            else if (blockType == typeof(PIControllerBuilder))
                builder = new PIControllerBuilder(model);
            else if (blockType == typeof(IControllerBuilder))
                builder = new IControllerBuilder(model);
            else if (blockType == typeof(PControllerBuilder))
                builder = new PControllerBuilder(model);
            else if (blockType == typeof(IntegratorBuilder))
                builder = new IntegratorBuilder(model);
            else if (blockType == typeof(TransferFunctionBuilder))
                builder = new TransferFunctionBuilder(model);

            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported continuous builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
