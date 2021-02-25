using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using SimulinkModelGenerator.Rules;
using SimulinkModelGenerator.Rules.ModelBuilder;
using System;
using System.IO;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public sealed partial class ModelBuilder : IModel, IFinalizeModel
    {        
        private Model model;

        public string MDL { get; private set; }
        public static IModel Create() => new ModelBuilder();

        private ModelBuilder()
        {
            this.model = new Model();

            this.model.Name = "untitled";
            this.model.SimulationMode = SimulationMode.Normal;
            this.model.Array = new Models.Array();
        }

        public IModel WithName(string name)
        {
            if (!ModelNameRule.Evaluate(name, out string error))
                throw new SimulinkModelGeneratorException(error);

            model.Name = name;
            return this;
        }

        public IModel WithSimulationMode(SimulationMode mode = SimulationMode.Normal)
        {
            model.SimulationMode = mode;
            return this;
        }

        public IModel Configure(Action<ConfigurationBuilder> action = null)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder(model);
            action?.Invoke(builder);
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
            MDL = model.ToString();
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
