using Microsoft.Build.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Text;

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

			var ruleStr = string.Join(Environment.NewLine, RuleFiles.Select(f => File.ReadAllText(f, Encoding.GetEncoding("SHIFT_JIS"))));
			var ruleCsv = CsvParser.Parse(ruleStr).ToList();
			var rules = ruleCsv.Select(l => new XmlRuleXPath(l)).ToList();
			var violations = ViolationUtility.GetVioltations(TargetFiles, rules);

			foreach (var rule in rules.Where(r => !r.IsValid.GetValueOrDefault(true)))
			{
				Log.LogError("ルールID={0} が異常終了しました。{1}", rule.Id, rule.XPathErrorMessage);
				return false;
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
