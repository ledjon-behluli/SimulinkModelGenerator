
namespace SimulinkModelGenerator.Models
{
	internal class Parameter
	{
		public string Name { get; set; }
		public string Text { get; set; }

		public override string ToString()
		{
			return $"{Name}\t\t\"{Text}\"";
		}
	}
}
