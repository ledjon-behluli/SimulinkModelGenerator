using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class IntegratorBuilder : SystemBlockBuilder<IntegratorBuilder>, IIntegrator
    {
        internal override SizeU Size => new SizeU(30, 30);

        private string _InitialCondition = "0";

        public IntegratorBuilder(Model model)
            : base(model)
        {
            
        }

        public IIntegrator SetInitialCondition(double initialCondition)
        {
            _InitialCondition = initialCondition.ToString();
            return this;
        }


        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Integrator",
                Name = base.GetName("Integrator"),
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "BlockMirror", Text = base.BlockMirror },
                    new P() { Name = "InitialCondition", Text = _InitialCondition }
                }
            });
        }
    }
}
