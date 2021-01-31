using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public abstract class BaseIntegratorBuilder<T> : SystemBlockBuilder<T>, IBaseIntegrator
        where T : BaseIntegratorBuilder<T>
    {
        internal override SizeU Size => new SizeU(30, 30);
        internal abstract string BlockName { get; }

        private string _InitialCondition = "0";
        private bool _ShowSaturationPort = false;
        private bool _ShowStatePort = false;

        public BaseIntegratorBuilder(Model model)
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
            return this;
        }

        public IBaseIntegrator ShowStatePort()
        {
            _ShowStatePort = true;
            return this;
        }

        protected Block GetBlock()
        {
            return new Block()
            {
                BlockType = "Integrator",
                Name = $"{BlockName}{GetBlockTypeCount("Integrator")}",
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "InitialCondition", Text = _InitialCondition },
                    new Parameter() { Name = "ShowSaturationPort", Text = _ShowSaturationPort ? "on" : "off" },
                    new Parameter() { Name = "ShowStatePort", Text = _ShowStatePort ? "on" : "off" }
                }
            };
        }
    }
}
