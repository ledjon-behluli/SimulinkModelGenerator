using System.Collections.Generic;
using System;
using System.Text;

namespace SimulinkModelGenerator.Models
{
	public class Line : IEqualityComparer<Line>
	{	
		public Line()
		{
			Branch = new List<Branch>();
			P = new List<Parameter>();
		}

		public List<Parameter> P { get; internal set; }
		public List<Branch> Branch { get; internal set; }

		public override string ToString()
		{
			string properties = string.Empty;
			foreach (Parameter p in P)
			{
				properties += $"\t\t\t{p.ToString() + Environment.NewLine}";
			}

			string branches = string.Empty;
			foreach(Branch b in Branch)
			{
				branches += b.ToString() + Environment.NewLine;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("\t\tLine {");
			sb.Append(Environment.NewLine);
			sb.Append(properties);
			sb.Append(branches);
			sb.Append("\t\t}");

			return sb.ToString();
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

	public class Branch
	{
		public List<Parameter> P { get; internal set; }

		public override string ToString()
		{
			string properties = string.Empty;
			foreach (Parameter p in P)
			{
				properties += $"\t\t\t\t{p.ToString() + Environment.NewLine}";
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("\t\t\tBranch {");
			sb.Append(Environment.NewLine);
			sb.Append(properties);
			sb.Append("\t\t\t}");

			return sb.ToString();
		}
	}
}
