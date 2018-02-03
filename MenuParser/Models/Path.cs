using System.Xml.Serialization;

namespace MenuParser.Models
{
	/// <summary>
	/// A navigational route.
	/// </summary>
	public class Path
	{
		[XmlAttribute("value")]
		public string Value { get; set; }
	}
}
