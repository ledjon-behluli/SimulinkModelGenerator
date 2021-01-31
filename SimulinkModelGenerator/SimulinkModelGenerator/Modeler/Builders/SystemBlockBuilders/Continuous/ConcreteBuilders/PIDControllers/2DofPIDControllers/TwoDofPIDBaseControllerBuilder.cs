using SimulinkModelGenerator.Models;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous.PIDControllers
{
    public abstract class TwoDofPIDBaseControllerBuilder<T> : PIDBaseControllerBuilder<T>
        where T : PIDBaseControllerBuilder<T>
    {
        internal override SizeU Size => new SizeU(55, 40);

        protected override string BlockName => "PID Controller (2DOF)";
        protected override string SourceBlock => "simulink/Continuous/PID Controller (2DOF)";
        protected override string SourceType => "PID 2dof";

        protected string _b = "1";
        protected string _c = "0";

        public TwoDofPIDBaseControllerBuilder(Model model)
            : base(model)
        {

        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.InstanceData.P.AddRange(new List<Parameter>()
            {
                new Parameter() { Name = "b", Text = "" },
                new Parameter() { Name = "c", Text = "" },

                new Parameter() { Name = "bParamMin", Text = "[]" },
                new Parameter() { Name = "bParamMax", Text = "[]" },
                new Parameter() { Name = "bParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "cParamMin", Text = "[]" },
                new Parameter() { Name = "cParamMax", Text = "[]" },
                new Parameter() { Name = "cParamDataTypeStr", Text = "Inherit: Inherit via internal rule" },

                new Parameter() { Name = "bOutMin", Text = "[]" },
                new Parameter() { Name = "bOutMax", Text = "[]" },
                new Parameter() { Name = "bOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "bGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "bProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "cOutMin", Text = "[]" },
                new Parameter() { Name = "cOutMax", Text = "[]" },
                new Parameter() { Name = "cOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "cGainOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "cProdOutDataTypeStr", Text = "Inherit: Inherit via internal rule" },

                new Parameter() { Name = "Sum1OutMin", Text = "[]" },
                new Parameter() { Name = "Sum1OutMax", Text = "[]" },
                new Parameter() { Name = "Sum1OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "Sum2OutMin", Text = "[]" },
                new Parameter() { Name = "Sum2OutMax", Text = "[]" },
                new Parameter() { Name = "Sum2OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "Sum3OutMin", Text = "[]" },
                new Parameter() { Name = "Sum3OutMax", Text = "[]" },
                new Parameter() { Name = "Sum3OutDataTypeStr", Text = "Inherit: Inherit via internal rule" },

                new Parameter() { Name = "Sum1AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "Sum2AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" },
                new Parameter() { Name = "Sum3AccumDataTypeStr", Text = "Inherit: Inherit via internal rule" }
            });

            model.System.Block.Add(block);
        }
    }
}
