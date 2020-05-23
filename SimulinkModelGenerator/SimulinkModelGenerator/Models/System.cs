using System.Collections.Generic;

namespace SimulinkModelGenerator.Models
{
	public class System
	{
		public List<Parameter> P { get; set; }
		public List<Block> Block { get; set; }
		public List<Line> Line { get; set; }
	}
}
