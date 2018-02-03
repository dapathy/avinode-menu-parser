using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MenuParser.Models;

namespace MenuParser
{
	/// <summary>
	/// Parses text files into <see cref="Menu"/> objects.
	/// </summary>
	internal static class FileParser
	{
		internal static Menu Parse(string fileName)
		{
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException($"{fileName} was not found.", fileName);
			}

			var fileStream = new FileStream(fileName, FileMode.Open);
			var reader = XmlReader.Create(fileStream);
			var xmlSerializer = new XmlSerializer(typeof(Menu));
			return xmlSerializer.Deserialize(reader) as Menu;
		}
	}
}
