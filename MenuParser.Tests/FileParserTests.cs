using System.IO;
using MenuParser.Models;
using MenuParser.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuParser.Tests
{
	[TestClass]
	public class FileParserTests
	{

		[TestMethod]
		public void ShouldParseFile()
		{
			var file = new FileInfo($"{Constants.SampleFilesDirectory}/{Constants.SchedAero}");
			var menu = FileParser.Parse(file.FullName);
			Assert.AreEqual(typeof(Menu), menu.GetType());
		}

		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]
		public void ShouldThrowException_WhenFileNotFound()
		{
			FileParser.Parse("somefilename");
		}
	}
}
