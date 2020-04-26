using System.Collections.Generic;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class GainBuilder : SystemBlockBuilder<GainBuilder>, IGain
    {
        private string _Gain = "1";

        public GainBuilder(ModelInformation modelInformation)
            : base(modelInformation)
        {

        }


        public IGain SetGain(decimal gain)
        {
            _Gain = gain.ToString();
            return this;
        }    


        internal override void Build()
        {
            base.modelInformation.Model.System.Block.Add(new Block()
            {
                BlockType = "Gain",
                Name = base.GetName("Gain"),
                SID = base._SID,
                P = new List<P>()
                {
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "ZOrder", Text = base._ZOrder },
                    new P() { Name = "BlockMirror", Text = "on" },
                    new P() { Name = "ParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                    new P() { Name = "OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                    new P() { Name = "SaturateOnIntegerOverflow", Text = "off" },
                    new P() { Name = "Gain", Text = _Gain }
                }
            });
        }
    }
}
