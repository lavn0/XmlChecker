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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0004", "Error", @"//@*[name(.)='Visibility'][.='Collapsed'][not(parent::*/@*[local-name(.)='Name'])]", @"Name属性が無いタグのVisibility属性に""Collapsed""が指定されています。このコントロールは表示されない可能性があります。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0004", "Error", @"//@*[name(.)='Visibility'][.='Collapsed'][not(parent::*/@*[local-name(.)='Name'])]", @"Name属性が無いタグのVisibility属性に""Collapsed""が指定されています。このコントロールは表示されない可能性があります。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0005", "Default", @"//@*[name(.)='Margin'][contains(.,' ')]", @"Margin属性は空白区切りではなく"",""区切りで指定してください。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0005", "Default", @"//@*[name(.)='Margin'][contains(.,' ')]", @"Margin属性は空白区切りではなく"",""区切りで指定してください。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0006", "Default", @"//@*[name(.)='Padding'][contains(.,' ')]", @"Padding属性は空白区切りではなく"",""区切りで指定してください。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0006", "Default", @"//@*[name(.)='Padding'][contains(.,' ')]", @"Padding属性は空白区切りではなく"",""区切りで指定してください。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0007", "Warning", @"//@*[name(.)='Margin'][contains(.,'-')]", @"Margin属性にマイナス値があります。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0007", "Warning", @"//@*[name(.)='Margin'][contains(.,'-')]", @"Margin属性にマイナス値があります。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0008", "Critical", @"//@*[name(.)='IsEnabled'][contains(.,'TwoWay')]", @"IsEnabledはTwoWayバインディングしないでください。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0008", "Critical", @"//@*[name(.)='IsEnabled'][contains(.,'TwoWay')]", @"IsEnabledはTwoWayバインディングしないでください。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0009", "Critical", @"//@*[name(.)='Visibility'][contains(.,'TwoWay')]", @"VisibilityはTwoWayバインディングしないでください。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0009", "Critical", @"//@*[name(.)='Visibility'][contains(.,'TwoWay')]", @"VisibilityはTwoWayバインディングしないでください。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0101", "Default", @"//*[name(.)='Border']/@*[name(.)='Visibility'][.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0101", "Default", @"//*[name(.)='Border']/@*[name(.)='Visibility'][.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0102", "Default", @"//*[name(.)='Border']/@*[name(.)='IsEnabled'][.='True']", @"IsEnabled=""True""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0102", "Default", @"//*[name(.)='Border']/@*[name(.)='IsEnabled'][.='True']", @"IsEnabled=""True""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0103", "Default", @"//*[name(.)='Border']/@*[name(.)='HorizontalAlignment'][.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0103", "Default", @"//*[name(.)='Border']/@*[name(.)='HorizontalAlignment'][.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0104", "Default", @"//*[name(.)='Border']/@*[name(.)='VerticalAlignment'][.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0104", "Default", @"//*[name(.)='Border']/@*[name(.)='VerticalAlignment'][.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0105", "Default", @"//*[name(.)='Border'][not(@*[name(.)='Name'])]/@*[name(.)='Margin'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0105", "Default", @"//*[name(.)='Border'][not(@*[name(.)='Name'])]/@*[name(.)='Margin'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0106", "Default", @"//*[name(.)='Border'][not(@*[name(.)='Name'])]/@*[name(.)='Padding'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Padding=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0106", "Default", @"//*[name(.)='Border'][not(@*[name(.)='Name'])]/@*[name(.)='Padding'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Padding=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0107", "Error", @"//*[name(.)='Border'][not(@*[name(.)='Name'])]/@*[name(.)='BorderBrush'][.='Transparent']", @"BorderBrush=""Transparent""を指定しなくとも背景は透明です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0107", "Error", @"//*[name(.)='Border'][not(@*[name(.)='Name'])]/@*[name(.)='BorderBrush'][.='Transparent']", @"BorderBrush=""Transparent""を指定しなくとも背景は透明です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0108", "Default", @"//*[name(.)='Border']/@*[name(.)='BorderThickness'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"BorderThickness=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0108", "Default", @"//*[name(.)='Border']/@*[name(.)='BorderThickness'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"BorderThickness=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0201", "Default", @"//*[name(.)='StackPanel']/@*[name(.)='Visibility'][.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0201", "Default", @"//*[name(.)='StackPanel']/@*[name(.)='Visibility'][.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0202", "Default", @"//*[name(.)='StackPanel']/@*[name(.)='IsEnabled'][.='True']", @"IsEnabled=""True""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0202", "Default", @"//*[name(.)='StackPanel']/@*[name(.)='IsEnabled'][.='True']", @"IsEnabled=""True""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0203", "Default", @"//*[name(.)='StackPanel']/@*[name(.)='HorizontalAlignment'][.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0203", "Default", @"//*[name(.)='StackPanel']/@*[name(.)='HorizontalAlignment'][.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0204", "Default", @"//*[name(.)='StackPanel']/@*[name(.)='VerticalAlignment'][.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0204", "Default", @"//*[name(.)='StackPanel']/@*[name(.)='VerticalAlignment'][.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0205", "Default", @"//*[name(.)='StackPanel'][not(@*[name(.)='Name'])]/@*[name(.)='Margin'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0205", "Default", @"//*[name(.)='StackPanel'][not(@*[name(.)='Name'])]/@*[name(.)='Margin'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0301", "Default", @"//*[name(.)='Grid']/@*[name(.)='Visibility'][.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0301", "Default", @"//*[name(.)='Grid']/@*[name(.)='Visibility'][.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0303", "Default", @"//*[name(.)='Grid']/@*[name(.)='HorizontalAlignment'][.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0303", "Default", @"//*[name(.)='Grid']/@*[name(.)='HorizontalAlignment'][.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0304", "Default", @"//*[name(.)='Grid']/@*[name(.)='VerticalAlignment'][.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0304", "Default", @"//*[name(.)='Grid']/@*[name(.)='VerticalAlignment'][.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0305", "Default", @"//*[name(.)='Grid'][not(@*[name(.)='Name'])]/@*[name(.)='Margin'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
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
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "XA0305", "Default", @"//*[name(.)='Grid'][not(@*[name(.)='Name'])]/@*[name(.)='Margin'][.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
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
		public void XA0323_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0323)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0323_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0323)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0324_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0324)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0324_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0324)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0401_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0401)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0401_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0401)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0402_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0402)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0402_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0402)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0403_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0403)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0403_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0403)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0404_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0404)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0404_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0404)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0405_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0405)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0405_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0405)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0406_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0406)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0406_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0406)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0407_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0407)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0407_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0407)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0408_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0408)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0408_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0408)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0409_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0409)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0409_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0409)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0410_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0410)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0410_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0410)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0411_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0411)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0411_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0411)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0412_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0412)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0412_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0412)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0413_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0413)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0413_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0413)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0414_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0414)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0414_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0414)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0415_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0415)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0415_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0415)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0416_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0416)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0416_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0416)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0417_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0417)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0417_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0417)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0418_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0418)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0418_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0418)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0501_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0501)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0501_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0501)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0502_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0502)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0502_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0502)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0503_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0503)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0503_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0503)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0504_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0504)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0504_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0504)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0505_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0505)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0505_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0505)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0506_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0506)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0506_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0506)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0507_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0507)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0507_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0507)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0508_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0508)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0508_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0508)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0509_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0509)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0509_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0509)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0510_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0510)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0510_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0510)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0601_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0601)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0601_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0601)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0602_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0602)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0602_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0602)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0603_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0603)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0603_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0603)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0604_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0604)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0604_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0604)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0605_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0605)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0605_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0605)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0701_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0701)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0701_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0701)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0702_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0702)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0702_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0702)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0703_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0703)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0703_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0703)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0704_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0704)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0704_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0704)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0705_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0705)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0705_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0705)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0706_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0706)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0706_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0706)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0707_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0707)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0707_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0707)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0708_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0708)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0708_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0708)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0709_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0709)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0709_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0709)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0710_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0710)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0710_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0710)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0711_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0711)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0711_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0711)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0712_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0712)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0712_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0712)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0713_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0713)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0713_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0713)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0714_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0714)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0714_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0714)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0801_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0801)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0801_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0801)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0802_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0802)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0802_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0802)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0803_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0803)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0803_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0803)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0804_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0804)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0804_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0804)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0805_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0805)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0805_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0805)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0806_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0806)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0806_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0806)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0807_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0807)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0807_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0807)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0808_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0808)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0808_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0808)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0809_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0809)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0809_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0809)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0810_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0810)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0810_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0810)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0901_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0901)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0901_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0901)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0902_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0902)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0902_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0902)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0903_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0903)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0903_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0903)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0904_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0904)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0904_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0904)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0905_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0905)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0905_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0905)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0906_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0906)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0906_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0906)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0907_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0907)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0907_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0907)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0908_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0908)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0908_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0908)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0909_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0909)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0909_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0909)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0910_OK()
		{
			Assert.Inconclusive("ルール(ID=XA0910)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA0910_NG()
		{
			Assert.Inconclusive("ルール(ID=XA0910)の異常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1001_OK()
		{
			Assert.Inconclusive("ルール(ID=XA1001)の正常系テストが作成されていません。");
		}

		[TestMethod]
		[TestCategory("XmlChecker")]
		public void XA1001_NG()
		{
			Assert.Inconclusive("ルール(ID=XA1001)の異常系テストが作成されていません。");
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
