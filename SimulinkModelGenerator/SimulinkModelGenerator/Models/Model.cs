using System.Collections.Generic;

namespace SimulinkModelGenerator.Models
{
	public class Model
	{
		public List<Parameter> P { get; internal set; }
		public System System { get; internal set; }
		public ConfigSet ConfigSet { get; internal set; }
		public string Name { get; internal set; }
		public string SimulationMode { get; internal set; }
	}
}
