namespace XmlChecker
{
	public class Violation
	{
		public string ErrorCode { get; }
		public string Level { get; }
		public string FileName { get; }
		public int LineNumber { get; }
		public int LinePosition { get; }
		public string Message { get; }

		public Violation(string errorCode, string level, string fileName, int lineNumber, int linePosition, string message)
		{
			this.ErrorCode = errorCode;
			this.Level = level;
			this.FileName = fileName;
			this.LineNumber = lineNumber;
			this.LinePosition = linePosition;
			this.Message = message;
		}
	}
}
