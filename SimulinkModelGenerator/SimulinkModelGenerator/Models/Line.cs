using System.Xml.Serialization;
using System.Collections.Generic;
using System;

namespace SimulinkModelGenerator
{
	[XmlRoot(ElementName = "Line")]
	public class Line : IEqualityComparer<Line>
	{	
		public Line()
		{
			Branch = new List<Branch>();
			P = new List<P>();
		}

		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }

		[XmlElement(ElementName = "Branch")]
		public List<Branch> Branch { get; set; }

		public override string ToString()
		{
			string properties = string.Empty;
			foreach (P p in P)
			{
				properties += p.ToString() + Environment.NewLine;
			}

			string branches = string.Empty;
			foreach(Branch b in Branch)
			{
				branches += b.ToString() + Environment.NewLine;
			}

			return $@"Line {{
						{properties}
						{branches}	
					}}";
		}

		public bool Equals(Line x, Line y)
		{
			string x_srcBlockName = x.P.Find(p => p.Name == "SrcBlock")?.Text;
			string x_dstBlockName = x.P.Find(p => p.Name == "DstBlock")?.Text;
			string x_srcBlockPort = x.P.Find(p => p.Name == "SrcPort")?.Text;
			string x_dstBlockPort = x.P.Find(p => p.Name == "DstBlock")?.Text;

			string y_srcBlockName = y.P.Find(p => p.Name == "SrcBlock")?.Text;
			string y_dstBlockName = y.P.Find(p => p.Name == "DstBlock")?.Text;
			string y_srcBlockPort = y.P.Find(p => p.Name == "SrcPort")?.Text;
			string y_dstBlockPort = y.P.Find(p => p.Name == "DstBlock")?.Text;

			if (!string.IsNullOrEmpty(x_srcBlockName) && !string.IsNullOrEmpty(y_srcBlockName)
				&& !string.IsNullOrEmpty(x_dstBlockName) && !string.IsNullOrEmpty(y_dstBlockName)
				&& !string.IsNullOrEmpty(x_srcBlockPort) && !string.IsNullOrEmpty(y_srcBlockPort)
				&& !string.IsNullOrEmpty(x_dstBlockPort) && !string.IsNullOrEmpty(y_dstBlockPort))
			{
				if (x_srcBlockName == y_srcBlockName && x_dstBlockName == y_dstBlockName
					&& x_srcBlockPort == y_srcBlockPort && x_dstBlockPort == y_dstBlockPort)
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

		public override string ToString()
		{
			string properties = string.Empty;
			foreach (P p in P)
			{
				properties += p.ToString() + Environment.NewLine;
			}

			return $@"Branch {{
						{properties}
					}}";
		}
	}
}
