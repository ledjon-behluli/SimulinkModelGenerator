using System.Collections.Generic;
using System;
using System.Text;

namespace SimulinkModelGenerator.Models
{
	public class Block
	{
		public List<Parameter> P { get; internal set; }
		public string BlockType { get; internal set; }
		public string BlockName { get; internal set; }
		public InstanceData InstanceData { get; internal set; }

		public override string ToString()
		{
			string properties = string.Empty;
			foreach(Parameter p in P)
			{
				properties += $"\t\t\t{p.ToString() + Environment.NewLine}";
			}

			if(InstanceData != null)
			{
				foreach(Parameter p in InstanceData.P)
				{
					properties += $"\t\t\t{p.ToString() + Environment.NewLine}";
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("\t\tBlock {");
			sb.Append(Environment.NewLine);
			sb.Append($"\t\t\tBlockType \"{BlockType}\"");
			sb.Append(Environment.NewLine);
			sb.Append($"\t\t\tName \"{BlockName}\"");
			sb.Append(Environment.NewLine);
			sb.Append(properties);
			sb.Append("\t\t}");

			return sb.ToString();
		}
	}

	public class InstanceData
	{
		public List<Parameter> P { get; internal set; }
	}
}
