using System.Xml.Serialization;
using System.Collections.Generic;

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
	}


	[XmlRoot(ElementName = "InstanceData")]
	public class InstanceData
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}
}
