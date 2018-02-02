using System.Xml.Serialization;

namespace MenuParser.Models
{
	public class Path
	{
		[XmlAttribute("value")]
		public string Value { get; set; }
	}
}
