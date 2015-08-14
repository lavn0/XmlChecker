using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XmlChecker
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				Run(args[0]);
				return;
			}
			else
			{
				var message = "引き数にファイルまたはフォルダを指定してください。";
				Debug.WriteLine(message);
				Console.WriteLine();
			}
		}

		private static void Run(string argumentPath)
		{
			if (!Path.IsPathRooted(argumentPath))
			{
				Debug.WriteLine(argumentPath + " は不正なパスです。");
				Console.WriteLine(argumentPath + " は不正なパスです。");
				return;
			}

			string[] files;

			if (Directory.Exists(argumentPath))
			{
				Console.WriteLine(argumentPath + " ディレクトリ以下のファイルを探索中です・・・");
				files = Directory.GetFiles(argumentPath, "*.xaml", SearchOption.AllDirectories);
				Console.WriteLine(argumentPath + " ディレクトリ以下の '*.xaml' ファイルが " + files.Length + " 見つかりました。");
			}
			else if (File.Exists(argumentPath))
			{
				files = new[] { argumentPath };
			}
			else
			{
				Debug.WriteLine(argumentPath + " のディレクトリ、ファイルが見つかりません。");
				Console.WriteLine(argumentPath + " のディレクトリ、ファイルが見つかりません。");
				return;
			}

			Console.WriteLine();
			Console.WriteLine("チェックを開始します…");
			Console.WriteLine();

			var filePath = "Rule.csv";

			if (!File.Exists(filePath))
			{
				Debug.WriteLine("ルールファイル({0})が見つかりませんでした。", filePath);
				Console.WriteLine("ルールファイル({0})が見つかりませんでした。", filePath);
				return;
			}

			var ruleStr = File.ReadAllText(filePath, Encoding.GetEncoding("SHIFT_JIS"));
			var ruleCsv = CsvParser.Parse(ruleStr).ToList();
			var rules = ruleCsv.Select(l => new XmlRuleXPath(l)).ToList();

			var results = new List<Violation>();

			foreach (var file in files)
			{
				foreach (var rule in rules)
				{
					var xaml = XDocument.Load(file, LoadOptions.SetLineInfo | LoadOptions.PreserveWhitespace);
					var violations = rule.GetViolatedElements(xaml);

					foreach (var violation in violations)
					{
						var info = violation as IXmlLineInfo;
						results.Add(new Violation(rule.Id, rule.Level, file, info.LineNumber, info.LinePosition, rule.Message));
					}
				}
			}

			foreach (var rule in rules.Where(r => !r.IsValid.GetValueOrDefault(true)))
			{
				Debug.WriteLine("ルールID={0} が異常終了しました。{1}", rule.Id, rule.XPathErrorMessage);
				Console.WriteLine("ルールID={0} が異常終了しました。{1}", rule.Id, rule.XPathErrorMessage);
			}

			var dic = 結果整理(results);

			foreach (var level in dic.Keys.OrderBy(k => k))
			{
				Debug.WriteLine("■レベル {0} の結果", level);
				Console.WriteLine("■レベル {0} の結果", level);

				foreach (var result in dic[level])
				{
					Debug.WriteLine("{0}({1},{2}): {3} {4} {5}", result.FileName, result.LineNumber, result.LinePosition, result.ErrorCode, result.Level, result.Message);
					Console.WriteLine("{0}({1},{2}): {3} {4} {5}", result.FileName, result.LineNumber, result.LinePosition, result.ErrorCode, result.Level, result.Message);
				}

				Debug.WriteLine("");
				Console.WriteLine("");
			}

			Debug.WriteLine("");
			Console.WriteLine("");


			var summary = string.Join(", ", dic.Select(p => string.Format("{0}:{1}", p.Key, p.Value.Count)));

			Debug.WriteLine("  Summary:  Total:{0}, {1}", results.Count, summary);
			Console.WriteLine("  Summary:  Total:{0}, {1}", results.Count, summary);

			foreach (var errorCode in results.Select(r => r.ErrorCode).Distinct().OrderBy(e => e))
			{
				Debug.WriteLine("    {0}: {1}", errorCode, results.Count(r => r.ErrorCode == errorCode));
				Console.WriteLine("    {0}: {1}", errorCode, results.Count(r => r.ErrorCode == errorCode));
			}
		}

		private static Dictionary<string, List<Violation>> 結果整理(List<Violation> results)
		{
			var dic = new Dictionary<string, List<Violation>>();
			foreach (var result in results)
			{
				List<Violation> ls;
				if (!dic.TryGetValue(result.Level, out ls))
				{
					ls = new List<Violation>();
					dic[result.Level] = ls;
				}

				ls.Add(result);
			}

			return dic;
		}
	}
}
