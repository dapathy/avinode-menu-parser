using System;
using System.IO;
using System.Linq;
using System.Text;
using MenuParser.Exceptions;

namespace MenuParser
{
	/// <summary>
	/// Reads a file name and selected path from the command line and
	/// prints out a menu highlighting the paths matching the selected path.
	/// </summary>
	public class Program
	{
		internal static void Main(string[] args)
		{
			try
			{
				AssertValidCommandLineArguments(args);
				var menu = FileParser.Parse(args[0]);
				MenuPrinter.Print(menu, args[1].Trim());
			}
			catch (InvalidCommandLineArgumentException)
			{
				PrintUsage();
			}
			catch (InvalidMenuException)
			{
				Console.WriteLine("File is not in the proper format.");
				PrintUsage();
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine($"{e.FileName} is not a valid file path.");
				PrintUsage();
			}
			catch (InvalidOperationException)
			{
				Console.WriteLine("File is not in the proper format.");
				PrintUsage();
			}
			catch (Exception)
			{
				Console.WriteLine("An unknown error occurred.");
			}
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
