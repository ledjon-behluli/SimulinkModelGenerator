﻿using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    /// <summary>
    /// State-space model:
    /// <para>[dx/dt = Ax + Bu]</para>
    /// <para>[y = Cx + Du]</para>
    /// <para>[x|t = t0 = x0]</para>
    /// <para>Where x is the state vector, u is the input vector, y is the output vector, and x0 is the initial condition of the state vector. 
    /// The matrix coefficients must have these characteristics:
    /// <list type="bullet">
    /// <item><description>A must be an n-by-n matrix, where n is the number of states.</description></item>
    /// <item><description>B must be an n-by-m matrix, where m is the number of inputs.</description></item>
    /// <item><description>C must be an r-by-n matrix, where r is the number of outputs.</description></item>
    /// <item><description>D must be an r-by-m matrix.</description></item>
    /// </list>
    /// </para>
    /// </summary>
    internal class StateSpaceBuilder : SystemBlockBuilder<StateSpaceBuilder>, IStateSpace, IStateSpaceCharacteristics
    {
        internal override SizeU Size => new SizeU(60, 34);

        private int _NumberOfInputs = 1;
        private int _NumberOfOutputs = 1;
        private int _NumberOfStates = 1;

        private Dimessions A_Dims = Dimessions.Get(new double[,] { { 1 } });
        private Dimessions B_Dims = Dimessions.Get(new double[,] { { 1 } });
        private Dimessions C_Dims = Dimessions.Get(new double[,] { { 1 } });
        private Dimessions D_Dims = Dimessions.Get(new double[,] { { 1 } });
        private double[] X0_Dims = new double[] { 0.0 };

        private string _A = "1";
        private string _B = "1";
        private string _C = "1";
        private string _D = "1";
        private string _X0 = "0.0";

        internal StateSpaceBuilder(Model model)
            : base(model)
        {
            
        }

        public IStateSpaceCharacteristics WithStateSpaceCharacteristics(int numberOfInputs = 1, int numberOfOutputs = 1, int numberOfStates = 1)
        {
            if (numberOfInputs < 1)
                throw new SimulinkModelGeneratorException("Number of inputs must be greater than or equal to 1");

            if (numberOfOutputs < 1)
                throw new SimulinkModelGeneratorException("Number of outputs must be greater than or equal to 1");

            if (numberOfStates < 1)
                throw new SimulinkModelGeneratorException("Number of states must be greater than or equal to 1");

            _NumberOfInputs = numberOfInputs;
            _NumberOfOutputs = numberOfOutputs;
            _NumberOfStates = numberOfStates;

            return this;
        }

        public IStateSpaceCharacteristics SetMatrixCoefficient_A(double[,] coefficients)
        {
            A_Dims = Dimessions.Get(coefficients);
            _A = ToMatrixString(coefficients);

            return this;
        }

        public IStateSpaceCharacteristics SetMatrixCoefficient_B(double[,] coefficients)
        {
            B_Dims = Dimessions.Get(coefficients);
            _B = ToMatrixString(coefficients);

            return this;
        }

        public IStateSpaceCharacteristics SetMatrixCoefficient_C(double[,] coefficients)
        {
            C_Dims = Dimessions.Get(coefficients);
            _C = ToMatrixString(coefficients);

            return this;
        }

        public IStateSpaceCharacteristics SetMatrixCoefficient_D(double[,] coefficients)
        {
            D_Dims = Dimessions.Get(coefficients);
            _D = ToMatrixString(coefficients);

            return this;
        }

        public IStateSpaceCharacteristics SetInitialStateVector(double[] coefficients)
        {
            X0_Dims = coefficients;
            _X0 = coefficients.Length == 1 ? coefficients[0].ToString() : $"[{string.Join("; ", coefficients)}]";

            return this;
        }

        private string ToMatrixString(double[,] coefficients)
        {
            var result = string.Join(" ",
               Enumerable.Range(0, coefficients.GetUpperBound(0) + 1)
                         .Select(x => Enumerable.Range(0, coefficients.GetUpperBound(1) + 1)
                               .Select(y => coefficients[x, y]))
                         .Select(z => "" + string.Join(" ", z) + ";"));

            result = result.Substring(0, result.Length - 1);
            return result.Length == 1 ? result : $"[{result}]";
        }


        internal override void Build()
        {
            if (A_Dims.RowCount != A_Dims.ColumnCount || A_Dims.RowCount != _NumberOfStates || A_Dims.ColumnCount != _NumberOfStates)
                throw new SimulinkModelGeneratorException("Matrix coefficient A, must be a real-valued n-by-n matrix, where n is the number of states.");

            if (B_Dims.RowCount != _NumberOfStates || B_Dims.ColumnCount != _NumberOfInputs)
                throw new SimulinkModelGeneratorException("Matrix coefficient B, must be a real-valued n-by-m matrix, where n is the number of states and m is the number of inputs.");

            if (C_Dims.RowCount != _NumberOfOutputs || C_Dims.ColumnCount != _NumberOfStates)
                throw new SimulinkModelGeneratorException("Matrix coefficient C, must be a real-valued r-by-n matrix, where r is the number of outputs and n is the number of states.");

            if (D_Dims.RowCount != _NumberOfOutputs || D_Dims.ColumnCount != _NumberOfInputs)
                throw new SimulinkModelGeneratorException("Matrix coefficient D, must be a real-valued r-by-m matrix, where r is the number of outputs and m is the number of inputs.");

            if (X0_Dims.Length > 1 && X0_Dims.Length != _NumberOfStates)
                throw new SimulinkModelGeneratorException("Initial state vector, must be a real-valued n-vector, where n is the number of states, or can be a 1-vector.");


            model.System.Block.Add(new Block()
            {
                BlockType = "StateSpace",
                BlockName = GenerateUniqueName("State-Space"),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "A", Text = _A },
                    new Parameter() { Name = "B", Text = _B },
                    new Parameter() { Name = "C", Text = _C },
                    new Parameter() { Name = "D", Text = _D },
                    new Parameter() { Name = "X0", Text = _X0 },
                    new Parameter() { Name = "AbsoluteTolerance", Text = "auto" },
                    new Parameter() { Name = "ContinuousStateAttributes", Text = "''" },
                    new Parameter() { Name = "Realization", Text = "auto" },
                }
            });
        }


        private class Dimessions
        {
            public int RowCount { get; private set; }
            public int ColumnCount { get; private set; }

            public static Dimessions Get(double[,] coefficients) => new Dimessions()
            {
                RowCount = coefficients.GetUpperBound(0) + 1,
                ColumnCount = coefficients.GetUpperBound(1) + 1
            };
        }
    }
}
