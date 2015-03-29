using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using XmlChecker;

namespace UnitTestProject
{
	[TestClass]
	public class XmlRuleXPathTest
	{
		[TestMethod]
		public void XA0101_GridTest()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0101", "Error", "//*[name(.)='Grid'][not(*[2])]", "子要素を複数持たないGridは入れ子を解除してください。", });
			var xaml = @"<Grid><TextBlock Text=""Test"" /></Grid>";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		public void XA0102_GridTest()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0102", "Error", "//*[name(.)='Grid']", "子要素を複数持たないGridは入れ子を解除してください。", });
			var xaml = @"<Grid><TextBlock Text=""Test"" /></Grid>";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		public void XA0201_StackPanelTest()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0201", "Error", "//*[name(.)='StackPanel'][not(*[2])]", "子要素を複数持たないStackPanelは入れ子を解除してください。", });
			var xaml = @"<StackPanel><TextBlock Text=""Test"" /></StackPanel>";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		public void XA0301_BorderTest1()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0301", "Error", "//*[name(.)='Border'][not(@Background)][not(@BorderBrush) or not(@BorderThickness)]", "罫線色を持たないBorderは表示されないので入れ子を解除してください。", });
			var xaml = @"<Border Background=""Black""><TextBlock Text=""Test"" /></Border>";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		public void XA0301_BorderTest2()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0301", "Error", "//*[name(.)='Border'][not(@Background)][not(@BorderBrush) or not(@BorderThickness)]", "背景色も罫線を持たないBorderは表示されないので入れ子を解除してください。", });
			var xaml = @"<Border><TextBlock Text=""Test"" /></Border>";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		public void XA0301_BorderTest3()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0301", "Error", "//*[name(.)='Border'][not(@Background)][not(@BorderBrush) or not(@BorderThickness)]", "背景色も罫線を持たないBorderは表示されないので入れ子を解除してください。", });
			var xaml = @"<Border BorderThickness=""1""><TextBlock Text=""Test"" /></Border>";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		public void XA0301_BorderTest4()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0301", "Error", "//*[name(.)='Border'][not(@BorderBrush) or not(@BorderThickness)]", "背景色も罫線を持たないBorderは表示されないので入れ子を解除してください。", });
			var xaml = @"<Border BorderBrush=""Black""><TextBlock Text=""Test"" /></Border>";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		public void XA0401_ScrollViewerTest()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0401", "Error", "//*[name(.)='ScrollViewer'][not(@Background)]", "マウスホイールに反応させるため、ScrollViewrにはBackgroundを指定してください。", });
			var xaml = @"<ScrollViewer><TextBlock Text=""Test"" /></ScrollViewer>";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		public void XA0501_TextBlockTest()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0501", "Error", "//*[name(.)='TextBlock'][contains(@Text,'TwoWay')]", "TextBlock.TextにはTwoWayバインドを指定しないでください。", });
			var xaml = @"<TextBlock Text=""{Binding Text, Mode=TwoWay}"" />";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		public void XA0601_TextBoxTest()
		{
			var rule = new XmlRuleXPath(new string[] { "XA0601", "Error", "//*[name(.)='TextBox'][contains(@Text,'{Binding')][not(contains(@Text,'TwoWay'))]", "TextBox.TextのバインドがTwoWayバインドされていません。", });
			var xaml = @"<TextBox Text=""{Binding Text}"" />";
			var xDoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = xDoc.XPathSelectElements(rule.XPath).ToList();
			Assert.AreEqual(1, errorInstances.Count);
		}
	}
}
