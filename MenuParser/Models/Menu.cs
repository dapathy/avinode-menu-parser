using System.Collections.Generic;
using System.Xml.Serialization;

namespace MenuParser.Models
{
	[XmlRoot("menu")]
	public class Menu
	{
		[XmlElement("item")]
		public List<Item> Items { get; set; }
	}
}
