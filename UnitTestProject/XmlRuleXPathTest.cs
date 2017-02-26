using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlChecker;

namespace UnitTestProject
{
	[TestClass]
	public class XmlRuleXPathTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0001_OK.xaml", "Resources")]
		public void XA0001_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0001", "Info", @"//@*[starts-with(.,'{Binding ')][contains(.,'Mode=OneWay')]", @"OneWayバインディングはデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0001_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0001_NG1.xaml", "Resources")]
		public void XA0001_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0001", "Info", @"//@*[starts-with(.,'{Binding ')][contains(.,'Mode=OneWay')]", @"OneWayバインディングはデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0001_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0002_OK.xaml", "Resources")]
		public void XA0002_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0002", "Info", @"//@*[contains(.,'TargetNullValue')]", @"TargetNullValueは使用しないでください。", });
			var xaml = File.ReadAllText(@"Resources\XA0002_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0002_NG1.xaml", "Resources")]
		public void XA0002_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0002", "Info", @"//@*[contains(.,'TargetNullValue')]", @"TargetNullValueは使用しないでください。", });
			var xaml = File.ReadAllText(@"Resources\XA0002_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0003_OK.xaml", "Resources")]
		public void XA0003_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0003", "Warning", @"//@*[contains(.,'FallbackValue')]", @"FallbackValueが不要な実装を検討してください。FallbackValueが必要なケースは例外発生のケースであり、例外によってパフォーマンス低下が懸念されます。", });
			var xaml = File.ReadAllText(@"Resources\XA0003_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0003_NG1.xaml", "Resources")]
		public void XA0003_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0003", "Warning", @"//@*[contains(.,'FallbackValue')]", @"FallbackValueが不要な実装を検討してください。FallbackValueが必要なケースは例外発生のケースであり、例外によってパフォーマンス低下が懸念されます。", });
			var xaml = File.ReadAllText(@"Resources\XA0003_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0004_OK.xaml", "Resources")]
		public void XA0004_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0004", "Error", @"//@Visibility[.='Collapsed'][not(parent::*/@*[local-name(.)='Name'])]", @"Name属性が無いタグのVisibility属性に""Collapsed""が指定されています。このコントロールは表示されない可能性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0004_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0004_NG1.xaml", "Resources")]
		public void XA0004_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0004", "Error", @"//@Visibility[.='Collapsed'][not(parent::*/@*[local-name(.)='Name'])]", @"Name属性が無いタグのVisibility属性に""Collapsed""が指定されています。このコントロールは表示されない可能性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0004_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0005_OK.xaml", "Resources")]
		public void XA0005_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0005", "Default", @"//@Margin[contains(.,' ')]", @"Margin属性は空白区切りではなく"",""区切りで指定してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0005_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0005_NG3.xaml", "Resources")]
		public void XA0005_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0005", "Default", @"//@Margin[contains(.,' ')]", @"Margin属性は空白区切りではなく"",""区切りで指定してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0005_NG3.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(3, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0006_OK.xaml", "Resources")]
		public void XA0006_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0006", "Default", @"//@Padding[contains(.,' ')]", @"Padding属性は空白区切りではなく"",""区切りで指定してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0006_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0006_NG3.xaml", "Resources")]
		public void XA0006_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0006", "Default", @"//@Padding[contains(.,' ')]", @"Padding属性は空白区切りではなく"",""区切りで指定してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0006_NG3.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(3, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0007_OK.xaml", "Resources")]
		public void XA0007_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0007", "Warning", @"//@Margin[contains(.,'-')]", @"Margin属性にマイナス値があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0007_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0007_NG1.xaml", "Resources")]
		public void XA0007_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0007", "Warning", @"//@Margin[contains(.,'-')]", @"Margin属性にマイナス値があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0007_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0008_OK.xaml", "Resources")]
		public void XA0008_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0008", "Critical", @"//@IsEnabled[contains(.,'TwoWay')]", @"IsEnabledはTwoWayバインディングしないでください。", });
			var xaml = File.ReadAllText(@"Resources\XA0008_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0008_NG1.xaml", "Resources")]
		public void XA0008_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0008", "Critical", @"//@IsEnabled[contains(.,'TwoWay')]", @"IsEnabledはTwoWayバインディングしないでください。", });
			var xaml = File.ReadAllText(@"Resources\XA0008_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0009_OK.xaml", "Resources")]
		public void XA0009_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0009", "Critical", @"//@Visibility[contains(.,'TwoWay')]", @"VisibilityはTwoWayバインディングしないでください。", });
			var xaml = File.ReadAllText(@"Resources\XA0009_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0009_NG1.xaml", "Resources")]
		public void XA0009_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0009", "Critical", @"//@Visibility[contains(.,'TwoWay')]", @"VisibilityはTwoWayバインディングしないでください。", });
			var xaml = File.ReadAllText(@"Resources\XA0009_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0101_OK.xaml", "Resources")]
		public void XA0101_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0101", "Default", @"//*[name(.)='Border']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0101_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0101_NG1.xaml", "Resources")]
		public void XA0101_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0101", "Default", @"//*[name(.)='Border']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0101_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0102_OK.xaml", "Resources")]
		public void XA0102_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0102", "Default", @"//*[name(.)='Border']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0102_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0102_NG1.xaml", "Resources")]
		public void XA0102_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0102", "Default", @"//*[name(.)='Border']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0102_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0103_OK.xaml", "Resources")]
		public void XA0103_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0103", "Default", @"//*[name(.)='Border']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0103_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0103_NG1.xaml", "Resources")]
		public void XA0103_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0103", "Default", @"//*[name(.)='Border']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0103_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0104_OK.xaml", "Resources")]
		public void XA0104_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0104", "Default", @"//*[name(.)='Border']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0104_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0104_NG1.xaml", "Resources")]
		public void XA0104_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0104", "Default", @"//*[name(.)='Border']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0104_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0105_OK.xaml", "Resources")]
		public void XA0105_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0105", "Default", @"//*[name(.)='Border'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0105_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0105_NG5.xaml", "Resources")]
		public void XA0105_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0105", "Default", @"//*[name(.)='Border'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0105_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0106_OK.xaml", "Resources")]
		public void XA0106_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0106", "Default", @"//*[name(.)='Border'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Padding=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0106_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0106_NG5.xaml", "Resources")]
		public void XA0106_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0106", "Default", @"//*[name(.)='Border'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Padding=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0106_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0107_OK.xaml", "Resources")]
		public void XA0107_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0107", "Error", @"//*[name(.)='Border'][not(@Name)]/@BorderBrush[.='Transparent']", @"BorderBrush=""Transparent""を指定しなくとも背景は透明です。", });
			var xaml = File.ReadAllText(@"Resources\XA0107_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0107_NG1.xaml", "Resources")]
		public void XA0107_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0107", "Error", @"//*[name(.)='Border'][not(@Name)]/@BorderBrush[.='Transparent']", @"BorderBrush=""Transparent""を指定しなくとも背景は透明です。", });
			var xaml = File.ReadAllText(@"Resources\XA0107_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0108_OK.xaml", "Resources")]
		public void XA0108_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0108", "Default", @"//*[name(.)='Border']/@BorderThickness[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"BorderThickness=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0108_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0108_NG5.xaml", "Resources")]
		public void XA0108_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0108", "Default", @"//*[name(.)='Border']/@BorderThickness[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"BorderThickness=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0108_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0109_OK.xaml", "Resources")]
		public void XA0109_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0109", "Error", @"//*[name(.)='Border'][not(@Style)][not(@Background)][not(@BorderThickness) or @BorderThickness[.='0' or .='0 0' or .='0,0' or .='0 0 0 0' or .='0,0,0,0']]", @"BorderのStyle属性もBackground属性もBordertThickness属性もありません。背景色も罫線も持たないBorderは表示されないので入れ子を解除して下さい。", });
			var xaml = File.ReadAllText(@"Resources\XA0109_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0109_NG2.xaml", "Resources")]
		public void XA0109_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0109", "Error", @"//*[name(.)='Border'][not(@Style)][not(@Background)][not(@BorderThickness) or @BorderThickness[.='0' or .='0 0' or .='0,0' or .='0 0 0 0' or .='0,0,0,0']]", @"BorderのStyle属性もBackground属性もBordertThickness属性もありません。背景色も罫線も持たないBorderは表示されないので入れ子を解除して下さい。", });
			var xaml = File.ReadAllText(@"Resources\XA0109_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0110_OK.xaml", "Resources")]
		public void XA0110_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0110", "Error", @"//*[name(.)='Border'][not(@Width)][@HorizontalAlignment]/*/@HorizontalAlignment", @"HorizontalAlignment属性が指定されたBorder配下の要素のHorizontalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0110_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0110_NG2.xaml", "Resources")]
		public void XA0110_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0110", "Error", @"//*[name(.)='Border'][not(@Width)][@HorizontalAlignment]/*/@HorizontalAlignment", @"HorizontalAlignment属性が指定されたBorder配下の要素のHorizontalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0110_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0111_OK.xaml", "Resources")]
		public void XA0111_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0111", "Error", @"//*[name(.)='Border'][not(@Height)][@VerticalAlignment]/*/@VerticalAlignment", @"VerticalAlignment属性が指定されたBorder配下の要素のVerticalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0111_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0111_NG1.xaml", "Resources")]
		public void XA0111_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0111", "Error", @"//*[name(.)='Border'][not(@Height)][@VerticalAlignment]/*/@VerticalAlignment", @"VerticalAlignment属性が指定されたBorder配下の要素のVerticalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0111_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0201_OK.xaml", "Resources")]
		public void XA0201_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0201", "Default", @"//*[name(.)='StackPanel']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0201_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0201_NG1.xaml", "Resources")]
		public void XA0201_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0201", "Default", @"//*[name(.)='StackPanel']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0201_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0202_OK.xaml", "Resources")]
		public void XA0202_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0202", "Default", @"//*[name(.)='StackPanel']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0202_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0202_NG1.xaml", "Resources")]
		public void XA0202_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0202", "Default", @"//*[name(.)='StackPanel']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0202_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0203_OK.xaml", "Resources")]
		public void XA0203_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0203", "Default", @"//*[name(.)='StackPanel']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0203_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0203_NG1.xaml", "Resources")]
		public void XA0203_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0203", "Default", @"//*[name(.)='StackPanel']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0203_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0204_OK.xaml", "Resources")]
		public void XA0204_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0204", "Default", @"//*[name(.)='StackPanel']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0204_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0204_NG1.xaml", "Resources")]
		public void XA0204_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0204", "Default", @"//*[name(.)='StackPanel']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0204_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0205_OK.xaml", "Resources")]
		public void XA0205_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0205", "Default", @"//*[name(.)='StackPanel'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0205_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0205_NG4.xaml", "Resources")]
		public void XA0205_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0205", "Default", @"//*[name(.)='StackPanel'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0205_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0206_OK.xaml", "Resources")]
		public void XA0206_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0206", "Warning", @"//*[name(.)='StackPanel'][@Orientation=""Vertical""]", @"StackPanel.Orientation=""Vertical""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0206_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0206_NG1.xaml", "Resources")]
		public void XA0206_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0206", "Warning", @"//*[name(.)='StackPanel'][@Orientation=""Vertical""]", @"StackPanel.Orientation=""Vertical""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0206_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0207_OK.xaml", "Resources")]
		public void XA0207_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0207", "Error", @"//*[name(.)='StackPanel'][*[not(starts-with(local-name(.),'StackPanel.'))][1]][not(*[not(starts-with(local-name(.),'StackPanel.'))][2])]", @"StackPanelの子要素が1つしかありません。子要素を複数持たないStackPanelは不要な入れ子なので解除するか、Borderに変更できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0207_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0207_NG2.xaml", "Resources")]
		public void XA0207_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0207", "Error", @"//*[name(.)='StackPanel'][*[not(starts-with(local-name(.),'StackPanel.'))][1]][not(*[not(starts-with(local-name(.),'StackPanel.'))][2])]", @"StackPanelの子要素が1つしかありません。子要素を複数持たないStackPanelは不要な入れ子なので解除するか、Borderに変更できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0207_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0208_OK.xaml", "Resources")]
		public void XA0208_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0208", "Error", @"//*[name(.)='StackPanel'][not(@Orientation=('Horizontal'))]/@HorizontalAlignment[.='Center' or .='Left']", @"縦方向StackPanelではなく、内部のコントロールに対してHorizontalAlignmentを設定すべきです。", });
			var xaml = File.ReadAllText(@"Resources\XA0208_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0208_NG2.xaml", "Resources")]
		public void XA0208_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0208", "Error", @"//*[name(.)='StackPanel'][not(@Orientation=('Horizontal'))]/@HorizontalAlignment[.='Center' or .='Left']", @"縦方向StackPanelではなく、内部のコントロールに対してHorizontalAlignmentを設定すべきです。", });
			var xaml = File.ReadAllText(@"Resources\XA0208_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0209_OK.xaml", "Resources")]
		public void XA0209_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0209", "Error", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/@VerticalAlignment[.='Center' or .='Top']", @"横方向StackPanelではなく、内部のコントロールに対してVerticalAlignmentを設定すべきです。", });
			var xaml = File.ReadAllText(@"Resources\XA0209_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0209_NG2.xaml", "Resources")]
		public void XA0209_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0209", "Error", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/@VerticalAlignment[.='Center' or .='Top']", @"横方向StackPanelではなく、内部のコントロールに対してVerticalAlignmentを設定すべきです。", });
			var xaml = File.ReadAllText(@"Resources\XA0209_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0210_OK.xaml", "Resources")]
		public void XA0210_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0210", "Warning", @"//*[name(.)='StackPanel'][not(@Orientation='Horizontal')]/*/@VerticalAlignment", @"縦方向StackPanel配下のVerticalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0210_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0210_NG4.xaml", "Resources")]
		public void XA0210_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0210", "Warning", @"//*[name(.)='StackPanel'][not(@Orientation='Horizontal')]/*/@VerticalAlignment", @"縦方向StackPanel配下のVerticalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0210_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0211_OK.xaml", "Resources")]
		public void XA0211_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0211", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*/@HorizontalAlignment", @"横方向StackPanel配下のHorizontalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0211_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0211_NG4.xaml", "Resources")]
		public void XA0211_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0211", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*/@HorizontalAlignment", @"横方向StackPanel配下のHorizontalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0211_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0212_OK.xaml", "Resources")]
		public void XA0212_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0212", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*[not(@Width)]/@TextAlignment", @"横方向StackPanel配下のTextAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0212_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0212_NG4.xaml", "Resources")]
		public void XA0212_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0212", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*[not(@Width)]/@TextAlignment", @"横方向StackPanel配下のTextAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0212_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0301_OK.xaml", "Resources")]
		public void XA0301_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0301", "Default", @"//*[name(.)='Grid']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0301_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0301_NG1.xaml", "Resources")]
		public void XA0301_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0301", "Default", @"//*[name(.)='Grid']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0301_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0303_OK.xaml", "Resources")]
		public void XA0303_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0303", "Default", @"//*[name(.)='Grid']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0303_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0303_NG1.xaml", "Resources")]
		public void XA0303_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0303", "Default", @"//*[name(.)='Grid']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0303_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0304_OK.xaml", "Resources")]
		public void XA0304_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0304", "Default", @"//*[name(.)='Grid']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0304_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0304_NG1.xaml", "Resources")]
		public void XA0304_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0304", "Default", @"//*[name(.)='Grid']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0304_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0305_OK.xaml", "Resources")]
		public void XA0305_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0305", "Default", @"//*[name(.)='Grid'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0305_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0305_NG5.xaml", "Resources")]
		public void XA0305_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0305", "Default", @"//*[name(.)='Grid'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0305_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0306_OK.xaml", "Resources")]
		public void XA0306_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0306", "Error", @"//*[name(.)='Grid']/*[@Grid.Row][not(@Grid.RowSpan)][number(@Grid.Row)>=count(parent::*/*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])]/@Grid.Row", @"指定された(Grid.Row)の位置のRowDefinitionがありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0306_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0306_NG1.xaml", "Resources")]
		public void XA0306_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0306", "Error", @"//*[name(.)='Grid']/*[@Grid.Row][not(@Grid.RowSpan)][number(@Grid.Row)>=count(parent::*/*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])]/@Grid.Row", @"指定された(Grid.Row)の位置のRowDefinitionがありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0306_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0307_OK.xaml", "Resources")]
		public void XA0307_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0307", "Error", @"//*[name(.)='Grid']/*[@Grid.Column][not(@Grid.ColumnSpan)][number(@Grid.Column)>=count(parent::*/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])]/@Grid.Column", @"指定された(Grid.Column)の位置のColumnDefinitionがありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0307_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0307_NG1.xaml", "Resources")]
		public void XA0307_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0307", "Error", @"//*[name(.)='Grid']/*[@Grid.Column][not(@Grid.ColumnSpan)][number(@Grid.Column)>=count(parent::*/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])]/@Grid.Column", @"指定された(Grid.Column)の位置のColumnDefinitionがありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0307_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0308_OK.xaml", "Resources")]
		public void XA0308_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0308", "Error", @"//*[name(.)='Grid']/*[@Grid.Row][@Grid.RowSpan][number(@Grid.Row)+number(@Grid.RowSpan)-1>=count(parent::*/*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])]/@Grid.RowSpan", @"指定された(Grid.Row+Grid.RowSpan)の位置のRowDefinitionがありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0308_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0308_NG1.xaml", "Resources")]
		public void XA0308_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0308", "Error", @"//*[name(.)='Grid']/*[@Grid.Row][@Grid.RowSpan][number(@Grid.Row)+number(@Grid.RowSpan)-1>=count(parent::*/*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])]/@Grid.RowSpan", @"指定された(Grid.Row+Grid.RowSpan)の位置のRowDefinitionがありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0308_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0309_OK.xaml", "Resources")]
		public void XA0309_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0309", "Error", @"//*[name(.)='Grid']/*[@Grid.Column][@Grid.ColumnSpan][number(@Grid.Column)+number(@Grid.ColumnSpan)-1>=count(parent::*/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])]/@Grid.ColumnSpan", @"指定された(Grid.Column+Grid.ColumnSpan)の位置のColumnDefinitionがありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0309_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0309_NG1.xaml", "Resources")]
		public void XA0309_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0309", "Error", @"//*[name(.)='Grid']/*[@Grid.Column][@Grid.ColumnSpan][number(@Grid.Column)+number(@Grid.ColumnSpan)-1>=count(parent::*/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])]/@Grid.ColumnSpan", @"指定された(Grid.Column+Grid.ColumnSpan)の位置のColumnDefinitionがありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0309_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0310_OK.xaml", "Resources")]
		public void XA0310_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0310", "Error", @"//*[name(.)='RowDefinition'][not(parent::*/parent::*/*/@Grid.Row=position()-1)][not(position()=1 and parent::*/parent::*/*[not(@Grid.Row)][not(starts-with(name(.),'Grid.'))])][@Height='Auto']", @"この行に要素が存在しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0310_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0310_NG1.xaml", "Resources")]
		public void XA0310_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0310", "Error", @"//*[name(.)='RowDefinition'][not(parent::*/parent::*/*/@Grid.Row=position()-1)][not(position()=1 and parent::*/parent::*/*[not(@Grid.Row)][not(starts-with(name(.),'Grid.'))])][@Height='Auto']", @"この行に要素が存在しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0310_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0311_OK.xaml", "Resources")]
		public void XA0311_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0311", "Error", @"//*[name(.)='ColumnDefinition'][not(parent::*/parent::*/*/@Grid.Column=position()-1)][not(position()=1 and parent::*/parent::*/*[not(@Grid.Column)][not(starts-with(name(.),'Grid.'))])][@Width='Auto']", @"この列に要素が存在しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0311_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0311_NG1.xaml", "Resources")]
		public void XA0311_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0311", "Error", @"//*[name(.)='ColumnDefinition'][not(parent::*/parent::*/*/@Grid.Column=position()-1)][not(position()=1 and parent::*/parent::*/*[not(@Grid.Column)][not(starts-with(name(.),'Grid.'))])][@Width='Auto']", @"この列に要素が存在しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0311_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0312_OK.xaml", "Resources")]
		public void XA0312_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0312", "Error", @"//@*[name(.)='Grid.Row'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.Row属性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0312_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0312_NG2.xaml", "Resources")]
		public void XA0312_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0312", "Error", @"//@*[name(.)='Grid.Row'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.Row属性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0312_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0313_OK.xaml", "Resources")]
		public void XA0313_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0313", "Error", @"//@*[name(.)='Grid.Column'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.Column属性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0313_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0313_NG2.xaml", "Resources")]
		public void XA0313_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0313", "Error", @"//@*[name(.)='Grid.Column'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.Column属性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0313_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0314_OK.xaml", "Resources")]
		public void XA0314_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0314", "Error", @"//@*[name(.)='Grid.RowSpan'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.RowSpan属性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0314_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0314_NG1.xaml", "Resources")]
		public void XA0314_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0314", "Error", @"//@*[name(.)='Grid.RowSpan'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.RowSpan属性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0314_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0315_OK.xaml", "Resources")]
		public void XA0315_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0315", "Error", @"//@*[name(.)='Grid.ColumnSpan'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.ColumnSpan属性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0315_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0315_NG1.xaml", "Resources")]
		public void XA0315_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0315", "Error", @"//@*[name(.)='Grid.ColumnSpan'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.ColumnSpan属性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0315_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0316_OK.xaml", "Resources")]
		public void XA0316_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0316", "Error", @"//*[name(.)='Grid'][not(*[2])]", @"Gridの子要素が1つしかありません。子要素を複数持たないGridは入れ子を解除できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0316_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0316_NG1.xaml", "Resources")]
		public void XA0316_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0316", "Error", @"//*[name(.)='Grid'][not(*[2])]", @"Gridの子要素が1つしかありません。子要素を複数持たないGridは入れ子を解除できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0316_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0317_OK.xaml", "Resources")]
		public void XA0317_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0317", "Error", @"//*[name(.)='Grid'][not(*[name(.)='Grid.ColumnDefinitions'])][*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'][not(@Height='*')]]", @"ColumnDefinitionが無く、いずれのRowDefinition.Height属性にも'*'が含まれません。縦方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0317_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0317_NG1.xaml", "Resources")]
		public void XA0317_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0317", "Error", @"//*[name(.)='Grid'][not(*[name(.)='Grid.ColumnDefinitions'])][*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'][not(@Height='*')]]", @"ColumnDefinitionが無く、いずれのRowDefinition.Height属性にも'*'が含まれません。縦方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0317_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0318_OK.xaml", "Resources")]
		public void XA0318_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0318", "Error", @"//*[name(.)='Grid'][*[name(.)='Grid.ColumnDefinitions']][1=count(*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])][*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'][not(@Height='*')]]", @"ColumnDefinitionが一つしか無く、いずれのRowDefinition.Height属性にも'*'が含まれません。縦方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0318_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0318_NG1.xaml", "Resources")]
		public void XA0318_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0318", "Error", @"//*[name(.)='Grid'][*[name(.)='Grid.ColumnDefinitions']][1=count(*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])][*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'][not(@Height='*')]]", @"ColumnDefinitionが一つしか無く、いずれのRowDefinition.Height属性にも'*'が含まれません。縦方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0318_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0319_OK.xaml", "Resources")]
		public void XA0319_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0319", "Error", @"//*[name(.)='Grid'][not(*[name(.)='Grid.RowDefinitions'])][*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][not(@Width='*')]]", @"RowDefinitionが無く、いずれのColumnDefinition.Width属性にも'*'が含まれません。横方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0319_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0319_NG1.xaml", "Resources")]
		public void XA0319_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0319", "Error", @"//*[name(.)='Grid'][not(*[name(.)='Grid.RowDefinitions'])][*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][not(@Width='*')]]", @"RowDefinitionが無く、いずれのColumnDefinition.Width属性にも'*'が含まれません。横方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0319_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0320_OK.xaml", "Resources")]
		public void XA0320_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0320", "Error", @"//*[name(.)='Grid'][*[name(.)='Grid.RowDefinitions']][1=count(*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])][*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][not(@Width='*')]]", @"RowDefinitionが一つしか無く、いずれのColumnDefinition.Width属性にも'*'が含まれません。横方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0320_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0320_NG1.xaml", "Resources")]
		public void XA0320_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0320", "Error", @"//*[name(.)='Grid'][*[name(.)='Grid.RowDefinitions']][1=count(*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])][*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][not(@Width='*')]]", @"RowDefinitionが一つしか無く、いずれのColumnDefinition.Width属性にも'*'が含まれません。横方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"Resources\XA0320_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0321_OK.xaml", "Resources")]
		public void XA0321_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0321", "Error", @"//*[name(.)='Grid.RowDefinitions'][not(*)]", @"Grid.RowDefinitions配下の要素がありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0321_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0321_NG1.xaml", "Resources")]
		public void XA0321_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0321", "Error", @"//*[name(.)='Grid.RowDefinitions'][not(*)]", @"Grid.RowDefinitions配下の要素がありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0321_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0322_OK.xaml", "Resources")]
		public void XA0322_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0322", "Error", @"//*[name(.)='Grid.ColumnDefinitions'][not(*)]", @"Grid.ColumnDefinitions配下の要素がありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0322_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0322_NG1.xaml", "Resources")]
		public void XA0322_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0322", "Error", @"//*[name(.)='Grid.ColumnDefinitions'][not(*)]", @"Grid.ColumnDefinitions配下の要素がありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0322_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0323_OK.xaml", "Resources")]
		public void XA0323_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0323", "Critical", @"//*[name(.)='Grid.RowDefinitions']/following-sibling::*[not(starts-with(name(.),'Grid.'))][not(starts-with(local-name(.),'Interaction'))][not(@*[name(.)='Grid.Row'])]", @"Grid.RowDefinitionが定義されたGrid配下でGrid.Row添付プロパティが指定されていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0323_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0323_NG1.xaml", "Resources")]
		public void XA0323_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0323", "Critical", @"//*[name(.)='Grid.RowDefinitions']/following-sibling::*[not(starts-with(name(.),'Grid.'))][not(starts-with(local-name(.),'Interaction'))][not(@*[name(.)='Grid.Row'])]", @"Grid.RowDefinitionが定義されたGrid配下でGrid.Row添付プロパティが指定されていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0323_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0324_OK.xaml", "Resources")]
		public void XA0324_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0324", "Critical", @"//*[name(.)='Grid.ColumnDefinitions']/following-sibling::*[not(starts-with(name(.),'Grid.'))][not(starts-with(local-name(.),'Interaction'))][not(@*[name(.)='Grid.Column'])]", @"Grid.ColumnDefinitionが定義されたGrid配下でGrid.Column添付プロパティが指定されていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0324_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0324_NG1.xaml", "Resources")]
		public void XA0324_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0324", "Critical", @"//*[name(.)='Grid.ColumnDefinitions']/following-sibling::*[not(starts-with(name(.),'Grid.'))][not(starts-with(local-name(.),'Interaction'))][not(@*[name(.)='Grid.Column'])]", @"Grid.ColumnDefinitionが定義されたGrid配下でGrid.Column添付プロパティが指定されていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0324_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0401_OK.xaml", "Resources")]
		public void XA0401_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0401", "Default", @"//*[name(.)='ScrollViewer']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0401_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0401_NG1.xaml", "Resources")]
		public void XA0401_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0401", "Default", @"//*[name(.)='ScrollViewer']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0401_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0402_OK.xaml", "Resources")]
		public void XA0402_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0402", "Default", @"//*[name(.)='ScrollViewer']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0402_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0402_NG1.xaml", "Resources")]
		public void XA0402_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0402", "Default", @"//*[name(.)='ScrollViewer']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0402_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0403_OK.xaml", "Resources")]
		public void XA0403_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0403", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0403_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0403_NG1.xaml", "Resources")]
		public void XA0403_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0403", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0403_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0404_OK.xaml", "Resources")]
		public void XA0404_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0404", "Default", @"//*[name(.)='ScrollViewer']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0404_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0404_NG1.xaml", "Resources")]
		public void XA0404_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0404", "Default", @"//*[name(.)='ScrollViewer']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0404_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0405_OK.xaml", "Resources")]
		public void XA0405_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0405", "Default", @"//*[name(.)='ScrollViewer'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ScrollViewer.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0405_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0405_NG5.xaml", "Resources")]
		public void XA0405_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0405", "Default", @"//*[name(.)='ScrollViewer'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ScrollViewer.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0405_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0406_OK.xaml", "Resources")]
		public void XA0406_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0406", "Default", @"//*[name(.)='ScrollViewer'][not(@Name)]/@Padding[.='4' or .='4,4' or .='4 4' or .='4,4,4,4' or .='4 4 4 4']", @"ScrollViewer.Padding=""4""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0406_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0406_NG5.xaml", "Resources")]
		public void XA0406_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0406", "Default", @"//*[name(.)='ScrollViewer'][not(@Name)]/@Padding[.='4' or .='4,4' or .='4 4' or .='4,4,4,4' or .='4 4 4 4']", @"ScrollViewer.Padding=""4""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0406_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0407_OK.xaml", "Resources")]
		public void XA0407_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0407", "Default", @"//*[name(.)='ScrollViewer']/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"ScrollViewer.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0407_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0407_NG5.xaml", "Resources")]
		public void XA0407_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0407", "Default", @"//*[name(.)='ScrollViewer']/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"ScrollViewer.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0407_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0408_OK.xaml", "Resources")]
		public void XA0408_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0408", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalContentAlignment[.='Left']", @"ScrollViewer.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0408_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0408_NG1.xaml", "Resources")]
		public void XA0408_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0408", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalContentAlignment[.='Left']", @"ScrollViewer.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0408_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0409_OK.xaml", "Resources")]
		public void XA0409_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0409", "Default", @"//*[name(.)='ScrollViewer']/@VerticalContentAlignment[.='Top']", @"ScrollViewer.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0409_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0409_NG1.xaml", "Resources")]
		public void XA0409_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0409", "Default", @"//*[name(.)='ScrollViewer']/@VerticalContentAlignment[.='Top']", @"ScrollViewer.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0409_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0410_OK.xaml", "Resources")]
		public void XA0410_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0410", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalScrollBarVisibility[.='Auto']", @"ScrollViewer.HorizontalScrollBarVisibility=""Auto""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0410_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0410_NG1.xaml", "Resources")]
		public void XA0410_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0410", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalScrollBarVisibility[.='Auto']", @"ScrollViewer.HorizontalScrollBarVisibility=""Auto""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0410_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0411_OK.xaml", "Resources")]
		public void XA0411_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0411", "Default", @"//*[name(.)='ScrollViewer']/@VerticalScrollBarVisibility[.='Visible']", @"ScrollViewer.VerticalScrollBarVisibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0411_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0411_NG1.xaml", "Resources")]
		public void XA0411_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0411", "Default", @"//*[name(.)='ScrollViewer']/@VerticalScrollBarVisibility[.='Visible']", @"ScrollViewer.VerticalScrollBarVisibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0411_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0412_OK.xaml", "Resources")]
		public void XA0412_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0412", "Warning", @"//*[name(.)='ScrollViewer']/@HorizontalScrollBarVisibility[not(.='Auto')][not(.='Visible')]", @"ScrollViewer.HorizontalScrollBarVisibility属性に""Auto"",""Visible""以外の値が指定されています。レイアウトのズレが目視確認できなくなっている可能性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0412_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0412_NG2.xaml", "Resources")]
		public void XA0412_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0412", "Warning", @"//*[name(.)='ScrollViewer']/@HorizontalScrollBarVisibility[not(.='Auto')][not(.='Visible')]", @"ScrollViewer.HorizontalScrollBarVisibility属性に""Auto"",""Visible""以外の値が指定されています。レイアウトのズレが目視確認できなくなっている可能性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0412_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0413_OK.xaml", "Resources")]
		public void XA0413_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0413", "Warning", @"//*[name(.)='ScrollViewer']/@VerticalScrollBarVisibility[not(.='Auto')][not(.='Visible')]", @"ScrollViewer.VerticalScrollBarVisibility属性に""Auto"",""Visible""以外の値が指定されています。レイアウトのズレが目視確認できなくなっている可能性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0413_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0413_NG2.xaml", "Resources")]
		public void XA0413_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0413", "Warning", @"//*[name(.)='ScrollViewer']/@VerticalScrollBarVisibility[not(.='Auto')][not(.='Visible')]", @"ScrollViewer.VerticalScrollBarVisibility属性に""Auto"",""Visible""以外の値が指定されています。レイアウトのズレが目視確認できなくなっている可能性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0413_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0414_OK.xaml", "Resources")]
		public void XA0414_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0414", "Critical", @"//*[name(.)='ScrollViewer'][not(@Background)]", @"ScrollViewer.Background属性が有りません。マウスホイールに反応させるため、Background=""Transparent""を指定してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0414_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0414_NG1.xaml", "Resources")]
		public void XA0414_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0414", "Critical", @"//*[name(.)='ScrollViewer'][not(@Background)]", @"ScrollViewer.Background属性が有りません。マウスホイールに反応させるため、Background=""Transparent""を指定してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0414_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0415_OK.xaml", "Resources")]
		public void XA0415_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0415", "Warning", @"//*[name(.)='ScrollViewer'][@BorderThickness='0']/@BorderBrush", @"ScrollViewer.BorderBrush属性があります。BorderThickness=""0""によってBorderは非表示になっているため、指定不要です", });
			var xaml = File.ReadAllText(@"Resources\XA0415_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0415_NG1.xaml", "Resources")]
		public void XA0415_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0415", "Warning", @"//*[name(.)='ScrollViewer'][@BorderThickness='0']/@BorderBrush", @"ScrollViewer.BorderBrush属性があります。BorderThickness=""0""によってBorderは非表示になっているため、指定不要です", });
			var xaml = File.ReadAllText(@"Resources\XA0415_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0416_OK.xaml", "Resources")]
		public void XA0416_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0416", "Warning", @"//*[name(.)='ScrollViewer'][not(@BorderThickness='0')]/@BorderBrush", @"ScrollViewer.BorderBrush属性があります。意図的でなければ指定を削除してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0416_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0416_NG1.xaml", "Resources")]
		public void XA0416_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0416", "Warning", @"//*[name(.)='ScrollViewer'][not(@BorderThickness='0')]/@BorderBrush", @"ScrollViewer.BorderBrush属性があります。意図的でなければ指定を削除してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0416_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0501_OK.xaml", "Resources")]
		public void XA0501_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0501", "Default", @"//*[name(.)='TextBlock']/@Visibility[.='Visible']", @"TextBlock.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0501_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0501_NG1.xaml", "Resources")]
		public void XA0501_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0501", "Default", @"//*[name(.)='TextBlock']/@Visibility[.='Visible']", @"TextBlock.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0501_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0503_OK.xaml", "Resources")]
		public void XA0503_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0503", "Default", @"//*[name(.)='TextBlock']/@HorizontalAlignment[.='Stretch']", @"TextBlock.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0503_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0503_NG1.xaml", "Resources")]
		public void XA0503_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0503", "Default", @"//*[name(.)='TextBlock']/@HorizontalAlignment[.='Stretch']", @"TextBlock.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0503_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0504_OK.xaml", "Resources")]
		public void XA0504_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0504", "Default", @"//*[name(.)='TextBlock']/@VerticalAlignment[.='Stretch']", @"TextBlock.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0504_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0504_NG1.xaml", "Resources")]
		public void XA0504_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0504", "Default", @"//*[name(.)='TextBlock']/@VerticalAlignment[.='Stretch']", @"TextBlock.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0504_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0505_OK.xaml", "Resources")]
		public void XA0505_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0505", "Default", @"//*[name(.)='TextBlock']/@TextAlignment[.='Left']", @"TextBlock.TextAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0505_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0505_NG1.xaml", "Resources")]
		public void XA0505_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0505", "Default", @"//*[name(.)='TextBlock']/@TextAlignment[.='Left']", @"TextBlock.TextAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0505_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0506_OK.xaml", "Resources")]
		public void XA0506_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0506", "Default", @"//*[name(.)='TextBlock'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBlock.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0506_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0506_NG5.xaml", "Resources")]
		public void XA0506_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0506", "Default", @"//*[name(.)='TextBlock'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBlock.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0506_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0507_OK.xaml", "Resources")]
		public void XA0507_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0507", "Critical", @"//*[name(.)='TextBlock'][not(@Text)][not(text())]", @"TextBlock.Text属性がありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0507_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0507_NG1.xaml", "Resources")]
		public void XA0507_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0507", "Critical", @"//*[name(.)='TextBlock'][not(@Text)][not(text())]", @"TextBlock.Text属性がありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0507_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0508_OK.xaml", "Resources")]
		public void XA0508_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0508", "Critical", @"//*[name(.)='TextBlock']/@Text[contains(.,'TwoWay')]", @"TextBlock.Text属性はTwoWayバインディングしないでください。", });
			var xaml = File.ReadAllText(@"Resources\XA0508_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0508_NG1.xaml", "Resources")]
		public void XA0508_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0508", "Critical", @"//*[name(.)='TextBlock']/@Text[contains(.,'TwoWay')]", @"TextBlock.Text属性はTwoWayバインディングしないでください。", });
			var xaml = File.ReadAllText(@"Resources\XA0508_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0509_OK.xaml", "Resources")]
		public void XA0509_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0509", "Warning", @"//*[name(.)='Grid']/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][@Width='Auto'][count(preceding-sibling::*)=parent::*/parent::*/*[@TextAlignment][not(number(@Grid.ColumnSpan)>1)]/@Grid.Column]", @"ColulmnDefinition.Width=""Auto""が指定されているため、該当列に存在する要素の""TextAlignment""の指定値は機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0509_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0509_NG2.xaml", "Resources")]
		public void XA0509_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0509", "Warning", @"//*[name(.)='Grid']/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][@Width='Auto'][count(preceding-sibling::*)=parent::*/parent::*/*[@TextAlignment][not(number(@Grid.ColumnSpan)>1)]/@Grid.Column]", @"ColulmnDefinition.Width=""Auto""が指定されているため、該当列に存在する要素の""TextAlignment""の指定値は機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0509_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0510_OK.xaml", "Resources")]
		public void XA0510_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0510", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*/@TextAlignment", @"横方向StackPanel配下のTextAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0510_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0510_NG4.xaml", "Resources")]
		public void XA0510_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0510", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*/@TextAlignment", @"横方向StackPanel配下のTextAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"Resources\XA0510_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0601_OK.xaml", "Resources")]
		public void XA0601_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0601", "Default", @"//*[name(.)='TextBox']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0601_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0601_NG1.xaml", "Resources")]
		public void XA0601_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0601", "Default", @"//*[name(.)='TextBox']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0601_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0602_OK.xaml", "Resources")]
		public void XA0602_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0602", "Default", @"//*[name(.)='TextBox']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0602_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0602_NG1.xaml", "Resources")]
		public void XA0602_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0602", "Default", @"//*[name(.)='TextBox']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0602_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0603_OK.xaml", "Resources")]
		public void XA0603_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0603", "Default", @"//*[name(.)='TextBox']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0603_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0603_NG1.xaml", "Resources")]
		public void XA0603_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0603", "Default", @"//*[name(.)='TextBox']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0603_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0604_OK.xaml", "Resources")]
		public void XA0604_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0604", "Default", @"//*[name(.)='TextBox']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0604_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0604_NG1.xaml", "Resources")]
		public void XA0604_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0604", "Default", @"//*[name(.)='TextBox']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0604_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0605_OK.xaml", "Resources")]
		public void XA0605_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0605", "Default", @"//*[name(.)='TextBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0605_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0605_NG5.xaml", "Resources")]
		public void XA0605_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0605", "Default", @"//*[name(.)='TextBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0605_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0606_OK.xaml", "Resources")]
		public void XA0606_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0606", "Default", @"//*[name(.)='TextBox'][not(@Name)]/@Padding[.='2' or .='2,2' or .='2 2' or .='2,2,2,2' or .='2 2 2 2']", @"TextBox.Padding=""4""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0606_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0606_NG5.xaml", "Resources")]
		public void XA0606_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0606", "Default", @"//*[name(.)='TextBox'][not(@Name)]/@Padding[.='2' or .='2,2' or .='2 2' or .='2,2,2,2' or .='2 2 2 2']", @"TextBox.Padding=""4""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0606_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0607_OK.xaml", "Resources")]
		public void XA0607_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0607", "Default", @"//*[name(.)='TextBox']/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"TextBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0607_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0607_NG5.xaml", "Resources")]
		public void XA0607_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0607", "Default", @"//*[name(.)='TextBox']/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"TextBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0607_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0608_OK.xaml", "Resources")]
		public void XA0608_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0608", "Critical", @"//*[name(.)='TextBox'][not(@Text)][not(text())]", @"TextBox.Text属性がありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0608_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0608_NG2.xaml", "Resources")]
		public void XA0608_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0608", "Critical", @"//*[name(.)='TextBox'][not(@Text)][not(text())]", @"TextBox.Text属性がありません。", });
			var xaml = File.ReadAllText(@"Resources\XA0608_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0609_OK.xaml", "Resources")]
		public void XA0609_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0609", "Critical", @"//*[name(.)='TextBox'][not(@IsReadOnly='True')][not(@IsEnabled='False')]/@Text[not(contains(.,'TwoWay'))]", @"読み取り専用ではないTextBox.Text属性がTwoWayバインディングされていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0609_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0609_NG3.xaml", "Resources")]
		public void XA0609_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0609", "Critical", @"//*[name(.)='TextBox'][not(@IsReadOnly='True')][not(@IsEnabled='False')]/@Text[not(contains(.,'TwoWay'))]", @"読み取り専用ではないTextBox.Text属性がTwoWayバインディングされていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0609_NG3.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(3, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0610_OK.xaml", "Resources")]
		public void XA0610_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0610", "Critical", @"//*[name(.)='TextBox'][@TextWrapping='Wrap'][not(@Style or @Template)][not(name(..)='StackPanel' and ../@Orientation='Horizontal')]", @"TextBox.TextWrappingのSilverlightバグが発生する可能性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0610_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0610_NG1.xaml", "Resources")]
		public void XA0610_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0610", "Critical", @"//*[name(.)='TextBox'][@TextWrapping='Wrap'][not(@Style or @Template)][not(name(..)='StackPanel' and ../@Orientation='Horizontal')]", @"TextBox.TextWrappingのSilverlightバグが発生する可能性があります。", });
			var xaml = File.ReadAllText(@"Resources\XA0610_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0611_OK1.xaml", "Resources")]
		public void XA0611_OK1()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0611", "Error", @"//*[name(.)='TextBox'][not(@MaxLength)][parent::*][not(@IsReadOnly='True') and not(@IsEnabled='False')]", @"TextBox.MaxLengthが設定されていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0611_OK1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0611_OK2.xaml", "Resources")]
		public void XA0611_OK2()
		{
			var rule = new XmlRuleXPath(string.Empty, 1, new string[] { "XA0611", "Error", @"//*[name(.)='TextBox'][not(@MaxLength)][parent::*][not(@IsReadOnly='True') and not(@IsEnabled='False')]", @"TextBox.MaxLengthが設定されていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0611_OK2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0611_NG1.xaml", "Resources")]
		public void XA0611_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0611", "Error", @"//*[name(.)='TextBox'][not(@MaxLength)][parent::*][not(@IsReadOnly='True') and not(@IsEnabled='False')]", @"TextBox.MaxLengthが設定されていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0611_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0701_OK.xaml", "Resources")]
		public void XA0701_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0701", "Default", @"//*[name(.)='CheckBox']/@Visibility[.='Visible']", @"CheckBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0701_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0701_NG1.xaml", "Resources")]
		public void XA0701_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0701", "Default", @"//*[name(.)='CheckBox']/@Visibility[.='Visible']", @"CheckBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0701_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0702_OK.xaml", "Resources")]
		public void XA0702_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0702", "Default", @"//*[name(.)='CheckBox']/@IsEnabled[.='True']", @"CheckBox.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0702_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0702_NG1.xaml", "Resources")]
		public void XA0702_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0702", "Default", @"//*[name(.)='CheckBox']/@IsEnabled[.='True']", @"CheckBox.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0702_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0703_OK.xaml", "Resources")]
		public void XA0703_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0703", "Default", @"//*[name(.)='CheckBox']/@HorizontalAlignment[.='Stretch']", @"CheckBox.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0703_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0703_NG1.xaml", "Resources")]
		public void XA0703_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0703", "Default", @"//*[name(.)='CheckBox']/@HorizontalAlignment[.='Stretch']", @"CheckBox.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0703_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0704_OK.xaml", "Resources")]
		public void XA0704_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0704", "Default", @"//*[name(.)='CheckBox']/@VerticalAlignment[.='Stretch']", @"CheckBox.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0704_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0704_NG1.xaml", "Resources")]
		public void XA0704_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0704", "Default", @"//*[name(.)='CheckBox']/@VerticalAlignment[.='Stretch']", @"CheckBox.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0704_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0705_OK.xaml", "Resources")]
		public void XA0705_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0705", "Default", @"//*[name(.)='CheckBox']/@HorizontalContentAlignment[.='Left']", @"CheckBox.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0705_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0705_NG1.xaml", "Resources")]
		public void XA0705_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0705", "Default", @"//*[name(.)='CheckBox']/@HorizontalContentAlignment[.='Left']", @"CheckBox.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0705_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0706_OK.xaml", "Resources")]
		public void XA0706_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0706", "Default", @"//*[name(.)='CheckBox']/@VerticalContentAlignment[.='Top']", @"CheckBox.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0706_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0706_NG1.xaml", "Resources")]
		public void XA0706_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0706", "Default", @"//*[name(.)='CheckBox']/@VerticalContentAlignment[.='Top']", @"CheckBox.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0706_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0707_OK.xaml", "Resources")]
		public void XA0707_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0707", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"CheckBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0707_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0707_NG5.xaml", "Resources")]
		public void XA0707_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0707", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"CheckBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0707_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0708_OK.xaml", "Resources")]
		public void XA0708_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0708", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Padding[.='4,1,0,0' or .='4 1 0 0']", @"CheckBox.Padding=""4,1,0,0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0708_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0708_NG2.xaml", "Resources")]
		public void XA0708_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0708", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Padding[.='4,1,0,0' or .='4 1 0 0']", @"CheckBox.Padding=""4,1,0,0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0708_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0709_OK.xaml", "Resources")]
		public void XA0709_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0709", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"CheckBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0709_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0709_NG5.xaml", "Resources")]
		public void XA0709_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0709", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"CheckBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0709_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0710_OK.xaml", "Resources")]
		public void XA0710_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0710", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Background[.='#FF448DCA']", @"CheckBox.Background=""#FF448DCA""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0710_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0710_NG1.xaml", "Resources")]
		public void XA0710_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0710", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Background[.='#FF448DCA']", @"CheckBox.Background=""#FF448DCA""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0710_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0711_OK.xaml", "Resources")]
		public void XA0711_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0711", "Info", @"//*[name(.)='CheckBox'][not(@IsEnabled='False')][not(contains(@IsChecked,'TwoWay'))][@*[local-name()='Name']]", @"名前付きコントロールの読み取り専用ではないCheckBox.IsCheckedプロパティがTwoWayバインドされていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0711_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0711_NG3.xaml", "Resources")]
		public void XA0711_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0711", "Info", @"//*[name(.)='CheckBox'][not(@IsEnabled='False')][not(contains(@IsChecked,'TwoWay'))][@*[local-name()='Name']]", @"名前付きコントロールの読み取り専用ではないCheckBox.IsCheckedプロパティがTwoWayバインドされていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0711_NG3.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(3, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0712_OK.xaml", "Resources")]
		public void XA0712_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0712", "Critical", @"//*[name(.)='CheckBox'][not(@IsEnabled='False')][not(contains(@IsChecked,'TwoWay'))][not(@*[local-name()='Name'])]", @"名前なしコントロールの読み取り専用ではないCheckBox.IsCheckedプロパティがTwoWayバインドされていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0712_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0712_NG3.xaml", "Resources")]
		public void XA0712_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0712", "Critical", @"//*[name(.)='CheckBox'][not(@IsEnabled='False')][not(contains(@IsChecked,'TwoWay'))][not(@*[local-name()='Name'])]", @"名前なしコントロールの読み取り専用ではないCheckBox.IsCheckedプロパティがTwoWayバインドされていません。", });
			var xaml = File.ReadAllText(@"Resources\XA0712_NG3.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(3, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0713_OK.xaml", "Resources")]
		public void XA0713_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0713", "Error", @"//*[name(.)='CheckBox']/@Content[starts-with(.,' ') or starts-with(.,'　')]", @"CheckBox.Content属性の先頭に空白があります]", });
			var xaml = File.ReadAllText(@"Resources\XA0713_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0713_NG2.xaml", "Resources")]
		public void XA0713_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0713", "Error", @"//*[name(.)='CheckBox']/@Content[starts-with(.,' ') or starts-with(.,'　')]", @"CheckBox.Content属性の先頭に空白があります]", });
			var xaml = File.ReadAllText(@"Resources\XA0713_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0714_OK.xaml", "Resources")]
		public void XA0714_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0714", "Error", @"//*[name(.)='CheckBox']/@Content[substring(.,string-length())=' ' or substring(.,string-length())='　']", @"CheckBox.Content属性の末尾に空白があります", });
			var xaml = File.ReadAllText(@"Resources\XA0714_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0714_NG2.xaml", "Resources")]
		public void XA0714_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0714", "Error", @"//*[name(.)='CheckBox']/@Content[substring(.,string-length())=' ' or substring(.,string-length())='　']", @"CheckBox.Content属性の末尾に空白があります", });
			var xaml = File.ReadAllText(@"Resources\XA0714_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0801_OK.xaml", "Resources")]
		public void XA0801_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0801", "Default", @"//*[name(.)='Button']/@Visibility[.='Visible']", @"Button.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0801_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0801_NG1.xaml", "Resources")]
		public void XA0801_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0801", "Default", @"//*[name(.)='Button']/@Visibility[.='Visible']", @"Button.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0801_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0802_OK.xaml", "Resources")]
		public void XA0802_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0802", "Default", @"//*[name(.)='Button']/@IsEnabled[.='True']", @"Button.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0802_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0802_NG1.xaml", "Resources")]
		public void XA0802_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0802", "Default", @"//*[name(.)='Button']/@IsEnabled[.='True']", @"Button.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0802_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0803_OK.xaml", "Resources")]
		public void XA0803_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0803", "Default", @"//*[name(.)='Button']/@HorizontalAlignment[.='Stretch']", @"Button.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0803_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0803_NG1.xaml", "Resources")]
		public void XA0803_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0803", "Default", @"//*[name(.)='Button']/@HorizontalAlignment[.='Stretch']", @"Button.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0803_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0804_OK.xaml", "Resources")]
		public void XA0804_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0804", "Default", @"//*[name(.)='Button']/@VerticalAlignment[.='Stretch']", @"Button.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0804_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0804_NG1.xaml", "Resources")]
		public void XA0804_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0804", "Default", @"//*[name(.)='Button']/@VerticalAlignment[.='Stretch']", @"Button.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0804_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0805_OK.xaml", "Resources")]
		public void XA0805_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0805", "Default", @"//*[name(.)='Button']/@HorizontalContentAlignment[.='Center']", @"Button.HorizontalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0805_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0805_NG1.xaml", "Resources")]
		public void XA0805_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0805", "Default", @"//*[name(.)='Button']/@HorizontalContentAlignment[.='Center']", @"Button.HorizontalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0805_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0806_OK.xaml", "Resources")]
		public void XA0806_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0806", "Default", @"//*[name(.)='Button']/@VerticalContentAlignment[.='Center']", @"Button.VerticalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0806_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0806_NG1.xaml", "Resources")]
		public void XA0806_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0806", "Default", @"//*[name(.)='Button']/@VerticalContentAlignment[.='Center']", @"Button.VerticalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0806_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0807_OK.xaml", "Resources")]
		public void XA0807_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0807", "Default", @"//*[name(.)='Button'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Button.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0807_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0807_NG5.xaml", "Resources")]
		public void XA0807_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0807", "Default", @"//*[name(.)='Button'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Button.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0807_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0808_OK.xaml", "Resources")]
		public void XA0808_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0808", "Default", @"//*[name(.)='Button'][not(@Name)]/@Padding[.='3' or .='3,3' or .='3 3' or .='3,3,3,3' or .='3 3 3 3']", @"Button.Padding=""3""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0808_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0808_NG5.xaml", "Resources")]
		public void XA0808_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0808", "Default", @"//*[name(.)='Button'][not(@Name)]/@Padding[.='3' or .='3,3' or .='3 3' or .='3,3,3,3' or .='3 3 3 3']", @"Button.Padding=""3""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0808_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0809_OK.xaml", "Resources")]
		public void XA0809_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0809", "Default", @"//*[name(.)='Button'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"Button.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0809_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0809_NG5.xaml", "Resources")]
		public void XA0809_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0809", "Default", @"//*[name(.)='Button'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"Button.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0809_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0810_OK.xaml", "Resources")]
		public void XA0810_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0810", "Default", @"//*[name(.)='Button'][not(@Name)]/@Background[.='#FF1F3B53' or .='#1F3B53']", @"Button.Background=""#FF1F3B53""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0810_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0810_NG2.xaml", "Resources")]
		public void XA0810_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0810", "Default", @"//*[name(.)='Button'][not(@Name)]/@Background[.='#FF1F3B53' or .='#1F3B53']", @"Button.Background=""#FF1F3B53""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0810_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0901_OK.xaml", "Resources")]
		public void XA0901_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0901", "Default", @"//*[name(.)='HyperlinkButton']/@Visibility[.='Visible']", @"HyperlinkButton.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0901_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0901_NG1.xaml", "Resources")]
		public void XA0901_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0901", "Default", @"//*[name(.)='HyperlinkButton']/@Visibility[.='Visible']", @"HyperlinkButton.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0901_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0902_OK.xaml", "Resources")]
		public void XA0902_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0902", "Default", @"//*[name(.)='HyperlinkButton']/@IsEnabled[.='True']", @"HyperlinkButton.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0902_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0902_NG1.xaml", "Resources")]
		public void XA0902_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0902", "Default", @"//*[name(.)='HyperlinkButton']/@IsEnabled[.='True']", @"HyperlinkButton.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0902_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0903_OK.xaml", "Resources")]
		public void XA0903_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0903", "Default", @"//*[name(.)='HyperlinkButton']/@HorizontalAlignment[.='Stretch']", @"HyperlinkButton.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0903_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0903_NG1.xaml", "Resources")]
		public void XA0903_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0903", "Default", @"//*[name(.)='HyperlinkButton']/@HorizontalAlignment[.='Stretch']", @"HyperlinkButton.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0903_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0904_OK.xaml", "Resources")]
		public void XA0904_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0904", "Default", @"//*[name(.)='HyperlinkButton']/@VerticalAlignment[.='Stretch']", @"HyperlinkButton.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0904_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0904_NG1.xaml", "Resources")]
		public void XA0904_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0904", "Default", @"//*[name(.)='HyperlinkButton']/@VerticalAlignment[.='Stretch']", @"HyperlinkButton.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0904_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0905_OK.xaml", "Resources")]
		public void XA0905_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0905", "Default", @"//*[name(.)='HyperlinkButton']/@HorizontalContentAlignment[.='Left']", @"HyperlinkButton.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0905_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0905_NG1.xaml", "Resources")]
		public void XA0905_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0905", "Default", @"//*[name(.)='HyperlinkButton']/@HorizontalContentAlignment[.='Left']", @"HyperlinkButton.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0905_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0906_OK.xaml", "Resources")]
		public void XA0906_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0906", "Default", @"//*[name(.)='HyperlinkButton']/@VerticalContentAlignment[.='Top']", @"HyperlinkButton.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0906_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0906_NG1.xaml", "Resources")]
		public void XA0906_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0906", "Default", @"//*[name(.)='HyperlinkButton']/@VerticalContentAlignment[.='Top']", @"HyperlinkButton.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0906_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0907_OK.xaml", "Resources")]
		public void XA0907_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0907", "Default", @"//*[name(.)='HyperlinkButton'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"HyperlinkButton.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0907_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0907_NG5.xaml", "Resources")]
		public void XA0907_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0907", "Default", @"//*[name(.)='HyperlinkButton'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"HyperlinkButton.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0907_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0908_OK.xaml", "Resources")]
		public void XA0908_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0908", "Default", @"//*[name(.)='HyperlinkButton'][not(@Name)]/@Padding[.='3' or .='3,3' or .='3 3' or .='3,3,3,3' or .='3 3 3 3']", @"HyperlinkButton.Padding=""3""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0908_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0908_NG5.xaml", "Resources")]
		public void XA0908_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0908", "Default", @"//*[name(.)='HyperlinkButton'][not(@Name)]/@Padding[.='3' or .='3,3' or .='3 3' or .='3,3,3,3' or .='3 3 3 3']", @"HyperlinkButton.Padding=""3""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0908_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0909_OK.xaml", "Resources")]
		public void XA0909_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0909", "Default", @"//*[name(.)='HyperlinkButton'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"HyperlinkButton.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0909_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0909_NG5.xaml", "Resources")]
		public void XA0909_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0909", "Default", @"//*[name(.)='HyperlinkButton'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"HyperlinkButton.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0909_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0910_OK.xaml", "Resources")]
		public void XA0910_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0910", "Default", @"//*[name(.)='HyperlinkButton'][not(@Name)]/@Background[.='Transparent']", @"HyperlinkButton.Background=""Transparent""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0910_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0910_NG1.xaml", "Resources")]
		public void XA0910_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0910", "Default", @"//*[name(.)='HyperlinkButton'][not(@Name)]/@Background[.='Transparent']", @"HyperlinkButton.Background=""Transparent""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA0910_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0911_OK.xaml", "Resources")]
		public void XA0911_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0911", "Error", @"//*[name(.)='HyperlinkButton'][not(@Name)]/text()", @"HyperlinkButtonのContentがテキストノードで指定されるとマウスオーバー時の下線が表示されなくなるため、Contentプロパティに指定してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0911_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA0911_NG1.xaml", "Resources")]
		public void XA0911_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0911", "Error", @"//*[name(.)='HyperlinkButton'][not(@Name)]/text()", @"HyperlinkButtonのContentがテキストノードで指定されるとマウスオーバー時の下線が表示されなくなるため、Contentプロパティに指定してください。", });
			var xaml = File.ReadAllText(@"Resources\XA0911_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA1001_OK.xaml", "Resources")]
		public void XA1001_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA1001", "Default", @"//*[name(.)='ListBox']/@Visibility[.='Visible']", @"ListBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA1001_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		[DeploymentItem(@"Resources\XA1001_NG1.xaml", "Resources")]
		public void XA1001_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA1001", "Default", @"//*[name(.)='ListBox']/@Visibility[.='Visible']", @"ListBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"Resources\XA1001_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1002_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1002)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1002_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1002)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1003_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1003)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1003_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1003)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1004_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1004)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1004_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1004)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1005_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1005)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1005_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1005)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1006_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1006)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1006_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1006)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1007_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1007)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1007_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1007)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1008_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1008)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1008_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1008)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1009_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1009)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1009_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1009)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1010_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1010)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1010_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1010)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1011_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1011)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1011_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1011)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1012_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1012)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1012_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1012)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1101_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1101)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1101_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1101)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1102_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1102)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1102_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1102)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1103_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1103)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1103_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1103)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1104_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1104)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1104_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1104)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1105_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1105)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1105_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1105)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1106_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1106)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1106_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1106)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1107_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1107)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1107_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1107)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1108_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1108)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1108_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1108)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1109_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1109)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1109_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1109)の異常系テストが作成されていません。");
		}
	}
}
