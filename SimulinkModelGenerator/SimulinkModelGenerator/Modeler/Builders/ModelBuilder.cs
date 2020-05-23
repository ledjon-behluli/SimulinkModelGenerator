using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.IO;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed class ModelBuilder : IModel, IFinalizeModel
    {        
        private Model model;
        private string _ModelName = "untitled";

        public string MDL { get; private set; }

        public ModelBuilder()
        {
            this.model = new Model();            
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

            string blocks = string.Empty;
            foreach(Block block in model.System.Block)
            {
                blocks += block.ToString() + Environment.NewLine;
            }

            string lines = string.Empty;
            foreach(Line line in model.System.Line)
            {
                lines += line.ToString() + Environment.NewLine;
            }

            MDL = $@"Model {{
                        Name ""{model.Name}""
                        System {{
                            Name ""{model.Name}""
                            {blocks}
                            {lines}
                         }}
                    }}";

            return MDL;
        }

        public void Save(string path)
        {
            this.Build();

            string fullname = $"{path}\\{this.model.Name}.mdl";
            Directory.CreateDirectory(Path.GetDirectoryName(fullname));
            if (File.Exists(fullname))
                File.Delete(fullname);

            using (StreamWriter sw = File.CreateText(fullname))
            {
                sw.WriteLine(MDL);
            }
        }
    }
}
