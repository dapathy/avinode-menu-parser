using System;

namespace MenuParser.Exceptions
{
	/// <summary>
	/// Thrown when the file contents do not match the expected format.
	/// </summary>
	public class InvalidMenuException : Exception
	{
		public InvalidMenuException() { }

		public InvalidMenuException(string message) : base(message) { }

		public InvalidMenuException(string message, Exception innerException) : base(message, innerException) { }
	}
}
