using System;
using System.Collections.Generic;
using System.Text;

namespace SimulinkModelGenerator.Models
{
	internal class System
	{
		public List<Block> Block { get; internal set; }
		public List<Line> Line { get; internal set; }

        public string Name { get; set; }

        public List<Parameter> Parameters =>
            new List<Parameter>()
            {
                new Parameter() { Name = "Name", Text = Name }
            };

        public override string ToString()
        {
            string properties = string.Empty;
            foreach (Parameter p in Parameters)
            {
                properties += $"\t\t{p.ToString() + Environment.NewLine}";
            }

            string blocks = string.Empty;
            foreach (Block block in Block)
            {
                blocks += block.ToString() + Environment.NewLine;
            }

            string lines = string.Empty;
            foreach (Line line in Line)
            {
                lines += line.ToString() + Environment.NewLine;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("\tSystem {");
            sb.Append(Environment.NewLine);
            sb.Append(properties);
            sb.Append(blocks);
            sb.Append(lines);
            sb.Append("\t}");
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
