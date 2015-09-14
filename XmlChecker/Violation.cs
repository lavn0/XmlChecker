namespace XmlChecker
{
	public class Violation
	{
		public string ErrorCode { get; }
		public string Level { get; }
		public string FileName { get; }
		public int StartLineNumber { get; }
		public int StartLinePosition { get; }
		public int EndLineNumber { get; }
		public int EndLinePosition { get; }
		public string Message { get; }

		public Violation(string errorCode, string level, string fileName, int startLineNumber, int startLinePosition, int endLineNumber, int endLinePosition, string message)
		{
			this.ErrorCode = errorCode;
			this.Level = level;
			this.FileName = fileName;
			this.StartLineNumber = startLineNumber;
			this.StartLinePosition = startLinePosition;
			this.EndLineNumber = endLineNumber;
			this.EndLinePosition = endLinePosition;
			this.Message = message;
#if DEBUG
			// レベル定義を無視
			this.Level = "::NOLEVEL::";
#endif
		}
	}
}
