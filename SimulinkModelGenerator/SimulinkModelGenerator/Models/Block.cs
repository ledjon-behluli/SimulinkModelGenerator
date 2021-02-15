using System.Collections.Generic;
using System;

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
						Name ""{BlockName}""	
						{properties}
					}}";
		}
	}

	public class InstanceData
	{
		public List<Parameter> P { get; internal set; }
	}
}
