using System.Collections.Generic;
using System.Xml.Serialization;

namespace MenuParser.Models
{
	/// <summary>
	/// Represents a single navigational route.
	/// </summary>
	public class Item
	{
		[XmlElement("displayName")]
		public string DisplayName { get; set; }

		[XmlElement("path")]
		public Path Path { get; set; }

		[XmlElement("subMenu")]
		public Menu SubMenu { get; set; }
	}
}
