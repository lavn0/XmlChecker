using System.Collections.Generic;
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
						results.Add(new Violation(rule.Id, rule.Level, file, info.LineNumber, info.LinePosition, rule.Message));
					}
				}
			}

			return results;
		}
	}
}
