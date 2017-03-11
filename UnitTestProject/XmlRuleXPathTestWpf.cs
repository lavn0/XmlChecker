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
	}
}
