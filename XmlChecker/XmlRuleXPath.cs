using System;

namespace XmlChecker
{
	public class XmlRuleXPath
	{
		public string Id { get; private set; }

		public string Level { get; private set; }

		public string XPath { get; private set; }

		public string Message { get; private set; }

		public XmlRuleXPath(string[] line)
		{
			if (line == null || line.Length != 4)
			{
				throw new Exception();
			}

			this.Id = line[0];
			this.Level = line[1];
			this.XPath = line[2];
			this.Message = line[3];
		}
	}
}
