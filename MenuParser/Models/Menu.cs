using System.Collections.Generic;
using System.Xml.Serialization;

namespace MenuParser.Models
{
	/// <summary>
	/// Represents a hierarchical navigational menu.
	/// </summary>
	[XmlRoot("menu")]
	public class Menu
	{
		[XmlElement("item")]
		public List<Item> Items { get; set; }
	}
}
