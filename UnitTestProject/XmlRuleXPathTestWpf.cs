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

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0108_OK.xaml", "WpfXaml")]
		public void WPFXA0108_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0108", "Default", @"//*[name(.)='Border']/@BorderThickness[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"BorderThickness=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0108_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0108_NG5.xaml", "WpfXaml")]
		public void WPFXA0108_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0108", "Default", @"//*[name(.)='Border']/@BorderThickness[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"BorderThickness=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0108_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0109_OK.xaml", "WpfXaml")]
		public void WPFXA0109_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0109", "Error", @"//*[name(.)='Border'][not(@Style)][not(@Background)][not(@BorderThickness) or @BorderThickness[.='0' or .='0 0' or .='0,0' or .='0 0 0 0' or .='0,0,0,0']]", @"BorderのStyle属性もBackground属性もBordertThickness属性もありません。背景色も罫線も持たないBorderは表示されないので入れ子を解除して下さい。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0109_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0109_NG2.xaml", "WpfXaml")]
		public void WPFXA0109_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0109", "Error", @"//*[name(.)='Border'][not(@Style)][not(@Background)][not(@BorderThickness) or @BorderThickness[.='0' or .='0 0' or .='0,0' or .='0 0 0 0' or .='0,0,0,0']]", @"BorderのStyle属性もBackground属性もBordertThickness属性もありません。背景色も罫線も持たないBorderは表示されないので入れ子を解除して下さい。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0109_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0110_OK.xaml", "WpfXaml")]
		public void WPFXA0110_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0110", "Error", @"//*[name(.)='Border'][not(@Width)][@HorizontalAlignment]/*/@HorizontalAlignment", @"HorizontalAlignment属性が指定されたBorder配下の要素のHorizontalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0110_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0110_NG2.xaml", "WpfXaml")]
		public void WPFXA0110_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0110", "Error", @"//*[name(.)='Border'][not(@Width)][@HorizontalAlignment]/*/@HorizontalAlignment", @"HorizontalAlignment属性が指定されたBorder配下の要素のHorizontalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0110_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0111_OK.xaml", "WpfXaml")]
		public void WPFXA0111_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0111", "Error", @"//*[name(.)='Border'][not(@Height)][@VerticalAlignment]/*/@VerticalAlignment", @"VerticalAlignment属性が指定されたBorder配下の要素のVerticalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0111_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0111_NG1.xaml", "WpfXaml")]
		public void WPFXA0111_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0111", "Error", @"//*[name(.)='Border'][not(@Height)][@VerticalAlignment]/*/@VerticalAlignment", @"VerticalAlignment属性が指定されたBorder配下の要素のVerticalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0111_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0201_OK.xaml", "WpfXaml")]
		public void WPFXA0201_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0201", "Default", @"//*[name(.)='StackPanel']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0201_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0201_NG1.xaml", "WpfXaml")]
		public void WPFXA0201_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0201", "Default", @"//*[name(.)='StackPanel']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0201_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0202_OK.xaml", "WpfXaml")]
		public void WPFXA0202_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0202", "Default", @"//*[name(.)='StackPanel']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0202_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0202_NG1.xaml", "WpfXaml")]
		public void WPFXA0202_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0202", "Default", @"//*[name(.)='StackPanel']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0202_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0203_OK.xaml", "WpfXaml")]
		public void WPFXA0203_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0203", "Default", @"//*[name(.)='StackPanel']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0203_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0203_NG1.xaml", "WpfXaml")]
		public void WPFXA0203_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0203", "Default", @"//*[name(.)='StackPanel']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0203_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0204_OK.xaml", "WpfXaml")]
		public void WPFXA0204_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0204", "Default", @"//*[name(.)='StackPanel']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0204_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0204_NG1.xaml", "WpfXaml")]
		public void WPFXA0204_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0204", "Default", @"//*[name(.)='StackPanel']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0204_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0205_OK.xaml", "WpfXaml")]
		public void WPFXA0205_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0205", "Default", @"//*[name(.)='StackPanel'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0205_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0205_NG4.xaml", "WpfXaml")]
		public void WPFXA0205_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0205", "Default", @"//*[name(.)='StackPanel'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0205_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0206_OK.xaml", "WpfXaml")]
		public void WPFXA0206_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0206", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Vertical']", @"StackPanel.Orientation=""Vertical""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0206_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0206_NG1.xaml", "WpfXaml")]
		public void WPFXA0206_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0206", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Vertical']", @"StackPanel.Orientation=""Vertical""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0206_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0207_OK.xaml", "WpfXaml")]
		public void WPFXA0207_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0207", "Error", @"//*[name(.)='StackPanel'][*[not(starts-with(local-name(.),'StackPanel.'))][1]][not(*[not(starts-with(local-name(.),'StackPanel.'))][2])]", @"StackPanelの子要素が1つしかありません。子要素を複数持たないStackPanelは不要な入れ子なので解除するか、Borderに変更できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0207_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0207_NG2.xaml", "WpfXaml")]
		public void WPFXA0207_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0207", "Error", @"//*[name(.)='StackPanel'][*[not(starts-with(local-name(.),'StackPanel.'))][1]][not(*[not(starts-with(local-name(.),'StackPanel.'))][2])]", @"StackPanelの子要素が1つしかありません。子要素を複数持たないStackPanelは不要な入れ子なので解除するか、Borderに変更できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0207_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0208_OK.xaml", "WpfXaml")]
		public void WPFXA0208_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0208", "Error", @"//*[name(.)='StackPanel'][not(@Orientation=('Horizontal'))]/@HorizontalAlignment[.='Center' or .='Left']", @"縦方向StackPanelではなく、内部のコントロールに対してHorizontalAlignmentを設定すべきです。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0208_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0208_NG2.xaml", "WpfXaml")]
		public void WPFXA0208_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0208", "Error", @"//*[name(.)='StackPanel'][not(@Orientation=('Horizontal'))]/@HorizontalAlignment[.='Center' or .='Left']", @"縦方向StackPanelではなく、内部のコントロールに対してHorizontalAlignmentを設定すべきです。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0208_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0209_OK.xaml", "WpfXaml")]
		public void WPFXA0209_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0209", "Error", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/@VerticalAlignment[.='Center' or .='Top']", @"横方向StackPanelではなく、内部のコントロールに対してVerticalAlignmentを設定すべきです。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0209_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0209_NG2.xaml", "WpfXaml")]
		public void WPFXA0209_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0209", "Error", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/@VerticalAlignment[.='Center' or .='Top']", @"横方向StackPanelではなく、内部のコントロールに対してVerticalAlignmentを設定すべきです。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0209_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0210_OK.xaml", "WpfXaml")]
		public void WPFXA0210_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0210", "Warning", @"//*[name(.)='StackPanel'][not(@Orientation='Horizontal')]/*/@VerticalAlignment", @"縦方向StackPanel配下のVerticalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0210_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0210_NG4.xaml", "WpfXaml")]
		public void WPFXA0210_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0210", "Warning", @"//*[name(.)='StackPanel'][not(@Orientation='Horizontal')]/*/@VerticalAlignment", @"縦方向StackPanel配下のVerticalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0210_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0211_OK.xaml", "WpfXaml")]
		public void WPFXA0211_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0211", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*/@HorizontalAlignment", @"横方向StackPanel配下のHorizontalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0211_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0211_NG4.xaml", "WpfXaml")]
		public void WPFXA0211_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0211", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*/@HorizontalAlignment", @"横方向StackPanel配下のHorizontalAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0211_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0212_OK.xaml", "WpfXaml")]
		public void WPFXA0212_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0212", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*[not(@Width)]/@TextAlignment", @"横方向StackPanel配下のTextAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0212_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0212_NG4.xaml", "WpfXaml")]
		public void WPFXA0212_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0212", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*[not(@Width)]/@TextAlignment", @"横方向StackPanel配下のTextAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0212_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0301_OK.xaml", "WpfXaml")]
		public void WPFXA0301_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0301", "Default", @"//*[name(.)='Grid']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0301_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0301_NG1.xaml", "WpfXaml")]
		public void WPFXA0301_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0301", "Default", @"//*[name(.)='Grid']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0301_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0302_OK.xaml", "WpfXaml")]
		public void WPFXA0302_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0302", "Default", @"//*[name(.)='Grid']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0302_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0302_NG1.xaml", "WpfXaml")]
		public void WPFXA0302_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0302", "Default", @"//*[name(.)='Grid']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0302_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0303_OK.xaml", "WpfXaml")]
		public void WPFXA0303_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0303", "Default", @"//*[name(.)='Grid']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0303_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0303_NG1.xaml", "WpfXaml")]
		public void WPFXA0303_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0303", "Default", @"//*[name(.)='Grid']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0303_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0304_OK.xaml", "WpfXaml")]
		public void WPFXA0304_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0304", "Default", @"//*[name(.)='Grid']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0304_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0304_NG1.xaml", "WpfXaml")]
		public void WPFXA0304_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0304", "Default", @"//*[name(.)='Grid']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0304_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0305_OK.xaml", "WpfXaml")]
		public void WPFXA0305_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0305", "Default", @"//*[name(.)='Grid'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0305_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0305_NG5.xaml", "WpfXaml")]
		public void WPFXA0305_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0305", "Default", @"//*[name(.)='Grid'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0305_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0306_OK.xaml", "WpfXaml")]
		public void WPFXA0306_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0306", "Error", @"//*[name(.)='Grid']/*[@Grid.Row][not(@Grid.RowSpan)][number(@Grid.Row)>=count(parent::*/*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])]/@Grid.Row", @"指定された(Grid.Row)の位置のRowDefinitionがありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0306_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0306_NG1.xaml", "WpfXaml")]
		public void WPFXA0306_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0306", "Error", @"//*[name(.)='Grid']/*[@Grid.Row][not(@Grid.RowSpan)][number(@Grid.Row)>=count(parent::*/*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])]/@Grid.Row", @"指定された(Grid.Row)の位置のRowDefinitionがありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0306_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0307_OK.xaml", "WpfXaml")]
		public void WPFXA0307_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0307", "Error", @"//*[name(.)='Grid']/*[@Grid.Column][not(@Grid.ColumnSpan)][number(@Grid.Column)>=count(parent::*/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])]/@Grid.Column", @"指定された(Grid.Column)の位置のColumnDefinitionがありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0307_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0307_NG1.xaml", "WpfXaml")]
		public void WPFXA0307_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0307", "Error", @"//*[name(.)='Grid']/*[@Grid.Column][not(@Grid.ColumnSpan)][number(@Grid.Column)>=count(parent::*/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])]/@Grid.Column", @"指定された(Grid.Column)の位置のColumnDefinitionがありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0307_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0308_OK.xaml", "WpfXaml")]
		public void WPFXA0308_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0308", "Error", @"//*[name(.)='Grid']/*[@Grid.Row][@Grid.RowSpan][number(@Grid.Row)+number(@Grid.RowSpan)-1>=count(parent::*/*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])]/@Grid.RowSpan", @"指定された(Grid.Row+Grid.RowSpan)の位置のRowDefinitionがありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0308_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0308_NG1.xaml", "WpfXaml")]
		public void WPFXA0308_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0308", "Error", @"//*[name(.)='Grid']/*[@Grid.Row][@Grid.RowSpan][number(@Grid.Row)+number(@Grid.RowSpan)-1>=count(parent::*/*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])]/@Grid.RowSpan", @"指定された(Grid.Row+Grid.RowSpan)の位置のRowDefinitionがありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0308_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0309_OK.xaml", "WpfXaml")]
		public void WPFXA0309_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0309", "Error", @"//*[name(.)='Grid']/*[@Grid.Column][@Grid.ColumnSpan][number(@Grid.Column)+number(@Grid.ColumnSpan)-1>=count(parent::*/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])]/@Grid.ColumnSpan", @"指定された(Grid.Column+Grid.ColumnSpan)の位置のColumnDefinitionがありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0309_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0309_NG1.xaml", "WpfXaml")]
		public void WPFXA0309_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0309", "Error", @"//*[name(.)='Grid']/*[@Grid.Column][@Grid.ColumnSpan][number(@Grid.Column)+number(@Grid.ColumnSpan)-1>=count(parent::*/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])]/@Grid.ColumnSpan", @"指定された(Grid.Column+Grid.ColumnSpan)の位置のColumnDefinitionがありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0309_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0310_OK.xaml", "WpfXaml")]
		public void WPFXA0310_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0310", "Error", @"//*[name(.)='RowDefinition'][not(parent::*/parent::*/*/@Grid.Row=position()-1)][not(position()=1 and parent::*/parent::*/*[not(@Grid.Row)][not(starts-with(name(.),'Grid.'))])][@Height='Auto']", @"この行に要素が存在しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0310_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0310_NG1.xaml", "WpfXaml")]
		public void WPFXA0310_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0310", "Error", @"//*[name(.)='RowDefinition'][not(parent::*/parent::*/*/@Grid.Row=position()-1)][not(position()=1 and parent::*/parent::*/*[not(@Grid.Row)][not(starts-with(name(.),'Grid.'))])][@Height='Auto']", @"この行に要素が存在しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0310_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0311_OK.xaml", "WpfXaml")]
		public void WPFXA0311_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0311", "Error", @"//*[name(.)='ColumnDefinition'][not(parent::*/parent::*/*/@Grid.Column=position()-1)][not(position()=1 and parent::*/parent::*/*[not(@Grid.Column)][not(starts-with(name(.),'Grid.'))])][@Width='Auto']", @"この列に要素が存在しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0311_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0311_NG1.xaml", "WpfXaml")]
		public void WPFXA0311_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0311", "Error", @"//*[name(.)='ColumnDefinition'][not(parent::*/parent::*/*/@Grid.Column=position()-1)][not(position()=1 and parent::*/parent::*/*[not(@Grid.Column)][not(starts-with(name(.),'Grid.'))])][@Width='Auto']", @"この列に要素が存在しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0311_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0312_OK.xaml", "WpfXaml")]
		public void WPFXA0312_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0312", "Error", @"//@*[name(.)='Grid.Row'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.Row属性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0312_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0312_NG2.xaml", "WpfXaml")]
		public void WPFXA0312_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0312", "Error", @"//@*[name(.)='Grid.Row'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.Row属性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0312_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0313_OK.xaml", "WpfXaml")]
		public void WPFXA0313_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0313", "Error", @"//@*[name(.)='Grid.Column'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.Column属性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0313_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0313_NG2.xaml", "WpfXaml")]
		public void WPFXA0313_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0313", "Error", @"//@*[name(.)='Grid.Column'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.Column属性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0313_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0314_OK.xaml", "WpfXaml")]
		public void WPFXA0314_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0314", "Error", @"//@*[name(.)='Grid.RowSpan'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.RowSpan属性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0314_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0314_NG1.xaml", "WpfXaml")]
		public void WPFXA0314_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0314", "Error", @"//@*[name(.)='Grid.RowSpan'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.RowSpan属性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0314_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0315_OK.xaml", "WpfXaml")]
		public void WPFXA0315_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0315", "Error", @"//@*[name(.)='Grid.ColumnSpan'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.ColumnSpan属性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0315_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0315_NG1.xaml", "WpfXaml")]
		public void WPFXA0315_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0315", "Error", @"//@*[name(.)='Grid.ColumnSpan'][parent::*/parent::*[not(name(.)='Grid')]]", @"Grid配下ではない要素にGrid.ColumnSpan属性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0315_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0316_OK.xaml", "WpfXaml")]
		public void WPFXA0316_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0316", "Error", @"//*[name(.)='Grid'][not(*[2])]", @"Gridの子要素が1つしかありません。子要素を複数持たないGridは入れ子を解除できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0316_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0316_NG1.xaml", "WpfXaml")]
		public void WPFXA0316_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0316", "Error", @"//*[name(.)='Grid'][not(*[2])]", @"Gridの子要素が1つしかありません。子要素を複数持たないGridは入れ子を解除できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0316_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0317_OK.xaml", "WpfXaml")]
		public void WPFXA0317_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0317", "Error", @"//*[name(.)='Grid'][not(*[name(.)='Grid.ColumnDefinitions'])][*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'][not(@Height='*')]]", @"ColumnDefinitionが無く、いずれのRowDefinition.Height属性にも'*'が含まれません。縦方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0317_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0317_NG1.xaml", "WpfXaml")]
		public void WPFXA0317_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0317", "Error", @"//*[name(.)='Grid'][not(*[name(.)='Grid.ColumnDefinitions'])][*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'][not(@Height='*')]]", @"ColumnDefinitionが無く、いずれのRowDefinition.Height属性にも'*'が含まれません。縦方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0317_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0318_OK.xaml", "WpfXaml")]
		public void WPFXA0318_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0318", "Error", @"//*[name(.)='Grid'][*[name(.)='Grid.ColumnDefinitions']][1=count(*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])][*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'][not(@Height='*')]]", @"ColumnDefinitionが一つしか無く、いずれのRowDefinition.Height属性にも'*'が含まれません。縦方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0318_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0318_NG1.xaml", "WpfXaml")]
		public void WPFXA0318_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0318", "Error", @"//*[name(.)='Grid'][*[name(.)='Grid.ColumnDefinitions']][1=count(*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'])][*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'][not(@Height='*')]]", @"ColumnDefinitionが一つしか無く、いずれのRowDefinition.Height属性にも'*'が含まれません。縦方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0318_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0319_OK.xaml", "WpfXaml")]
		public void WPFXA0319_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0319", "Error", @"//*[name(.)='Grid'][not(*[name(.)='Grid.RowDefinitions'])][*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][not(@Width='*')]]", @"RowDefinitionが無く、いずれのColumnDefinition.Width属性にも'*'が含まれません。横方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0319_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0319_NG1.xaml", "WpfXaml")]
		public void WPFXA0319_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0319", "Error", @"//*[name(.)='Grid'][not(*[name(.)='Grid.RowDefinitions'])][*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][not(@Width='*')]]", @"RowDefinitionが無く、いずれのColumnDefinition.Width属性にも'*'が含まれません。横方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0319_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0320_OK.xaml", "WpfXaml")]
		public void WPFXA0320_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0320", "Error", @"//*[name(.)='Grid'][*[name(.)='Grid.RowDefinitions']][1=count(*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])][*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][not(@Width='*')]]", @"RowDefinitionが一つしか無く、いずれのColumnDefinition.Width属性にも'*'が含まれません。横方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0320_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0320_NG1.xaml", "WpfXaml")]
		public void WPFXA0320_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0320", "Error", @"//*[name(.)='Grid'][*[name(.)='Grid.RowDefinitions']][1=count(*[name(.)='Grid.RowDefinitions']/*[name(.)='RowDefinition'])][*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][not(@Width='*')]]", @"RowDefinitionが一つしか無く、いずれのColumnDefinition.Width属性にも'*'が含まれません。横方向StackPanelで代用できます。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0320_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0321_OK.xaml", "WpfXaml")]
		public void WPFXA0321_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0321", "Error", @"//*[name(.)='Grid.RowDefinitions'][not(*)]", @"Grid.RowDefinitions配下の要素がありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0321_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0321_NG1.xaml", "WpfXaml")]
		public void WPFXA0321_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0321", "Error", @"//*[name(.)='Grid.RowDefinitions'][not(*)]", @"Grid.RowDefinitions配下の要素がありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0321_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0322_OK.xaml", "WpfXaml")]
		public void WPFXA0322_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0322", "Error", @"//*[name(.)='Grid.ColumnDefinitions'][not(*)]", @"Grid.ColumnDefinitions配下の要素がありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0322_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0322_NG1.xaml", "WpfXaml")]
		public void WPFXA0322_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0322", "Error", @"//*[name(.)='Grid.ColumnDefinitions'][not(*)]", @"Grid.ColumnDefinitions配下の要素がありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0322_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0323_OK.xaml", "WpfXaml")]
		public void WPFXA0323_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0323", "Critical", @"//*[name(.)='Grid.RowDefinitions']/following-sibling::*[not(starts-with(name(.),'Grid.'))][not(starts-with(local-name(.),'Interaction'))][not(@*[name(.)='Grid.Row'])]", @"Grid.RowDefinitionが定義されたGrid配下でGrid.Row添付プロパティが指定されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0323_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0323_NG1.xaml", "WpfXaml")]
		public void WPFXA0323_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0323", "Critical", @"//*[name(.)='Grid.RowDefinitions']/following-sibling::*[not(starts-with(name(.),'Grid.'))][not(starts-with(local-name(.),'Interaction'))][not(@*[name(.)='Grid.Row'])]", @"Grid.RowDefinitionが定義されたGrid配下でGrid.Row添付プロパティが指定されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0323_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0324_OK.xaml", "WpfXaml")]
		public void WPFXA0324_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0324", "Critical", @"//*[name(.)='Grid.ColumnDefinitions']/following-sibling::*[not(starts-with(name(.),'Grid.'))][not(starts-with(local-name(.),'Interaction'))][not(@*[name(.)='Grid.Column'])]", @"Grid.ColumnDefinitionが定義されたGrid配下でGrid.Column添付プロパティが指定されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0324_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0324_NG1.xaml", "WpfXaml")]
		public void WPFXA0324_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0324", "Critical", @"//*[name(.)='Grid.ColumnDefinitions']/following-sibling::*[not(starts-with(name(.),'Grid.'))][not(starts-with(local-name(.),'Interaction'))][not(@*[name(.)='Grid.Column'])]", @"Grid.ColumnDefinitionが定義されたGrid配下でGrid.Column添付プロパティが指定されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0324_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath)).Cast<XObject>().ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}
	}
}
