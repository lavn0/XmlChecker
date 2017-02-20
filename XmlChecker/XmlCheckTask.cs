using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;

namespace XmlChecker
{
	public class XmlCheckTask : Task
	{
		/// <summary>MSBuildプロセスで検証対象のファイル名を渡す</summary>
		public string[] TargetFiles { get; set; }

		/// <summary>MSBuildプロセスでCSVルールファイル名を渡す</summary>
		public string[] RuleFiles { get; set; }

		/// <summary>Error扱いとするレベル（その他はすべてWarning）</summary>
		public string[] ErrorLevels { get; set; }

		public override bool Execute()
		{
			if (RuleFiles == null)
			{
				Log.LogError("RuleFiles が指定されていません。");
				return false;
			}

			var notExistRuleFile = RuleFiles.Where(f => !File.Exists(f)).ToList();
			if (notExistRuleFile.Any())
			{
				Log.LogError("次の RuleFile が見つかりませんでした。" + string.Join(",", notExistRuleFile));
				return false;
			}

			if (TargetFiles == null)
			{
				Log.LogError("TargetFiles が指定されていません。");
				return false;
			}

			var notExistFiles = TargetFiles.Where(f => !File.Exists(f)).ToList();
			if (notExistFiles.Any())
			{
				Log.LogError("次の TargetFile が見つかりませんでした。" + string.Join(",", notExistFiles));
				return false;
			}

			var rules = new List<XmlRuleXPath>();
			foreach (var rule in RuleFiles)
			{
				var ruleStr = File.ReadAllText(rule, Encoding.GetEncoding("SHIFT_JIS"));
				var ruleCsv = CsvParser.Parse(ruleStr).ToList();
				var ruleXPaths = ruleCsv.Select((strLine, lineNumber) => new XmlRuleXPath(rule, lineNumber, strLine)).ToList();
				rules.AddRange(ruleXPaths);
			}

			var violations = ViolationUtility.GetVioltations(TargetFiles, rules);

			foreach (var rule in rules.Where(r => !r.IsValid.GetValueOrDefault(true)))
			{
				Log.LogError("category", "R00000", "helpKeyword", rule.File, rule.LineNumber + 1, 0, rule.LineNumber + 1, 0, "ルールID={0} が異常終了しました。{1}", rule.Id, rule.XPathErrorMessage);
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
				foreach (var result in item)
				{
					var message = string.Format("{0}({1},{2}): {3} {4} {5}", result.FileName, result.StartLineNumber, result.StartLinePosition, result.ErrorCode, result.Level, result.Message);

					if (ErrorLevels.Contains(result.Level))
					{
						Log.LogWarning(result.Level, result.ErrorCode, "ヘルプキーワード", result.FileName, result.StartLineNumber, result.StartLinePosition, result.EndLineNumber, result.EndLinePosition, result.ErrorCode + ":" + result.Message);
					}
					else
					{
						Log.LogError(result.Level, result.ErrorCode, "ヘルプキーワード", result.FileName, result.StartLineNumber, result.StartLinePosition, result.EndLineNumber, result.EndLinePosition, result.ErrorCode + ":" + result.Message);
					}
				}
			}

			return true;
		}
	}
}
