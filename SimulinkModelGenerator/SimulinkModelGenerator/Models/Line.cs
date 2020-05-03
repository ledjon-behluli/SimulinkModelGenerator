using System.Xml.Serialization;
using System.Collections.Generic;

namespace SimulinkModelGenerator
{
	[XmlRoot(ElementName = "Line")]
	public class Line : IEqualityComparer<Line>
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }

		[XmlElement(ElementName = "Branch")]
		public List<Branch> Branch { get; set; }

		public bool Equals(Line x, Line y)
		{
			string x_srcBlock = x.P.Find(p => p.Name == "SrcBlock").Text;
			string x_dstBlock = x.P.Find(p => p.Name == "DstBlock").Text;

			string y_srcBlock = y.P.Find(p => p.Name == "SrcBlock").Text;
			string y_dstBlock = y.P.Find(p => p.Name == "DstBlock").Text;

			if(!string.IsNullOrEmpty(x_srcBlock) && !string.IsNullOrEmpty(y_srcBlock) 
				&& !string.IsNullOrEmpty(x_dstBlock) && !string.IsNullOrEmpty(y_dstBlock))
			{
				if(x_srcBlock == y_srcBlock && x_dstBlock == y_dstBlock)
				{
					return true;
				}
			}

			return false;
		}

		public int GetHashCode(Line obj)
		{
			return obj.ToString().ToLower().GetHashCode();
		}
	}

	[XmlRoot(ElementName = "Branch")]
	public class Branch
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}
}
