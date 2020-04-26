using SimulinkModelGenerator.Modeler.GrammarRules;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class IntegratorBuilder : SystemBlockBuilder<IntegratorBuilder>, IIntegrator
    {        
        private string _InitialCondition = "0";

        public IntegratorBuilder(ModelInformation modelInformation)
            : base(modelInformation)
        {
            
        }

        public IIntegrator SetInitialCondition(decimal initialCondition)
        {
            _InitialCondition = initialCondition.ToString();
            return this;
        }


        internal override void Build()
        {
            base.modelInformation.Model.System.Block.Add(new Block()
            {
                BlockType = "Integrator",
                Name = base.GetName("Integrator"),
                SID = base._SID,
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "ZOrder", Text = base._ZOrder },
                    new P() { Name = "Ports", Text = "[1 1]" },
                    new P() { Name = "InitialCondition", Text = _InitialCondition }
                }
            });
        }
    }
}
