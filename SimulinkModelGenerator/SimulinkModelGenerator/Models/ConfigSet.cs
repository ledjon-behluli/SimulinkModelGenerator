using System;
using System.Collections.Generic;
using System.Text;

namespace SimulinkModelGenerator.Models
{
    internal class ConfigSet
    {
        public Solver Solver { get; internal set; }

        public List<Parameter> Parameters =>
           new List<Parameter>()
           {
                new Parameter() { Name = "Type", Text = "Handle" },
                new Parameter() { Name = "Dimension", Text = "2" },
                new Parameter() { Name = "PropName", Text = "Components" }
           };

        public override string ToString()
        {
            if (Solver == null)
            {
                return string.Empty;
            }

            string properties = string.Empty;
            foreach (Parameter p in Parameters)
            {
                properties += $"\t\t\t\t{p.ToString() + Environment.NewLine}";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("\t\tSimulink.ConfigSet {");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t\tArray {");
            sb.Append(Environment.NewLine);
            sb.Append(properties);
            sb.Append(Solver.ToString());
            sb.Append("\t\t\t}");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t}");
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}