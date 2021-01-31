﻿using SimulinkModelGenerator.Exceptions;
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

        public ISystemMathOperation AddSum(Action<SumBuilder> action = null) => AddMathOperation<SumBuilder>(action);
        public ISystemMathOperation AddAbs(Action<AbsBuilder> action = null) => AddMathOperation<AbsBuilder>(action);
        public ISystemMathOperation AddAddition(Action<AddBuilder> action = null) => AddMathOperation<AddBuilder>(action);
        public ISystemMathOperation AddSubtraction(Action<SubtractBuilder> action = null) => AddMathOperation<SubtractBuilder>(action);
        public ISystemMathOperation AddDivision(Action<DivideBuilder> action = null) => AddMathOperation<DivideBuilder>(action);
        public ISystemMathOperation AddProduct(Action<ProductBuilder> action = null) => AddMathOperation<ProductBuilder>(action);
        public ISystemMathOperation AddDotProduct(Action<DotProductBuilder> action = null) => AddMathOperation<DotProductBuilder>(action);
        public ISystemMathOperation AddMathFunction(Action<MathFunctionBuilder> action = null) => AddMathOperation<MathFunctionBuilder>(action);
        public ISystemMathOperation AddMin(Action<MinBuilder> action = null) => AddMathOperation<MinBuilder>(action);
        public ISystemMathOperation AddMax(Action<MaxBuilder> action = null) => AddMathOperation<MaxBuilder>(action);
        public ISystemMathOperation AddSign(Action<SignBuilder> action = null) => AddMathOperation<SignBuilder>(action);
        public ISystemMathOperation AddGain(Action<GainBuilder> action = null) => AddMathOperation<GainBuilder>(action);
        public ISystemMathOperation AddSliderGain(Action<SliderGainBuilder> action = null) => AddMathOperation<SliderGainBuilder>(action);
        public ISystemMathOperation AddSquareRoot(Action<SquareRootBuilder> action = null) => AddMathOperation<SquareRootBuilder>(action);
        public ISystemMathOperation AddSignedSquareRoot(Action<SignedSquareRootBuilder> action = null) => AddMathOperation<SignedSquareRootBuilder>(action);
        public ISystemMathOperation AddReciprocalSquareRoot(Action<ReciprocalSquareRootBuilder> action = null) => AddMathOperation<ReciprocalSquareRootBuilder>(action);
        public ISystemMathOperation AddTrigonometricFunction(Action<TrigonometricFunctionBuilder> action = null) => AddMathOperation<TrigonometricFunctionBuilder>(action);
        

        private ISystemMathOperation AddMathOperation<T>(dynamic action)
        {
            Type systemBlockType = typeof(T);
            SystemBlockBuilder builder;

            if (systemBlockType == typeof(SumBuilder))
                builder = new SumBuilder(model);
            else if (systemBlockType == typeof(AbsBuilder))
                builder = new AbsBuilder(model);
            else if (systemBlockType == typeof(AddBuilder))
                builder = new AddBuilder(model);
            else if (systemBlockType == typeof(SubtractBuilder))
                builder = new SubtractBuilder(model);
            else if (systemBlockType == typeof(DivideBuilder))
                builder = new DivideBuilder(model);
            else if (systemBlockType == typeof(ProductBuilder))
                builder = new ProductBuilder(model);
            else if (systemBlockType == typeof(DotProductBuilder))
                builder = new DotProductBuilder(model);
            else if (systemBlockType == typeof(MathFunctionBuilder))
                builder = new MathFunctionBuilder(model);
            else if (systemBlockType == typeof(MinBuilder))
                builder = new MinBuilder(model);
            else if (systemBlockType == typeof(MaxBuilder))
                builder = new MaxBuilder(model);
            else if (systemBlockType == typeof(SignBuilder))
                builder = new SignBuilder(model);
            else if (systemBlockType == typeof(GainBuilder))
                builder = new GainBuilder(model);
            else if (systemBlockType == typeof(SliderGainBuilder))
                builder = new SliderGainBuilder(model);
            else if (systemBlockType == typeof(SquareRootBuilder))
                builder = new SquareRootBuilder(model);
            else if (systemBlockType == typeof(SignedSquareRootBuilder))
                builder = new SignedSquareRootBuilder(model);
            else if (systemBlockType == typeof(ReciprocalSquareRootBuilder))
                builder = new ReciprocalSquareRootBuilder(model);
            else if (systemBlockType == typeof(TrigonometricFunctionBuilder))
                builder = new TrigonometricFunctionBuilder(model);
            else
                throw new SimulinkModelGeneratorException("Unsupported math operation builder provided!");

            action?.Invoke((dynamic)builder);
            builder.Build();
            return this;
        }
    }
}
