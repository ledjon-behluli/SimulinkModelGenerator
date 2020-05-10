using System.Xml.Serialization;
using System.Collections.Generic;
using System;

namespace SimulinkModelGenerator
{
	[XmlRoot(ElementName = "Block")]
	public class Block
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }

		[XmlAttribute(AttributeName = "BlockType")]
		public string BlockType { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "SID")]
		public string SID { get; set; }

		[XmlElement(ElementName = "InstanceData")]
		public InstanceData InstanceData { get; set; }

		public override string ToString()
		{
			string properties = string.Empty;
			foreach(P p in P)
			{
				properties += p.ToString() + Environment.NewLine;
			}

			if(InstanceData != null)
			{
				foreach(P p in InstanceData.P)
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


	[XmlRoot(ElementName = "InstanceData")]
	public class InstanceData
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}
}
