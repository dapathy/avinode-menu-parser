using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuParser.Tests
{
	[TestClass]
	public class MenuParserTests
	{
		private const string SampleFileDirectory = "SampleFiles";

		[TestMethod]
		public void ShoudParseSchedAeroFile()
		{
			const string fileName = "SchedAero Menu.txt";

			var file = new FileInfo($"{SampleFileDirectory}/{fileName}");
			Program.Main(new []{ file.FullName, "/Requests/OpenQuotes.aspx" });
		}

		[TestMethod]
		public void ShoudParseWyvernFile()
		{
			const string fileName = "Wyvern Menu.txt";

			var file = new FileInfo($"{SampleFileDirectory}/{fileName}");
			Program.Main(new[] { file.FullName, "/TWR/AircraftSearch.aspx" });
		}
	}
}
