using System;

namespace MenuParser.Exceptions
{
	public class InvalidCommandLineArgumentException : Exception
	{
		public InvalidCommandLineArgumentException() { }

		public InvalidCommandLineArgumentException(string message) : base(message) { }

		public InvalidCommandLineArgumentException(string message, Exception innerException) : base(message, innerException) { }
	}
}
