using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XmlChecker
{
	public static class ViolationUtility
	{
		public static List<Violation> GetVioltations(string[] files, List<XmlRuleXPath> rules)
		{
			var results = new List<Violation>();

			foreach (var file in files)
			{
				foreach (var rule in rules)
				{
					var xaml = XDocument.Load(file, LoadOptions.SetLineInfo | LoadOptions.PreserveWhitespace);
					var violatedObjects = rule.GetViolatedElements(xaml);

					foreach (IXmlLineInfo info in violatedObjects)
					{
						var xml = info.ToString();
						var endLineNumber = info.LineNumber + xml.Count(c => c == '\n');
						var endLinePosition = xml.Any(c => c == '\n') ? info.ToString().Substring(xml.LastIndexOf('\n')).Length : info.LinePosition + xml.Length;

						results.Add(new Violation(rule.Id, rule.Level, file, info.LineNumber, info.LinePosition, endLineNumber, endLinePosition, rule.Message));
					}
				}
			}

			return results;
		}
	}
}
