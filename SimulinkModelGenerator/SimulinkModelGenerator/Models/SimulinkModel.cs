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

		[XmlAttribute(AttributeName = "Class")]
		public string Class { get; set; }
	}

	[XmlRoot(ElementName = "GraphicalInterface")]
	public class GraphicalInterface
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "Object")]
	public class Object
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }

		[XmlAttribute(AttributeName = "PropName")]
		public string PropName { get; set; }

		[XmlAttribute(AttributeName = "ObjectID")]
		public string ObjectID { get; set; }

		[XmlAttribute(AttributeName = "ClassName")]
		public string ClassName { get; set; }

		[XmlElement(ElementName = "Array")]
		public List<Array> Array { get; set; }

		[XmlAttribute(AttributeName = "Version")]
		public string Version { get; set; }

		[XmlAttribute(AttributeName = "Reference")]
		public string Reference { get; set; }
	}

	[XmlRoot(ElementName = "ConfigManagerSettings")]
	public class ConfigManagerSettings
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "EditorSettings")]
	public class EditorSettings
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "Cell")]
	public class Cell
	{
		[XmlAttribute(AttributeName = "Class")]
		public string Class { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Array")]
	public class Array
	{
		[XmlElement(ElementName = "Cell")]
		public Cell Cell { get; set; }

		[XmlAttribute(AttributeName = "PropName")]
		public string PropName { get; set; }

		[XmlAttribute(AttributeName = "Type")]
		public string Type { get; set; }

		[XmlAttribute(AttributeName = "Dimension")]
		public string Dimension { get; set; }

		[XmlElement(ElementName = "Object")]
		public Object Object { get; set; }
	}

	[XmlRoot(ElementName = "SimulationSettings")]
	public class SimulationSettings
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }

		[XmlElement(ElementName = "Object")]
		public Object Object { get; set; }
	}

	[XmlRoot(ElementName = "ExternalMode")]
	public class ExternalMode
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "ModelReferenceSettings")]
	public class ModelReferenceSettings
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "ConfigurationSet")]
	public class ConfigurationSet
	{
		[XmlElement(ElementName = "Array")]
		public Array Array { get; set; }

		[XmlElement(ElementName = "Object")]
		public Object Object { get; set; }
	}

	[XmlRoot(ElementName = "ConcurrentExecutionSettings")]
	public class ConcurrentExecutionSettings
	{
		[XmlElement(ElementName = "Object")]
		public Object Object { get; set; }

		[XmlElement(ElementName = "P")]
		public P P { get; set; }
	}

	[XmlRoot(ElementName = "SystemDefaults")]
	public class SystemDefaults
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "BlockDefaults")]
	public class BlockDefaults
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "AnnotationDefaults")]
	public class AnnotationDefaults
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "LineDefaults")]
	public class LineDefaults
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "MaskDefaults")]
	public class MaskDefaults
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "MaskParameterDefaults")]
	public class MaskParameterDefaults
	{
		[XmlElement(ElementName = "P")]
		public List<P> P { get; set; }
	}

	[XmlRoot(ElementName = "BlockParameterDefaults")]
	public class BlockParameterDefaults
	{
		[XmlElement(ElementName = "Block")]
		public List<Block> Block { get; set; }
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

		[XmlElement(ElementName = "GraphicalInterface")]
		public GraphicalInterface GraphicalInterface { get; set; }

		[XmlElement(ElementName = "Object")]
		public Object Object { get; set; }

		[XmlElement(ElementName = "ConfigManagerSettings")]
		public ConfigManagerSettings ConfigManagerSettings { get; set; }

		[XmlElement(ElementName = "EditorSettings")]
		public EditorSettings EditorSettings { get; set; }

		[XmlElement(ElementName = "SimulationSettings")]
		public SimulationSettings SimulationSettings { get; set; }

		[XmlElement(ElementName = "ExternalMode")]
		public ExternalMode ExternalMode { get; set; }

		[XmlElement(ElementName = "ModelReferenceSettings")]
		public ModelReferenceSettings ModelReferenceSettings { get; set; }

		[XmlElement(ElementName = "ConfigurationSet")]
		public ConfigurationSet ConfigurationSet { get; set; }

		[XmlElement(ElementName = "ConcurrentExecutionSettings")]
		public ConcurrentExecutionSettings ConcurrentExecutionSettings { get; set; }

		[XmlElement(ElementName = "SystemDefaults")]
		public SystemDefaults SystemDefaults { get; set; }

		[XmlElement(ElementName = "BlockDefaults")]
		public BlockDefaults BlockDefaults { get; set; }

		[XmlElement(ElementName = "AnnotationDefaults")]
		public AnnotationDefaults AnnotationDefaults { get; set; }

		[XmlElement(ElementName = "LineDefaults")]
		public LineDefaults LineDefaults { get; set; }

		[XmlElement(ElementName = "MaskDefaults")]
		public MaskDefaults MaskDefaults { get; set; }

		[XmlElement(ElementName = "MaskParameterDefaults")]
		public MaskParameterDefaults MaskParameterDefaults { get; set; }

		[XmlElement(ElementName = "BlockParameterDefaults")]
		public BlockParameterDefaults BlockParameterDefaults { get; set; }

		[XmlElement(ElementName = "System")]
		public System System { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
	}
}
