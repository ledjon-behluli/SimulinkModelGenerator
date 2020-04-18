using System.Collections.Generic;
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Sinks
{
    public sealed class ScopeBuilder : SystemBlockBuilder<ScopeBuilder>, IScope
    {
        private string _NumInputPorts = "1";
        private string _Ports = "[1]";

        public ScopeBuilder(ModelInformation modelInformation)
            : base(modelInformation)
        {

        }

        public IScope SetInputPorts(uint numberOfPorts)
        {
            if (numberOfPorts > 0)
            {
                _NumInputPorts = numberOfPorts.ToString();
                _Ports = $"[{numberOfPorts}]";
            }
            else
                throw new SimulinkModelGeneratorException("Scope can not have less than 1 port!");

            return this;
        }


        internal override void Build()
        {
            base.modelInformation.Model.System.Block.Add(new Block()
            {
                BlockType = "Scope",
                Name = base.GetName("Scope"),
                SID = base._SID,
                P = new List<P>()
                {
                    new P() { Name = "Ports", Text = _Ports },
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "ZOrder", Text = base._ZOrder },
                    new P() { Name = "ScopeSpecificationString", Text = "Simulink.scopes.TimeScopeBlockCfg('CurrentConfiguration', extmgr.ConfigurationSet(extmgr.Configuration('Core','General UI',true),extmgr.Configuration('Core','Source UI',true),extmgr.Configuration('Sources','WiredSimulink',true),extmgr.Configuration('Visuals','Time Domain',true),extmgr.Configuration('Tools','Plot Navigation',true),extmgr.Configuration('Tools','Measurements',true)),'Version','2017a')" },
                    new P() { Name = "NumInputPorts", Text = _NumInputPorts }
                }
            });
        }
    }
}