using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver
{
    public sealed class FixedOptionsBuilder : IFixedStepSolverOptions
    {
        private readonly Model model;

        public FixedOptionsBuilder(Model model)
        {
            this.model = model;
            SetSolverType(FixedSolver.Auto);
        }

        private void SetSampleTime(double sampleTime)
        {
            if (sampleTime <= 0)
                throw new ArgumentException("Fundamental sample time can not be less than or equal to 0");

            model.ConfigSet.Solver.AdditionalSolverOptions.FixedStepSize = sampleTime.ToString();
        }

        private void SetSolverType(FixedSolver solver)
        {
            model.ConfigSet.Solver.SolverOptions.Solver = solver.GetDescription();
            model.ConfigSet.Solver.SolverOptions.SolverName = solver.GetDescription();
        }

        public IIntrapolatedFixedSolverType Auto() => throw new NotImplementedException();
        public IIntrapolatedFixedSolverType Discrete() => throw new NotImplementedException();
        public IIntrapolatedFixedSolverType Ode8() => throw new NotImplementedException();
        public IIntrapolatedFixedSolverType Ode5() => throw new NotImplementedException();
        public IIntrapolatedFixedSolverType Ode4() => throw new NotImplementedException();
        public IIntrapolatedFixedSolverType Ode3() => throw new NotImplementedException();
        public IIntrapolatedFixedSolverType Ode2() => throw new NotImplementedException();
        public IIntrapolatedFixedSolverType Ode1() => throw new NotImplementedException();
        public IExtrapolatedFixedSolverType Ode14x() => throw new NotImplementedException();


        #region Interface Implementations

        /// <summary>
        /// Automatic solver
        /// </summary>
        public void Auto(double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Auto);
            SetSampleTime(sampleTime);
        }

        /// <summary>
        /// No continous states
        /// </summary>
        public void Discrete(double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Discrete);
            SetSampleTime(sampleTime);
        }

        /// <summary>
        /// Dormand-Prince
        /// </summary>
        public void Ode8(double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Ode8);
            SetSampleTime(sampleTime);
        }

        /// <summary>
        /// Dormand-Prince
        /// </summary>
        public void Ode5(double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Ode5);
            SetSampleTime(sampleTime);
        }

        /// <summary>
        /// Runge-Kutta
        /// </summary>
        public void Ode4(double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Ode4);
            SetSampleTime(sampleTime);
        }

        /// <summary>
        /// Bogacki-Shampine
        /// </summary>
        public void Ode3(double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Ode3);
            SetSampleTime(sampleTime);
        }

        /// <summary>
        /// Heun
        /// </summary>
        public void Ode2(double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Ode2);
            SetSampleTime(sampleTime);
        }

        /// <summary>
        /// Euler
        /// </summary>
        public void Ode1(double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Ode1);
            SetSampleTime(sampleTime);
        }

        /// <summary>
        /// Extrapolation
        /// </summary>
        public void Ode14x(Jacobian jacobian = Jacobian.Auto, ExtrapolationOrder order = ExtrapolationOrder.Four,
            int numberOfNewtonIterations = 1, double sampleTime = 0.001)
        {
            SetSolverType(FixedSolver.Ode14x);
            SetSampleTime(sampleTime);

            if (numberOfNewtonIterations < 1)
                numberOfNewtonIterations = 1;

            model.ConfigSet.Solver.AdditionalSolverOptions.NumberNewtonIterations = numberOfNewtonIterations.ToString();
            model.ConfigSet.Solver.AdditionalSolverOptions.ExtrapolationOrder = order.GetDescription();
            model.ConfigSet.Solver.AdditionalSolverOptions.SolverJacobianMethodControl = jacobian.GetDescription();
        }

        #endregion
    }
}
