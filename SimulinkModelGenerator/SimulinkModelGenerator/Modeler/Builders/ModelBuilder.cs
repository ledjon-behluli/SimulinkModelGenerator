using SimulinkModelGenerator.Modeler.GrammarRules;
using System;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public class ModelBuilder : IModel, IFinalizeModel
    {        
        private Model model;
        private string _ModelName = "untitled";

        public string MDL { get; private set; }

        #region Overrideable Properties
  
        internal virtual GraphicalInterface GraphicalInterface { get; } = null;
        internal virtual Object Object { get; } = null;
        internal virtual ConfigManagerSettings ConfigManagerSettings { get; } = null;
        internal virtual EditorSettings EditorSettings { get; } = null;
        internal virtual SimulationSettings SimulationSettings { get; } = null;
        internal virtual ExternalMode ExternalMode { get; } = null;
        internal virtual ModelReferenceSettings ModelReferenceSettings { get; } = null;
        internal virtual ConcurrentExecutionSettings ConcurrentExecutionSettings { get; } = null;
        internal virtual SystemDefaults SystemDefaults { get; } = null;
        internal virtual BlockDefaults BlockDefaults { get; } = null;
        internal virtual AnnotationDefaults AnnotationDefaults { get; } = null;
        internal virtual LineDefaults LineDefaults { get; } = null;
        internal virtual MaskDefaults MaskDefaults { get; } = null;
        internal virtual MaskParameterDefaults MaskParameterDefaults { get; } = null;
        internal virtual BlockParameterDefaults BlockParameterDefaults { get; } = null;

        #endregion

        public ModelBuilder()
        {
            this.model = new Model()
            {                
                GraphicalInterface = this.GraphicalInterface,
                Object = this.Object,
                ConfigManagerSettings = this.ConfigManagerSettings,
                EditorSettings = this.EditorSettings,
                SimulationSettings = this.SimulationSettings,
                ExternalMode = this.ExternalMode,
                ModelReferenceSettings = this.ModelReferenceSettings,
                ConcurrentExecutionSettings = this.ConcurrentExecutionSettings,
                SystemDefaults = this.SystemDefaults,
                BlockDefaults = this.BlockDefaults,
                AnnotationDefaults = this.AnnotationDefaults,
                LineDefaults = this.LineDefaults,
                MaskDefaults = this.MaskDefaults,
                MaskParameterDefaults = this.MaskParameterDefaults,
                BlockParameterDefaults = this.BlockParameterDefaults
            };
        }

        public IModel WithName(string name)
        {
            _ModelName = name;
            return this;
        }

        public IFinalizeModel AddControlSystem(Action<ControlSystemBuilder> action = null)
        {
            ControlSystemBuilder builder = new ControlSystemBuilder(model);
            action?.Invoke(builder);
            return this;
        }

        public string Build()
        {
            this.model.Name = _ModelName;

            //TODO: Convert to MDL
            MDL = "test";

            return MDL;
        }

        public void Save(string path)
        {
            if (this.model == null)
                this.Build();

            //TODO: Save content of 'MDL' locally
        }
    }
}
