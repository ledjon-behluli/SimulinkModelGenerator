using System;
using System.Collections.Generic;
using System.Text;

namespace SimulinkModelGenerator.Models
{
    internal class Array
    {
        public ConfigSet ConfigSet { get; internal set; }

        public List<Parameter> Parameters =>
            new List<Parameter>()
            {
                new Parameter() { Name = "Type", Text = "Handle" },
                new Parameter() { Name = "Dimension", Text = "1" },
                new Parameter() { Name = "Name", Text = "Configuration" },
                new Parameter() { Name = "CurrentDlgPage", Text = "Solver" },
                new Parameter() { Name = "PropName", Text = "ConfigurationSets" }
            };
        
        public override string ToString()
        {
            if (ConfigSet == null)
            {
                return string.Empty;
            }

            string properties = string.Empty;
            foreach (Parameter p in Parameters)
            {
                properties += $"\t\t{p.ToString() + Environment.NewLine}";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("\tArray {");
            sb.Append(Environment.NewLine);
            sb.Append(properties);
            sb.Append(ConfigSet.ToString());
            sb.Append("\t}");
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
