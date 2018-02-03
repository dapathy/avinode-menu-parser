using System;

namespace MenuParser.Exceptions
{
	/// <summary>
	/// Thrown when the file contents do not match the expected format.
	/// </summary>
	public class InvalidMenuFileException : Exception
	{
		public InvalidMenuFileException() { }

		public InvalidMenuFileException(string message) : base(message) { }

		public InvalidMenuFileException(string message, Exception innerException) : base(message, innerException) { }
	}
}
