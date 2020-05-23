using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class SystemMathOperationsBuilder : ISystemMathOperation
    {
        private readonly Model model;

        public SystemMathOperationsBuilder(Model model)
        {
            this.model = model;
        }

        public ISystemMathOperation AddGain(Action<GainBuilder> action = null) => AddMathOperation<GainBuilder>(action);
        public ISystemMathOperation AddSum(Action<SumBuilder> action = null) => AddMathOperation<SumBuilder>(action);

        private ISystemMathOperation AddMathOperation<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder = null;

            if (systemBlockType == typeof(GainBuilder))
                builder = new GainBuilder(model);
            else if (systemBlockType == typeof(SumBuilder))
                builder = new SumBuilder(model);
            if (builder == null)
                throw new SimulinkModelGeneratorException("Unsupported math operation builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
