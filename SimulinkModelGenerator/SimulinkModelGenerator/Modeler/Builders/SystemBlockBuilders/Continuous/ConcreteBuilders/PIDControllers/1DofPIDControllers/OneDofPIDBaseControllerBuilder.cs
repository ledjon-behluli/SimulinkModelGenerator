using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public abstract class OneDofPIDBaseControllerBuilder<T> : PIDBaseControllerBuilder<T>
        where T : PIDBaseControllerBuilder<T>
    {
        internal override SizeU Size => new SizeU(40, 36);

        protected override string BlockName => "PID Controller";
        protected override string SourceBlock => "simulink/Continuous/PID Controller";
        protected override string SourceType => "PID 1dof";


        public OneDofPIDBaseControllerBuilder(Model model)
            : base(model)
        {

        }

        internal override void Build()
        {
            Block block = GetBlock();
            model.System.Block.Add(block);
        }
    }
}
