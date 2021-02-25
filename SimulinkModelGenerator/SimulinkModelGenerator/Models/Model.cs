using SimulinkModelGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimulinkModelGenerator
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
}

namespace SimulinkModelGenerator.Models
{
    internal class Model
    {
        public Array Array { get; set; }
        public System System { get; set; }
        public string Name { get; set; }
        public SimulationMode SimulationMode { get; set; }

        internal List<Parameter> Parameters =>
            new List<Parameter>()
            {
                new Parameter() { Name = "Name", Text = Name },
                new Parameter() { Name = "SimulationMode", Text = SimulationMode.GetDescription() }
            };

        public override string ToString()
        {
            string properties = string.Empty;
            foreach (Parameter p in Parameters)
            {
                properties += $"\t{p.ToString() + Environment.NewLine}";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Model {");
            sb.Append(Environment.NewLine);
            sb.Append(properties);
            sb.Append(Array.ToString());
            sb.Append(System.ToString());
            sb.Append("}");

            return sb.ToString();
        }
    }
}
