using System.IO;
using MenuParser.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuParser.Tests
{
	[TestClass]
	public class MenuParserTests
	{
		[TestMethod]
		public void ShoudParseSchedAeroFile()
		{

			const string expectedOutput = @"Home, /Default.aspx
Trips, /Requests/Quotes/CreateQuote.aspx ACTIVE
		Create Quote, /Requests/Quotes/CreateQuote.aspx
		Open Quotes, /Requests/OpenQuotes.aspx ACTIVE
		Scheduled Trips, /Requests/Trips/ScheduledTrips.aspx
Company, /mvc/company/view
		Customers, /customers/customers.aspx
		Pilots, /pilots/pilots.aspx
		Aircraft, /aircraft/Aircraft.aspx
";

			var file = new FileInfo($"{Constants.SampleFilesDirectory}/{Constants.SchedAero}");

			using (var consoleOutput = new ConsoleOutput())
			{
				Program.Main(new[] { file.FullName, "/Requests/OpenQuotes.aspx" });
				Assert.AreEqual(expectedOutput, consoleOutput.GetOuput());
			}
		}

		[TestMethod]
		public void ShoudParseWyvernFile()
		{

			const string expectedOutput = @"Home, /mvc/wyvern/home ACTIVE
		News, /mvc/wyvern/home/news
		Directory, /Directory/Directory.aspx ACTIVE
				Favorites, /TWR/Directory.aspx
				Search Aircraft, /TWR/AircraftSearch.aspx ACTIVE
PASS, /PASS/GeneratePASS.aspx
		Create New, /PASS/GeneratePASS.aspx
		Sent Requests, /PASS/YourPASSReports.aspx
		Received Requests, /PASS/Pending/PendingRequests.aspx
Company, /mvc/company/view
		Users, /mvc/account/list
		Aircraft, /aircraft/fleet.aspx
		Insurance, /insurance/policies.aspx
		Certificate, /Certificates/Certificates.aspx
";

			var file = new FileInfo($"{Constants.SampleFilesDirectory}/{Constants.Wyvern}");

			using (var consoleOutput = new ConsoleOutput())
			{
				Program.Main(new[] { file.FullName, "/TWR/AircraftSearch.aspx" });
				Assert.AreEqual(expectedOutput, consoleOutput.GetOuput());
			}
		}

		[TestMethod]
		public void ShouldPrintUsage_WhenInvalidArguments()
		{
			const string expectedOutput = "MenuParser requires two arguments";

			using (var consoleOutput = new ConsoleOutput())
			{
				Program.Main(new[] { string.Empty, string.Empty });
				Assert.IsTrue(consoleOutput.GetOuput().StartsWith(expectedOutput));
			}
		}
	}
}
