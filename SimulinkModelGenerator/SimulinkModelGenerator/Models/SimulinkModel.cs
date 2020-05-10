using System.Xml.Serialization;
using System.Collections.Generic;

namespace SimulinkModelGenerator
{
	[XmlRoot(ElementName = "P")]
	public class P
	{
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlText]
		public string Text { get; set; }

		public override string ToString()
		{
			return $"{Name} \"{Text}\"";
		}
	}

	[XmlRoot(ElementName = "System")]
	public class System
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }

		[XmlElement(ElementName = "Block")]
		public List<Block> Block { get; set; }

		[XmlElement(ElementName = "Line")]
		public List<Line> Line { get; set; }
	}

	[XmlRoot(ElementName = "Model")]
	public class Model
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }

		[XmlElement(ElementName = "System")]
		public System System { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
	}
}
