using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlChecker
{
	public static class CsvParser
	{
		public static List<string[]> Parse(string ruleStr)
		{
			return ParseCore(ruleStr).ToList();
		}

		private static IEnumerable<string[]> ParseCore(string ruleStr)
		{
			using (var sr = new MemoryStream(Encoding.UTF8.GetBytes(ruleStr)))
			using (var parser = new TextFieldParser(sr))
			{
				parser.SetDelimiters(","); // 区切り文字はコンマ

				while (!parser.EndOfData)
				{
					string[] row = parser.ReadFields(); // 1行読み込み
					yield return row;
				}
			}
		}
	}
}
