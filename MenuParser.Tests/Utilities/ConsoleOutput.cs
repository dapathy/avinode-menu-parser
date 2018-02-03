using System;
using System.IO;

namespace MenuParser.Tests.Utilities
{
	/// <summary>
	/// Assists in retrieving output from the console.
	/// </summary>
	/// <remarks>
	/// Modified from https://stackoverflow.com/questions/2139274/grabbing-the-output-sent-to-console-out-from-within-a-unit-test
	/// </remarks>
	public class ConsoleOutput : IDisposable
	{
		private readonly StringWriter _stringWriter;
		private readonly TextWriter _originalOutput;

		public ConsoleOutput()
		{
			_stringWriter = new StringWriter();
			_originalOutput = Console.Out;
			Console.SetOut(_stringWriter);
		}

		public string GetOuput()
		{
			return _stringWriter.ToString();
		}

		public void Dispose()
		{
			Console.SetOut(_originalOutput);

			// Write output back to original writer.
			Console.Write(_stringWriter);
			_stringWriter.Dispose();
		}
	}
}
