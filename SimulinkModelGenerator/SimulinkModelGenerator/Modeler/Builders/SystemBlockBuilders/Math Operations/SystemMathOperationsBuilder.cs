using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class SystemMathOperationsBuilder : ISystemMathOperation
    {
        private readonly ModelInformation modelInformation;

        public SystemMathOperationsBuilder(ModelInformation modelInformation)
        {
            this.modelInformation = modelInformation;
        }

        public ISystemMathOperation AddGain(Action<GainBuilder> action = null) => AddMathOperation<GainBuilder>(action);
        public ISystemMathOperation AddSum(Action<SumBuilder> action = null) => AddMathOperation<SumBuilder>(action);

        private ISystemMathOperation AddMathOperation<T>(dynamic action)
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
    }
}
