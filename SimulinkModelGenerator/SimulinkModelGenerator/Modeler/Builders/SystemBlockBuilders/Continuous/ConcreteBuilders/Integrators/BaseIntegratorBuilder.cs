using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    internal abstract class BaseIntegratorBuilder<T> : SystemBlockBuilder<T>, IBaseIntegrator
        where T : BaseIntegratorBuilder<T>
    {
        internal override SizeU Size => new SizeU(30, 30);
        internal abstract string BlockName { get; }

        protected string _InitialCondition = "0";
        protected string _UpperSaturationLimit;
        protected string _LowerSaturationLimit;

        private string _Ports = "[1, 1]";
        private bool _ShowSaturationPort = false;
        private bool _ShowStatePort = false;

        internal BaseIntegratorBuilder(Model model)
            : base(model)
        {

        }

        public IBaseIntegrator SetInitialCondition(double initialCondition)
        {
            _InitialCondition = initialCondition.ToString();
            return this;
        }

        public IBaseIntegrator ShowSaturationPort()
        {
            _ShowSaturationPort = true;
            _Ports = _ShowStatePort ? "[1, 2, 0, 0, 1]" : "[1, 2]";

            return this;
        }

        public IBaseIntegrator ShowStatePort()
        {
            _ShowStatePort = true;
            _Ports = _ShowSaturationPort ? "[1, 2, 0, 0, 1]" : "[1, 1, 0, 0, 1]";

            return this;
        }

        internal Block GetBlock()
        {
            return new Block()
            {
                BlockType = "Integrator",
                BlockName = GenerateUniqueName(BlockName),
                Parameters = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "InitialCondition", Text = _InitialCondition },
                    new Parameter() { Name = "Ports", Text = _Ports },
                    new Parameter() { Name = "LowerSaturationLimit", Text = _LowerSaturationLimit },
                    new Parameter() { Name = "UpperSaturationLimit", Text = _UpperSaturationLimit },
                    new Parameter() { Name = "ShowSaturationPort", Text = _ShowSaturationPort ? "on" : "off" },
                    new Parameter() { Name = "ShowStatePort", Text = _ShowStatePort ? "on" : "off" }
                }
            };
        }
    }
}
