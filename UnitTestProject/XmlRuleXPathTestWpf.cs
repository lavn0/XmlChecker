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
	public class XmlRuleXPathTestWpf
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0101_OK.xaml", "WpfXaml")]
		public void WPFXA0101_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0101", "Default", @"//*[name(.)='Border']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0101_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0101_NG1.xaml", "WpfXaml")]
		public void WPFXA0101_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0101", "Default", @"//*[name(.)='Border']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0101_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0102_OK.xaml", "WpfXaml")]
		public void WPFXA0102_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0102", "Default", @"//*[name(.)='Border']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0102_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0102_NG1.xaml", "WpfXaml")]
		public void WPFXA0102_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0102", "Default", @"//*[name(.)='Border']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0102_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0103_OK.xaml", "WpfXaml")]
		public void WPFXA0103_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0103", "Default", @"//*[name(.)='Border']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0103_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0103_NG1.xaml", "WpfXaml")]
		public void WPFXA0103_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0103", "Default", @"//*[name(.)='Border']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0103_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0104_OK.xaml", "WpfXaml")]
		public void WPFXA0104_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0104", "Default", @"//*[name(.)='Border']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0104_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0104_NG1.xaml", "WpfXaml")]
		public void WPFXA0104_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0104", "Default", @"//*[name(.)='Border']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0104_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0105_OK.xaml", "WpfXaml")]
		public void WPFXA0105_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0105", "Default", @"//*[name(.)='Border'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0105_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0105_NG5.xaml", "WpfXaml")]
		public void WPFXA0105_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0105", "Default", @"//*[name(.)='Border'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0105_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0106_OK.xaml", "WpfXaml")]
		public void WPFXA0106_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0106", "Default", @"//*[name(.)='Border'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Padding=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0106_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0106_NG5.xaml", "WpfXaml")]
		public void WPFXA0106_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0106", "Default", @"//*[name(.)='Border'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Padding=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0106_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0107_OK.xaml", "WpfXaml")]
		public void WPFXA0107_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0107", "Error", @"//*[name(.)='Border'][not(@Name)]/@BorderBrush[.='Transparent']", @"BorderBrush=""Transparent""を指定しなくとも背景は透明です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0107_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0107_NG1.xaml", "WpfXaml")]
		public void WPFXA0107_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0107", "Error", @"//*[name(.)='Border'][not(@Name)]/@BorderBrush[.='Transparent']", @"BorderBrush=""Transparent""を指定しなくとも背景は透明です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0107_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}
	}
}
