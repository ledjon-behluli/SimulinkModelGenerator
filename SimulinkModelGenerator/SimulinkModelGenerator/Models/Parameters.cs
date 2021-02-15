
namespace SimulinkModelGenerator.Models
{
	public class Parameter
	{
		public string Name { get; internal set; }
		public string Text { get; internal set; }

		public override string ToString()
		{
			return $"{Name} \"{Text}\"";
		}
	}
}
