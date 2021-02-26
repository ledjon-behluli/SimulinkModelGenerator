using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            if (string.IsNullOrEmpty(name))
                throw new SimulinkModelGeneratorException("Model name can not be null or empty");

            if (name.Length < 2 || name.Length >= 64)
                throw new SimulinkModelGeneratorException("Model name must have more than 2 and less than 64 characters");

            if (!Regex.Match(name, "^[A-Za-z0-9_]+$").Success)
                throw new SimulinkModelGeneratorException("Model name can only contain these characters: a-z, A-Z, 0-9 and the underscore character");

            if (name.Any(c => char.IsWhiteSpace(c)))
                throw new SimulinkModelGeneratorException("Model name can not contain any whitespace character");

            if (name.StartsWith("_"))
                throw new SimulinkModelGeneratorException("Model name can not start with an underscore character");

            if (char.IsNumber(name.ToCharArray().ElementAt(0)))
                throw new SimulinkModelGeneratorException("Model name can not start with a number");

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
