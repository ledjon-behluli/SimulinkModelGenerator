using System.Collections.Generic;

namespace SimulinkModelGenerator.Models
{
	public class Model
	{
		public List<Parameter> P { get; set; }
		public System System { get; set; }
		public string Name { get; set; }
	}
}
