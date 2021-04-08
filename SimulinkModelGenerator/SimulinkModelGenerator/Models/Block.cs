using System.Collections.Generic;
using System;
using System.Text;
using System.Diagnostics;

namespace SimulinkModelGenerator.Models
{
	[DebuggerDisplay("{BlockName}")]
	internal class Block
	{
		public List<Parameter> Parameters { get; set; }
		public InstanceData InstanceData { get; set; }

		public string BlockType { get; set; }
		public string BlockName { get; set; }
		

		public override string ToString()
		{
			string properties = string.Empty;
			foreach (Parameter p in Parameters)
			{
				properties += $"\t\t\t{p.ToString() + Environment.NewLine}";
			}

			if (InstanceData != null)
			{
				foreach(Parameter p in InstanceData.Parameters)
				{
					properties += $"\t\t\t{p.ToString() + Environment.NewLine}";
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("\t\tBlock {");
			sb.Append(Environment.NewLine);
			sb.Append($"\t\t\tBlockType\t\t\"{BlockType}\"");
			sb.Append(Environment.NewLine);
			sb.Append($"\t\t\tName\t\t\"{BlockName}\"");
			sb.Append(Environment.NewLine);
			sb.Append(properties);
			sb.Append("\t\t}");

			return sb.ToString();
		}
	}

	internal class InstanceData
	{
		public List<Parameter> Parameters { get; internal set; }
	}
}
