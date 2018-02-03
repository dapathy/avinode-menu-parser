using System;

namespace MenuParser.Exceptions
{
	/// <summary>
	/// Thrown when the command line arguments used are invalid.
	/// </summary>
	public class InvalidCommandLineArgumentException : Exception
	{
		public InvalidCommandLineArgumentException() { }

		public InvalidCommandLineArgumentException(string message) : base(message) { }

		public InvalidCommandLineArgumentException(string message, Exception innerException) : base(message, innerException) { }
	}
}
