using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class IntegratorBuilder : SystemBlockBuilder<IntegratorBuilder>, IIntegrator
    {        
        private string _InitialCondition = "0";

        public IntegratorBuilder(Model model)
            : base(model)
        {
            
        }

        public IIntegrator SetInitialCondition(decimal initialCondition)
        {
            _InitialCondition = initialCondition.ToString();
            return this;
        }

        public override ISystemBlock SetPosition(uint x, uint y, uint width = 30, uint height = 30)
        {
            return base.SetPosition(x, y, width, height);
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
