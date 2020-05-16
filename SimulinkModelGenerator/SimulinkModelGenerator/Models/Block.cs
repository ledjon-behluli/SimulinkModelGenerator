using System.Collections.Generic;
using System;

namespace SimulinkModelGenerator.Models
{
	public class Block
	{
		public List<Parameter> P { get; set; }
		public string BlockType { get; set; }
		public string Name { get; set; }
		public InstanceData InstanceData { get; set; }

		public override string ToString()
		{
			string properties = string.Empty;
			foreach(Parameter p in P)
			{
				properties += p.ToString() + Environment.NewLine;
			}

			if(InstanceData != null)
			{
				foreach(Parameter p in InstanceData.P)
				{
					properties += p.ToString() + Environment.NewLine;
				}
			}

			return $@"Block {{
						BlockType {BlockType}
						Name ""{Name}""	
						{properties}
					}}";
		}
	}

	public class InstanceData
	{
		public List<Parameter> P { get; set; }
	}
}
