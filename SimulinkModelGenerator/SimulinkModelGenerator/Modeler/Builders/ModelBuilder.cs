using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace SimulinkModelGenerator.Modeler.Builders
{
    public enum SimulationMode
    {
        [Description("normal")]
        Normal,
        [Description("accelerator")]
        Accelerator,
        [Description("rapid-accelerator")]
        RapidAccelerator,
        /// <summary>
        ///Software-in-the-Loop
        /// </summary>
        [Description("software-in-the-loop (sil)")]
        SIL,
        ///<summary>
        ///Processor-in-the-Loop
        ///</summary>
        [Description("processor-in-the-loop (pil)")]
        PIL,
        [Description("external")]
        External
    }

    public sealed partial class ModelBuilder : IModel, IFinalizeModel
    {        
        private Model model;

        private string _ModelName = "untitled";
        private SimulationMode _SimulationMode = SimulationMode.Normal;

        public string MDL { get; private set; }
        public static IModel Create() => new ModelBuilder();

        public ModelBuilder()
        {
            this.model = new Model();            
        }

        public IModel WithName(string name)
        {
            _ModelName = name;
            return this;
        }

        public IModel WithSimulationMode(SimulationMode mode = SimulationMode.Normal)
        {
            _SimulationMode = mode;
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
            this.model.Name = _ModelName;
            this.model.SimulationMode = _SimulationMode.GetDescription();

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

            StringBuilder sb = new StringBuilder();
            sb.Append("Model {");
            sb.Append(Environment.NewLine);
            sb.Append($"\tName \"{model.Name}\"");
            sb.Append(Environment.NewLine);
            sb.Append($"\tSimulationMode \"{model.SimulationMode}\"");
            sb.Append(Environment.NewLine);

            if (model.ConfigSet != null)
            {
                sb.Append("\tArray {");
                sb.Append(Environment.NewLine);
                sb.Append(model.ConfigSet.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("\t}");
                sb.Append(Environment.NewLine);
            }

            sb.Append("\tSystem {");
            sb.Append(Environment.NewLine);
            sb.Append($"\t\tName \"{model.Name}\"");
            sb.Append(Environment.NewLine);
            sb.Append(blocks);
            sb.Append(lines);
            sb.Append("\t}");
            sb.Append(Environment.NewLine);
            sb.Append("}");

            MDL = sb.ToString();

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
