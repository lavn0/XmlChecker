using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using XmlChecker;

namespace XmlCheckerConsole
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
				var message = "ファイルまたはフォルダを指定してください。";
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
			var rules = ruleCsv.Select((strLine, lineNumer) => new XmlRuleXPath(filePath, lineNumer, strLine)).ToList();

			var violations = ViolationUtility.GetVioltations(files, rules);

			foreach (var rule in rules.Where(r => !r.IsValid.GetValueOrDefault(true)))
			{
				Debug.WriteLine("ルールID={0} が異常終了しました。{1}", rule.Id, rule.XPathErrorMessage);
				Console.WriteLine("ルールID={0} が異常終了しました。{1}", rule.Id, rule.XPathErrorMessage);
			}

			var groupedViolations = violations
				.OrderBy(r => r.Level)
				.ThenBy(r => r.FileName)
				.ThenBy(r => r.StartLineNumber)
				.ThenBy(r => r.StartLinePosition)
				.ThenBy(r => r.ErrorCode)
				.GroupBy(r => r.Level);

			foreach (var item in groupedViolations)
			{
				Debug.WriteLine(string.Format("■レベル {0} の結果", item.Key));
				Console.WriteLine(string.Format("■レベル {0} の結果", item.Key));

				foreach (var result in item)
				{
					Debug.WriteLine("{0}({1},{2}): {3} {4} {5}", result.FileName, result.StartLineNumber, result.StartLinePosition, result.ErrorCode, result.Level, result.Message);
					Console.WriteLine("{0}({1},{2}): {3} {4} {5}", result.FileName, result.StartLineNumber, result.StartLinePosition, result.ErrorCode, result.Level, result.Message);
				}

				Debug.WriteLine("");
				Console.WriteLine("");
			}

			Debug.WriteLine("");
			Console.WriteLine("");

			// ■サマリーの出力
			var summaryMessage = string.Format(
				"  Summary:  Total:{0}, {1}",
				violations.Count,
				string.Join(", ", groupedViolations.Select(p => string.Format("{0}:{1}", p.Key, p.Count()))));

			Console.WriteLine(summaryMessage);
			Console.WriteLine(summaryMessage);

			foreach (var errorCode in rules.Select(e => e.Id))
			{
				Debug.WriteLine("    {0}: {1}", errorCode, violations.Count(r => r.ErrorCode == errorCode));
				Console.WriteLine("    {0}: {1}", errorCode, violations.Count(r => r.ErrorCode == errorCode));
			}
		}
	}
}
