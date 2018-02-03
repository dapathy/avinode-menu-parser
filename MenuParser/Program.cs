using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MenuParser.Exceptions;
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
				PrintMenu(menu, args[1].Trim());
			}
			catch (InvalidCommandLineArgumentException)
			{
				PrintUsage();
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine($"{e.FileName} is not a valid file path.");
				PrintUsage();
			}
			catch (Exception)
			{
				Console.WriteLine("An unknown error occurred.");
			}
		}

		private static void PrintMenu(Menu menu, string pathToMatch, int indentCount = 0)
		{
			foreach (var item in menu.Items)
			{
				PrintItem(item, pathToMatch, indentCount);
			}
		}

		private static void PrintItem(Item item, string pathToMatch, int indentCount = 0)
		{
			const string active = " ACTIVE";
			var spaces = new string('\t', indentCount);
			var activeStatus = IsActive(item, pathToMatch) ? active : string.Empty;
			Console.WriteLine($"{spaces}{item.DisplayName}, {item.Path.Value}{activeStatus}");
			if (item.SubMenu != null)
			{
				PrintMenu(item.SubMenu, pathToMatch, indentCount + 2);
			}
		}

		private static bool IsActive(Item item, string pathToMatch)
		{
			if (item.Path.Value == pathToMatch) return true;

			if (item.SubMenu == null) return false;
			foreach (var subItem in item.SubMenu.Items)
			{
				if (IsActive(subItem, pathToMatch)) return true;
			}

			return false;
		}

		private static Menu ParseFile(string fileName)
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

		private static void PrintUsage()
		{
			var usage = new StringBuilder();
			usage.AppendLine($"{nameof(MenuParser)} requires two arguments:");
			usage.AppendLine("First, a path to the menu XML file");
			usage.AppendLine("Second, an active path to match");
			usage.AppendLine($"Example:  {nameof(MenuParser)}.exe \"c:\\schedaeromenu.xml\" \"/default.aspx\"");
			Console.WriteLine(usage.ToString());
		}

		private static void AssertValidCommandLineArguments(string[] args)
		{
			if (args == null) throw new InvalidCommandLineArgumentException();

			if (args.Length != 2)
			{
				throw new InvalidCommandLineArgumentException();
			}

			if (args.Any(string.IsNullOrWhiteSpace))
			{
				throw new InvalidCommandLineArgumentException();
			}
		}
	}
}
