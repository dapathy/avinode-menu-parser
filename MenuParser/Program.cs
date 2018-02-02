using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using MenuParser.Models;

namespace MenuParser
{
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				AssertValidCommandLineArguments(args);
				var menu = ParseFile(args[0]);

			}
			catch (Exception e)
			{

			}
		}

		private static Menu ParseFile(string fileName)
		{
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException($"{fileName} was not found.", fileName);
			}

			var fs = new FileStream(fileName, FileMode.Open);
			var reader = XmlReader.Create(fs);
			var xmlSerializer = new XmlSerializer(typeof(Menu));
			return xmlSerializer.Deserialize(reader) as Menu;
		}

		private static void AssertValidCommandLineArguments(string[] args)
		{
			if (args == null) throw new ArgumentNullException(nameof(args));

			if (args.Length != 2)
			{
				throw new InvalidOperationException($"{nameof(MenuParser)} requires two arguments.");
			}

			if (args.Any(string.IsNullOrWhiteSpace))
			{
				throw new InvalidOperationException("Arguments are not valid.");
			}
		}
	}
}
