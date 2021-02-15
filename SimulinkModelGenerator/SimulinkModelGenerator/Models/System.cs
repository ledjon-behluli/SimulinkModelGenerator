using System.Collections.Generic;

namespace SimulinkModelGenerator.Models
{
	public class System
	{
		public List<Parameter> P { get; internal set; }
		public List<Block> Block { get; internal set; }
		public List<Line> Line { get; internal set; }
	}
}
