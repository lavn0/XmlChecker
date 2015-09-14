using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XmlChecker
{
	public class XmlRuleXPath
	{
		public string File { get; }
		public int LineNumber { get; }
		public string Id { get; }
		public string Level { get; }
		public string XPath { get; }
		public string Message { get; }
		public bool? IsValid { get; private set; }
		public string XPathErrorMessage { get; private set; }

		public XmlRuleXPath(string file, int lineNumber, string[] line)
		{
			if (line == null || line.Length != 4)
			{
				throw new Exception();
			}

			this.File = file;
			this.LineNumber = lineNumber;
			this.Id = line[0];
			this.Level = line[1];
			this.XPath = line[2];
			this.Message = line[3];
		}

		public List<XObject> GetViolatedElements(XDocument xDocument)
		{
			if (this.IsValid.GetValueOrDefault(true))
			{
				try
				{
					var evaluateResult = xDocument.XPathEvaluate(this.XPath) as IEnumerable<object>;
					var result = evaluateResult.Cast<XObject>().ToList();
					this.IsValid = true;
					return result;
				}
				catch (XPathException ex)
				{
					this.IsValid = false;
					this.XPathErrorMessage = ex.Message;
				}
			}

			return new List<XObject>();
		}
	}
}
