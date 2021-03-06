﻿using System.Collections.Generic;
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
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
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0401_OK.xaml", "WpfXaml")]
		public void WPFXA0401_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0401", "Default", @"//*[name(.)='ScrollViewer']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0401_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0401_NG1.xaml", "WpfXaml")]
		public void WPFXA0401_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0401", "Default", @"//*[name(.)='ScrollViewer']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0401_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0402_OK.xaml", "WpfXaml")]
		public void WPFXA0402_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0402", "Default", @"//*[name(.)='ScrollViewer']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0402_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0402_NG1.xaml", "WpfXaml")]
		public void WPFXA0402_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0402", "Default", @"//*[name(.)='ScrollViewer']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0402_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0403_OK.xaml", "WpfXaml")]
		public void WPFXA0403_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0403", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0403_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0403_NG1.xaml", "WpfXaml")]
		public void WPFXA0403_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0403", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0403_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0404_OK.xaml", "WpfXaml")]
		public void WPFXA0404_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0404", "Default", @"//*[name(.)='ScrollViewer']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0404_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0404_NG1.xaml", "WpfXaml")]
		public void WPFXA0404_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0404", "Default", @"//*[name(.)='ScrollViewer']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0404_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0405_OK.xaml", "WpfXaml")]
		public void WPFXA0405_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0405", "Default", @"//*[name(.)='ScrollViewer'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ScrollViewer.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0405_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0405_NG5.xaml", "WpfXaml")]
		public void WPFXA0405_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0405", "Default", @"//*[name(.)='ScrollViewer'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ScrollViewer.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0405_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0406_OK.xaml", "WpfXaml")]
		public void WPFXA0406_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0406", "Default", @"//*[name(.)='ScrollViewer'][not(@Name)]/@Padding[.='4' or .='4,4' or .='4 4' or .='4,4,4,4' or .='4 4 4 4']", @"ScrollViewer.Padding=""4""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0406_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0406_NG5.xaml", "WpfXaml")]
		public void WPFXA0406_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0406", "Default", @"//*[name(.)='ScrollViewer'][not(@Name)]/@Padding[.='4' or .='4,4' or .='4 4' or .='4,4,4,4' or .='4 4 4 4']", @"ScrollViewer.Padding=""4""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0406_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0407_OK.xaml", "WpfXaml")]
		public void WPFXA0407_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0407", "Default", @"//*[name(.)='ScrollViewer']/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"ScrollViewer.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0407_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0407_NG5.xaml", "WpfXaml")]
		public void WPFXA0407_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0407", "Default", @"//*[name(.)='ScrollViewer']/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"ScrollViewer.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0407_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0408_OK.xaml", "WpfXaml")]
		public void WPFXA0408_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0408", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalContentAlignment[.='Left']", @"ScrollViewer.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0408_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0408_NG1.xaml", "WpfXaml")]
		public void WPFXA0408_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0408", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalContentAlignment[.='Left']", @"ScrollViewer.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0408_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0409_OK.xaml", "WpfXaml")]
		public void WPFXA0409_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0409", "Default", @"//*[name(.)='ScrollViewer']/@VerticalContentAlignment[.='Top']", @"ScrollViewer.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0409_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0409_NG1.xaml", "WpfXaml")]
		public void WPFXA0409_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0409", "Default", @"//*[name(.)='ScrollViewer']/@VerticalContentAlignment[.='Top']", @"ScrollViewer.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0409_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0410_OK.xaml", "WpfXaml")]
		public void WPFXA0410_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0410", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalScrollBarVisibility[.='Auto']", @"ScrollViewer.HorizontalScrollBarVisibility=""Auto""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0410_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0410_NG1.xaml", "WpfXaml")]
		public void WPFXA0410_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0410", "Default", @"//*[name(.)='ScrollViewer']/@HorizontalScrollBarVisibility[.='Auto']", @"ScrollViewer.HorizontalScrollBarVisibility=""Auto""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0410_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0411_OK.xaml", "WpfXaml")]
		public void WPFXA0411_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0411", "Default", @"//*[name(.)='ScrollViewer']/@VerticalScrollBarVisibility[.='Visible']", @"ScrollViewer.VerticalScrollBarVisibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0411_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0411_NG1.xaml", "WpfXaml")]
		public void WPFXA0411_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0411", "Default", @"//*[name(.)='ScrollViewer']/@VerticalScrollBarVisibility[.='Visible']", @"ScrollViewer.VerticalScrollBarVisibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0411_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0412_OK.xaml", "WpfXaml")]
		public void WPFXA0412_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0412", "Warning", @"//*[name(.)='ScrollViewer']/@HorizontalScrollBarVisibility[not(.='Auto')][not(.='Visible')]", @"ScrollViewer.HorizontalScrollBarVisibility属性に""Auto"",""Visible""以外の値が指定されています。レイアウトのズレが目視確認できなくなっている可能性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0412_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0412_NG2.xaml", "WpfXaml")]
		public void WPFXA0412_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0412", "Warning", @"//*[name(.)='ScrollViewer']/@HorizontalScrollBarVisibility[not(.='Auto')][not(.='Visible')]", @"ScrollViewer.HorizontalScrollBarVisibility属性に""Auto"",""Visible""以外の値が指定されています。レイアウトのズレが目視確認できなくなっている可能性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0412_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0413_OK.xaml", "WpfXaml")]
		public void WPFXA0413_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0413", "Warning", @"//*[name(.)='ScrollViewer']/@VerticalScrollBarVisibility[not(.='Auto')][not(.='Visible')]", @"ScrollViewer.VerticalScrollBarVisibility属性に""Auto"",""Visible""以外の値が指定されています。レイアウトのズレが目視確認できなくなっている可能性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0413_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0413_NG2.xaml", "WpfXaml")]
		public void WPFXA0413_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0413", "Warning", @"//*[name(.)='ScrollViewer']/@VerticalScrollBarVisibility[not(.='Auto')][not(.='Visible')]", @"ScrollViewer.VerticalScrollBarVisibility属性に""Auto"",""Visible""以外の値が指定されています。レイアウトのズレが目視確認できなくなっている可能性があります。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0413_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0414_OK.xaml", "WpfXaml")]
		public void WPFXA0414_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0414", "Critical", @"//*[name(.)='ScrollViewer'][not(@Background)]", @"ScrollViewer.Background属性が有りません。マウスホイールに反応させるため、Background=""Transparent""を指定してください。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0414_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0414_NG1.xaml", "WpfXaml")]
		public void WPFXA0414_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0414", "Critical", @"//*[name(.)='ScrollViewer'][not(@Background)]", @"ScrollViewer.Background属性が有りません。マウスホイールに反応させるため、Background=""Transparent""を指定してください。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0414_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0415_OK.xaml", "WpfXaml")]
		public void WPFXA0415_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0415", "Warning", @"//*[name(.)='ScrollViewer'][@BorderThickness='0']/@BorderBrush", @"ScrollViewer.BorderBrush属性があります。BorderThickness=""0""によってBorderは非表示になっているため、指定不要です", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0415_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0415_NG1.xaml", "WpfXaml")]
		public void WPFXA0415_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0415", "Warning", @"//*[name(.)='ScrollViewer'][@BorderThickness='0']/@BorderBrush", @"ScrollViewer.BorderBrush属性があります。BorderThickness=""0""によってBorderは非表示になっているため、指定不要です", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0415_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0416_OK.xaml", "WpfXaml")]
		public void WPFXA0416_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0416", "Warning", @"//*[name(.)='ScrollViewer'][not(@BorderThickness='0')]/@BorderBrush", @"ScrollViewer.BorderBrush属性があります。意図的でなければ指定を削除してください。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0416_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0416_NG1.xaml", "WpfXaml")]
		public void WPFXA0416_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0416", "Warning", @"//*[name(.)='ScrollViewer'][not(@BorderThickness='0')]/@BorderBrush", @"ScrollViewer.BorderBrush属性があります。意図的でなければ指定を削除してください。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0416_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0501_OK.xaml", "WpfXaml")]
		public void WPFXA0501_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0501", "Default", @"//*[name(.)='TextBlock']/@Visibility[.='Visible']", @"TextBlock.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0501_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0501_NG1.xaml", "WpfXaml")]
		public void WPFXA0501_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0501", "Default", @"//*[name(.)='TextBlock']/@Visibility[.='Visible']", @"TextBlock.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0501_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0502_OK.xaml", "WpfXaml")]
		public void WPFXA0502_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0502", "Default", @"//*[name(.)='TextBlock']/@IsEnabled[.='True']", @"TextBlock.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0502_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0502_NG1.xaml", "WpfXaml")]
		public void WPFXA0502_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0502", "Default", @"//*[name(.)='TextBlock']/@IsEnabled[.='True']", @"TextBlock.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0502_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0503_OK.xaml", "WpfXaml")]
		public void WPFXA0503_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0503", "Default", @"//*[name(.)='TextBlock']/@HorizontalAlignment", @"TextBlock.HorizontalAlignmentを使用するよりもTextAlignmentを使用します。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0503_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0503_NG4.xaml", "WpfXaml")]
		public void WPFXA0503_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0503", "Default", @"//*[name(.)='TextBlock']/@HorizontalAlignment", @"TextBlock.HorizontalAlignmentを使用するよりもTextAlignmentを使用します。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0503_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0504_OK.xaml", "WpfXaml")]
		public void WPFXA0504_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0504", "Default", @"//*[name(.)='TextBlock']/@VerticalAlignment[.='Stretch']", @"TextBlock.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0504_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0504_NG1.xaml", "WpfXaml")]
		public void WPFXA0504_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0504", "Default", @"//*[name(.)='TextBlock']/@VerticalAlignment[.='Stretch']", @"TextBlock.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0504_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0505_OK.xaml", "WpfXaml")]
		public void WPFXA0505_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0505", "Default", @"//*[name(.)='TextBlock']/@TextAlignment[.='Left']", @"TextBlock.TextAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0505_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0505_NG1.xaml", "WpfXaml")]
		public void WPFXA0505_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0505", "Default", @"//*[name(.)='TextBlock']/@TextAlignment[.='Left']", @"TextBlock.TextAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0505_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0506_OK.xaml", "WpfXaml")]
		public void WPFXA0506_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0506", "Default", @"//*[name(.)='TextBlock'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBlock.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0506_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0506_NG5.xaml", "WpfXaml")]
		public void WPFXA0506_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0506", "Default", @"//*[name(.)='TextBlock'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBlock.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0506_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0507_OK.xaml", "WpfXaml")]
		public void WPFXA0507_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0507", "Critical", @"//*[name(.)='TextBlock'][not(@Text)][not(text())]", @"TextBlock.Text属性がありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0507_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0507_NG1.xaml", "WpfXaml")]
		public void WPFXA0507_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0507", "Critical", @"//*[name(.)='TextBlock'][not(@Text)][not(text())]", @"TextBlock.Text属性がありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0507_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0509_OK.xaml", "WpfXaml")]
		public void WPFXA0509_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0509", "Warning", @"//*[name(.)='Grid']/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][@Width='Auto'][count(preceding-sibling::*)=parent::*/parent::*/*[@TextAlignment][not(number(@Grid.ColumnSpan)>1)]/@Grid.Column]", @"ColulmnDefinition.Width=""Auto""が指定されているため、該当列に存在する要素の""TextAlignment""の指定値は機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0509_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0509_NG2.xaml", "WpfXaml")]
		public void WPFXA0509_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0509", "Warning", @"//*[name(.)='Grid']/*[name(.)='Grid.ColumnDefinitions']/*[name(.)='ColumnDefinition'][@Width='Auto'][count(preceding-sibling::*)=parent::*/parent::*/*[@TextAlignment][not(number(@Grid.ColumnSpan)>1)]/@Grid.Column]", @"ColulmnDefinition.Width=""Auto""が指定されているため、該当列に存在する要素の""TextAlignment""の指定値は機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0509_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0510_OK.xaml", "WpfXaml")]
		public void WPFXA0510_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0510", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*/@TextAlignment", @"横方向StackPanel配下のTextAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0510_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0510_NG4.xaml", "WpfXaml")]
		public void WPFXA0510_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0510", "Warning", @"//*[name(.)='StackPanel'][@Orientation='Horizontal']/*/@TextAlignment", @"横方向StackPanel配下のTextAlignmentは機能しません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0510_NG4.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(4, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0601_OK.xaml", "WpfXaml")]
		public void WPFXA0601_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0601", "Default", @"//*[name(.)='TextBox']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0601_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0601_NG1.xaml", "WpfXaml")]
		public void WPFXA0601_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0601", "Default", @"//*[name(.)='TextBox']/@Visibility[.='Visible']", @"Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0601_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0602_OK.xaml", "WpfXaml")]
		public void WPFXA0602_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0602", "Default", @"//*[name(.)='TextBox']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0602_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0602_NG1.xaml", "WpfXaml")]
		public void WPFXA0602_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0602", "Default", @"//*[name(.)='TextBox']/@IsEnabled[.='True']", @"IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0602_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0603_OK.xaml", "WpfXaml")]
		public void WPFXA0603_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0603", "Default", @"//*[name(.)='TextBox']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0603_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0603_NG1.xaml", "WpfXaml")]
		public void WPFXA0603_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0603", "Default", @"//*[name(.)='TextBox']/@HorizontalAlignment[.='Stretch']", @"HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0603_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0604_OK.xaml", "WpfXaml")]
		public void WPFXA0604_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0604", "Default", @"//*[name(.)='TextBox']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0604_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0604_NG1.xaml", "WpfXaml")]
		public void WPFXA0604_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0604", "Default", @"//*[name(.)='TextBox']/@VerticalAlignment[.='Stretch']", @"VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0604_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0605_OK.xaml", "WpfXaml")]
		public void WPFXA0605_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0605", "Default", @"//*[name(.)='TextBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0605_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0605_NG5.xaml", "WpfXaml")]
		public void WPFXA0605_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0605", "Default", @"//*[name(.)='TextBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0605_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0606_OK.xaml", "WpfXaml")]
		public void WPFXA0606_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0606", "Default", @"//*[name(.)='TextBox'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBox.Padding=""2""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0606_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0606_NG5.xaml", "WpfXaml")]
		public void WPFXA0606_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0606", "Default", @"//*[name(.)='TextBox'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"TextBox.Padding=""2""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0606_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0607_OK.xaml", "WpfXaml")]
		public void WPFXA0607_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0607", "Default", @"//*[name(.)='TextBox']/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"TextBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0607_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0607_NG5.xaml", "WpfXaml")]
		public void WPFXA0607_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0607", "Default", @"//*[name(.)='TextBox']/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"TextBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0607_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0608_OK.xaml", "WpfXaml")]
		public void WPFXA0608_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0608", "Critical", @"//*[name(.)='TextBox'][not(@Text)][not(text())]", @"TextBox.Text属性がありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0608_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0608_NG2.xaml", "WpfXaml")]
		public void WPFXA0608_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0608", "Critical", @"//*[name(.)='TextBox'][not(@Text)][not(text())]", @"TextBox.Text属性がありません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0608_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0609_OK.xaml", "WpfXaml")]
		public void WPFXA0609_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0609", "Critical", @"//*[name(.)='TextBox'][not(@IsReadOnly='True')][not(@IsEnabled='False')]/@Text[contains(.,'Mode=')][not(contains(.,'TwoWay'))]", @"読み取り専用ではないTextBox.Text属性にTwoWay以外のバインディングが指定されています。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0609_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0609_NG2.xaml", "WpfXaml")]
		public void WPFXA0609_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0609", "Critical", @"//*[name(.)='TextBox'][not(@IsReadOnly='True')][not(@IsEnabled='False')]/@Text[contains(.,'Mode=')][not(contains(.,'TwoWay'))]", @"読み取り専用ではないTextBox.Text属性にTwoWay以外のバインディングが指定されています。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0609_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0611_OK1.xaml", "WpfXaml")]
		public void WPFXA0611_OK1()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0611", "Error", @"//*[name(.)='TextBox'][not(@MaxLength)][parent::*][not(@IsReadOnly='True') and not(@IsEnabled='False')]", @"TextBox.MaxLengthが設定されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0611_OK1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0611_OK2.xaml", "WpfXaml")]
		public void WPFXA0611_OK2()
		{
			var rule = new XmlRuleXPath(string.Empty, 1, new string[] { "WPFXA0611", "Error", @"//*[name(.)='TextBox'][not(@MaxLength)][parent::*][not(@IsReadOnly='True') and not(@IsEnabled='False')]", @"TextBox.MaxLengthが設定されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0611_OK2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0611_NG1.xaml", "WpfXaml")]
		public void WPFXA0611_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0611", "Error", @"//*[name(.)='TextBox'][not(@MaxLength)][parent::*][not(@IsReadOnly='True') and not(@IsEnabled='False')]", @"TextBox.MaxLengthが設定されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0611_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0701_OK.xaml", "WpfXaml")]
		public void WPFXA0701_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0701", "Default", @"//*[name(.)='CheckBox']/@Visibility[.='Visible']", @"CheckBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0701_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0701_NG1.xaml", "WpfXaml")]
		public void WPFXA0701_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0701", "Default", @"//*[name(.)='CheckBox']/@Visibility[.='Visible']", @"CheckBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0701_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0702_OK.xaml", "WpfXaml")]
		public void WPFXA0702_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0702", "Default", @"//*[name(.)='CheckBox']/@IsEnabled[.='True']", @"CheckBox.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0702_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0702_NG1.xaml", "WpfXaml")]
		public void WPFXA0702_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0702", "Default", @"//*[name(.)='CheckBox']/@IsEnabled[.='True']", @"CheckBox.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0702_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0703_OK.xaml", "WpfXaml")]
		public void WPFXA0703_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0703", "Default", @"//*[name(.)='CheckBox']/@HorizontalAlignment[.='Stretch']", @"CheckBox.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0703_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0703_NG1.xaml", "WpfXaml")]
		public void WPFXA0703_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0703", "Default", @"//*[name(.)='CheckBox']/@HorizontalAlignment[.='Stretch']", @"CheckBox.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0703_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0704_OK.xaml", "WpfXaml")]
		public void WPFXA0704_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0704", "Default", @"//*[name(.)='CheckBox']/@VerticalAlignment[.='Stretch']", @"CheckBox.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0704_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0704_NG1.xaml", "WpfXaml")]
		public void WPFXA0704_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0704", "Default", @"//*[name(.)='CheckBox']/@VerticalAlignment[.='Stretch']", @"CheckBox.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0704_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0705_OK.xaml", "WpfXaml")]
		public void WPFXA0705_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0705", "Default", @"//*[name(.)='CheckBox']/@HorizontalContentAlignment[.='Left']", @"CheckBox.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0705_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0705_NG1.xaml", "WpfXaml")]
		public void WPFXA0705_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0705", "Default", @"//*[name(.)='CheckBox']/@HorizontalContentAlignment[.='Left']", @"CheckBox.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0705_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0706_OK.xaml", "WpfXaml")]
		public void WPFXA0706_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0706", "Default", @"//*[name(.)='CheckBox']/@VerticalContentAlignment[.='Top']", @"CheckBox.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0706_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0706_NG1.xaml", "WpfXaml")]
		public void WPFXA0706_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0706", "Default", @"//*[name(.)='CheckBox']/@VerticalContentAlignment[.='Top']", @"CheckBox.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0706_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0707_OK.xaml", "WpfXaml")]
		public void WPFXA0707_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0707", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"CheckBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0707_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0707_NG5.xaml", "WpfXaml")]
		public void WPFXA0707_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0707", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"CheckBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0707_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0708_OK.xaml", "WpfXaml")]
		public void WPFXA0708_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0708", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"CheckBox.Padding=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0708_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0708_NG5.xaml", "WpfXaml")]
		public void WPFXA0708_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0708", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"CheckBox.Padding=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0708_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0709_OK.xaml", "WpfXaml")]
		public void WPFXA0709_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0709", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"CheckBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0709_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0709_NG5.xaml", "WpfXaml")]
		public void WPFXA0709_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0709", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"CheckBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0709_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0710_OK.xaml", "WpfXaml")]
		public void WPFXA0710_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0710", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Background[.='#FFFFFFFF' or .='#FFFFFF' or .='White']", @"CheckBox.Background=""#FFFFFFFF""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0710_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0710_NG3.xaml", "WpfXaml")]
		public void WPFXA0710_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0710", "Default", @"//*[name(.)='CheckBox'][not(@Name)]/@Background[.='#FFFFFFFF' or .='#FFFFFF' or .='White']", @"CheckBox.Background=""#FFFFFFFF""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0710_NG3.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(3, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0711_OK.xaml", "WpfXaml")]
		public void WPFXA0711_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0711", "Info", @"//*[name(.)='CheckBox'][not(@IsEnabled='False')][@*[local-name()='Name']]/@IsChecked[contains(.,'Mode=')][not(contains(.,'TwoWay'))]", @"名前付きコントロールの読み取り専用ではないCheckBox.IsChecked属性にTwoWay以外のバインディングが指定されています。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0711_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0711_NG2.xaml", "WpfXaml")]
		public void WPFXA0711_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0711", "Info", @"//*[name(.)='CheckBox'][not(@IsEnabled='False')][@*[local-name()='Name']]/@IsChecked[contains(.,'Mode=')][not(contains(.,'TwoWay'))]", @"名前付きコントロールの読み取り専用ではないCheckBox.IsChecked属性にTwoWay以外のバインディングが指定されています。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0711_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0712_OK.xaml", "WpfXaml")]
		public void WPFXA0712_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0712", "Critical", @"//*[name(.)='CheckBox'][not(@IsEnabled='False')][not(@*[local-name()='Name'])]/@IsChecked[contains(.,'Mode=')][not(contains(.,'TwoWay'))]", @"名前なしコントロールの読み取り専用ではないCheckBox.IsChecked属性にTwoWay以外のバインディングが指定されています。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0712_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0712_NG2.xaml", "WpfXaml")]
		public void WPFXA0712_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0712", "Critical", @"//*[name(.)='CheckBox'][not(@IsEnabled='False')][not(@*[local-name()='Name'])]/@IsChecked[contains(.,'Mode=')][not(contains(.,'TwoWay'))]", @"名前なしコントロールの読み取り専用ではないCheckBox.IsChecked属性にTwoWay以外のバインディングが指定されています。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0712_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0713_OK.xaml", "WpfXaml")]
		public void WPFXA0713_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0713", "Error", @"//*[name(.)='CheckBox']/@Content[starts-with(.,' ') or starts-with(.,'　')]", @"CheckBox.Content属性の先頭に空白があります", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0713_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0713_NG2.xaml", "WpfXaml")]
		public void WPFXA0713_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0713", "Error", @"//*[name(.)='CheckBox']/@Content[starts-with(.,' ') or starts-with(.,'　')]", @"CheckBox.Content属性の先頭に空白があります", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0713_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0714_OK.xaml", "WpfXaml")]
		public void WPFXA0714_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0714", "Error", @"//*[name(.)='CheckBox']/@Content[substring(.,string-length())=' ' or substring(.,string-length())='　']", @"CheckBox.Content属性の末尾に空白があります", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0714_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0714_NG2.xaml", "WpfXaml")]
		public void WPFXA0714_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0714", "Error", @"//*[name(.)='CheckBox']/@Content[substring(.,string-length())=' ' or substring(.,string-length())='　']", @"CheckBox.Content属性の末尾に空白があります", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0714_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0801_OK.xaml", "WpfXaml")]
		public void WPFXA0801_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0801", "Default", @"//*[name(.)='Button']/@Visibility[.='Visible']", @"Button.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0801_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0801_NG1.xaml", "WpfXaml")]
		public void WPFXA0801_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0801", "Default", @"//*[name(.)='Button']/@Visibility[.='Visible']", @"Button.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0801_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0802_OK.xaml", "WpfXaml")]
		public void WPFXA0802_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0802", "Default", @"//*[name(.)='Button']/@IsEnabled[.='True']", @"Button.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0802_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0802_NG1.xaml", "WpfXaml")]
		public void WPFXA0802_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0802", "Default", @"//*[name(.)='Button']/@IsEnabled[.='True']", @"Button.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0802_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0803_OK.xaml", "WpfXaml")]
		public void WPFXA0803_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0803", "Default", @"//*[name(.)='Button']/@HorizontalAlignment[.='Stretch']", @"Button.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0803_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0803_NG1.xaml", "WpfXaml")]
		public void WPFXA0803_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0803", "Default", @"//*[name(.)='Button']/@HorizontalAlignment[.='Stretch']", @"Button.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0803_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0804_OK.xaml", "WpfXaml")]
		public void WPFXA0804_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0804", "Default", @"//*[name(.)='Button']/@VerticalAlignment[.='Stretch']", @"Button.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0804_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0804_NG1.xaml", "WpfXaml")]
		public void WPFXA0804_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0804", "Default", @"//*[name(.)='Button']/@VerticalAlignment[.='Stretch']", @"Button.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0804_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0805_OK.xaml", "WpfXaml")]
		public void WPFXA0805_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0805", "Default", @"//*[name(.)='Button']/@HorizontalContentAlignment[.='Center']", @"Button.HorizontalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0805_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0805_NG1.xaml", "WpfXaml")]
		public void WPFXA0805_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0805", "Default", @"//*[name(.)='Button']/@HorizontalContentAlignment[.='Center']", @"Button.HorizontalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0805_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0806_OK.xaml", "WpfXaml")]
		public void WPFXA0806_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0806", "Default", @"//*[name(.)='Button']/@VerticalContentAlignment[.='Center']", @"Button.VerticalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0806_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0806_NG1.xaml", "WpfXaml")]
		public void WPFXA0806_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0806", "Default", @"//*[name(.)='Button']/@VerticalContentAlignment[.='Center']", @"Button.VerticalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0806_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0807_OK.xaml", "WpfXaml")]
		public void WPFXA0807_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0807", "Default", @"//*[name(.)='Button'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Button.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0807_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0807_NG5.xaml", "WpfXaml")]
		public void WPFXA0807_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0807", "Default", @"//*[name(.)='Button'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"Button.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0807_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0808_OK.xaml", "WpfXaml")]
		public void WPFXA0808_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0808", "Default", @"//*[name(.)='Button'][not(@Name)]/@Padding[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"Button.Padding=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0808_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0808_NG5.xaml", "WpfXaml")]
		public void WPFXA0808_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0808", "Default", @"//*[name(.)='Button'][not(@Name)]/@Padding[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"Button.Padding=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0808_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0809_OK.xaml", "WpfXaml")]
		public void WPFXA0809_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0809", "Default", @"//*[name(.)='Button'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"Button.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0809_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0809_NG5.xaml", "WpfXaml")]
		public void WPFXA0809_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0809", "Default", @"//*[name(.)='Button'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"Button.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0809_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0810_OK.xaml", "WpfXaml")]
		public void WPFXA0810_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0810", "Default", @"//*[name(.)='Button'][not(@Name)]/@Background[.='#FF1F3B53' or .='#1F3B53']", @"Button.Background=""#FF1F3B53""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0810_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0810_NG2.xaml", "WpfXaml")]
		public void WPFXA0810_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0810", "Default", @"//*[name(.)='Button'][not(@Name)]/@Background[.='#FF1F3B53' or .='#1F3B53']", @"Button.Background=""#FF1F3B53""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0810_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0901_OK.xaml", "WpfXaml")]
		public void WPFXA0901_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0901", "Default", @"//*[name(.)='ListBox']/@Visibility[.='Visible']", @"ListBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0901_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0901_NG1.xaml", "WpfXaml")]
		public void WPFXA0901_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0901", "Default", @"//*[name(.)='ListBox']/@Visibility[.='Visible']", @"ListBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0901_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0902_OK.xaml", "WpfXaml")]
		public void WPFXA0902_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0902", "Default", @"//*[name(.)='ListBox']/@IsEnabled[.='True']", @"ListBox.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0902_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0902_NG1.xaml", "WpfXaml")]
		public void WPFXA0902_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0902", "Default", @"//*[name(.)='ListBox']/@IsEnabled[.='True']", @"ListBox.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0902_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0903_OK.xaml", "WpfXaml")]
		public void WPFXA0903_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0903", "Default", @"//*[name(.)='ListBox']/@HorizontalAlignment[.='Stretch']", @"ListBox.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0903_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0903_NG1.xaml", "WpfXaml")]
		public void WPFXA0903_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0903", "Default", @"//*[name(.)='ListBox']/@HorizontalAlignment[.='Stretch']", @"ListBox.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0903_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0904_OK.xaml", "WpfXaml")]
		public void WPFXA0904_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0904", "Default", @"//*[name(.)='ListBox']/@VerticalAlignment[.='Stretch']", @"ListBox.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0904_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0904_NG1.xaml", "WpfXaml")]
		public void WPFXA0904_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0904", "Default", @"//*[name(.)='ListBox']/@VerticalAlignment[.='Stretch']", @"ListBox.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0904_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0905_OK.xaml", "WpfXaml")]
		public void WPFXA0905_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0905", "Default", @"//*[name(.)='ListBox']/@HorizontalContentAlignment[.='Left']", @"ListBox.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0905_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0905_NG1.xaml", "WpfXaml")]
		public void WPFXA0905_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0905", "Default", @"//*[name(.)='ListBox']/@HorizontalContentAlignment[.='Left']", @"ListBox.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0905_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0906_OK.xaml", "WpfXaml")]
		public void WPFXA0906_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0906", "Default", @"//*[name(.)='ListBox']/@VerticalContentAlignment[.='Center']", @"ListBox.VerticalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0906_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0906_NG1.xaml", "WpfXaml")]
		public void WPFXA0906_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0906", "Default", @"//*[name(.)='ListBox']/@VerticalContentAlignment[.='Center']", @"ListBox.VerticalContentAlignment=""Center""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0906_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0907_OK.xaml", "WpfXaml")]
		public void WPFXA0907_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0907", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ListBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0907_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0907_NG5.xaml", "WpfXaml")]
		public void WPFXA0907_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0907", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ListBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0907_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0908_OK.xaml", "WpfXaml")]
		public void WPFXA0908_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0908", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ListBox.Padding=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0908_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0908_NG5.xaml", "WpfXaml")]
		public void WPFXA0908_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0908", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@Padding[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ListBox.Padding=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0908_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0909_OK.xaml", "WpfXaml")]
		public void WPFXA0909_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0909", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"ListBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0909_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0909_NG5.xaml", "WpfXaml")]
		public void WPFXA0909_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0909", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"ListBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0909_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0910_OK.xaml", "WpfXaml")]
		public void WPFXA0910_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0910", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@Background[.='White' or .='#FFFFFFFF' or .='#FFFFFF']", @"ListBox.Background=""White""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0910_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0910_NG3.xaml", "WpfXaml")]
		public void WPFXA0910_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0910", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@Background[.='White' or .='#FFFFFFFF' or .='#FFFFFF']", @"ListBox.Background=""White""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0910_NG3.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(3, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0911_OK.xaml", "WpfXaml")]
		public void WPFXA0911_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0911", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@*[name(.)='ScrollViewer.HorizontalScrollBarVisibility'][.='Auto']", @"ListBox.HorizontalScrollBarVisibility=""Auto""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0911_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0911_NG1.xaml", "WpfXaml")]
		public void WPFXA0911_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0911", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@*[name(.)='ScrollViewer.HorizontalScrollBarVisibility'][.='Auto']", @"ListBox.HorizontalScrollBarVisibility=""Auto""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0911_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0912_OK.xaml", "WpfXaml")]
		public void WPFXA0912_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0912", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@*[name(.)='ScrollViewer.VerticalScrollBarVisibility'][.='Auto']", @"ListBox.VerticalScrollBarVisibility=""Auto""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0912_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA0912_NG1.xaml", "WpfXaml")]
		public void WPFXA0912_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA0912", "Default", @"//*[name(.)='ListBox'][not(@Name)]/@*[name(.)='ScrollViewer.VerticalScrollBarVisibility'][.='Auto']", @"ListBox.VerticalScrollBarVisibility=""Auto""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA0912_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1001_OK.xaml", "WpfXaml")]
		public void WPFXA1001_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1001", "Default", @"//*[name(.)='ComboBox']/@Visibility[.='Visible']", @"ComboBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1001_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1001_NG1.xaml", "WpfXaml")]
		public void WPFXA1001_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1001", "Default", @"//*[name(.)='ComboBox']/@Visibility[.='Visible']", @"ComboBox.Visibility=""Visible""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1001_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1002_OK.xaml", "WpfXaml")]
		public void WPFXA1002_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1002", "Default", @"//*[name(.)='ComboBox']/@IsEnabled[.='True']", @"ComboBox.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1002_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1002_NG1.xaml", "WpfXaml")]
		public void WPFXA1002_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1002", "Default", @"//*[name(.)='ComboBox']/@IsEnabled[.='True']", @"ComboBox.IsEnabled=""True""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1002_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1003_OK.xaml", "WpfXaml")]
		public void WPFXA1003_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1003", "Default", @"//*[name(.)='ComboBox']/@HorizontalAlignment[.='Stretch']", @"ComboBox.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1003_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1003_NG1.xaml", "WpfXaml")]
		public void WPFXA1003_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1003", "Default", @"//*[name(.)='ComboBox']/@HorizontalAlignment[.='Stretch']", @"ComboBox.HorizontalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1003_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1004_OK.xaml", "WpfXaml")]
		public void WPFXA1004_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1004", "Default", @"//*[name(.)='ComboBox']/@VerticalAlignment[.='Stretch']", @"ComboBox.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1004_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1004_NG1.xaml", "WpfXaml")]
		public void WPFXA1004_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1004", "Default", @"//*[name(.)='ComboBox']/@VerticalAlignment[.='Stretch']", @"ComboBox.VerticalAlignment=""Stretch""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1004_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1005_OK.xaml", "WpfXaml")]
		public void WPFXA1005_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1005", "Default", @"//*[name(.)='ComboBox']/@HorizontalContentAlignment[.='Left']", @"ComboBox.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1005_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1005_NG1.xaml", "WpfXaml")]
		public void WPFXA1005_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1005", "Default", @"//*[name(.)='ComboBox']/@HorizontalContentAlignment[.='Left']", @"ComboBox.HorizontalContentAlignment=""Left""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1005_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1006_OK.xaml", "WpfXaml")]
		public void WPFXA1006_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1006", "Default", @"//*[name(.)='ComboBox']/@VerticalContentAlignment[.='Top']", @"ComboBox.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1006_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1006_NG1.xaml", "WpfXaml")]
		public void WPFXA1006_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1006", "Default", @"//*[name(.)='ComboBox']/@VerticalContentAlignment[.='Top']", @"ComboBox.VerticalContentAlignment=""Top""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1006_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1007_OK.xaml", "WpfXaml")]
		public void WPFXA1007_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1007", "Default", @"//*[name(.)='ComboBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ComboBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1007_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1007_NG5.xaml", "WpfXaml")]
		public void WPFXA1007_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1007", "Default", @"//*[name(.)='ComboBox'][not(@Name)]/@Margin[.='0' or .='0,0' or .='0 0' or .='0,0,0,0' or .='0 0 0 0']", @"ComboBox.Margin=""0""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1007_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1008_OK.xaml", "WpfXaml")]
		public void WPFXA1008_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1008", "Default", @"//*[name(.)='ComboBox'][not(@Name)]/@Padding[.='6,3,5,3' or .='6 3 5 3']", @"ComboBox.Padding=""6,3,5,3""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1008_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1008_NG2.xaml", "WpfXaml")]
		public void WPFXA1008_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1008", "Default", @"//*[name(.)='ComboBox'][not(@Name)]/@Padding[.='6,3,5,3' or .='6 3 5 3']", @"ComboBox.Padding=""6,3,5,3""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1008_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1009_OK.xaml", "WpfXaml")]
		public void WPFXA1009_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1009", "Default", @"//*[name(.)='ComboBox'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"ComboBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1009_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA1009_NG5.xaml", "WpfXaml")]
		public void WPFXA1009_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA1009", "Default", @"//*[name(.)='ComboBox'][not(@Name)]/@BorderThickness[.='1' or .='1,1' or .='1 1' or .='1,1,1,1' or .='1 1 1 1']", @"ComboBox.BorderThickness=""1""はデフォルト値です。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA1009_NG5.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(5, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA9998_OK.xaml", "WpfXaml")]
		public void WPFXA9998_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA9998", "Info", @"//namespace::*[not(name()='xml')][not(parent::*/parent::*)][not(.=namespace-uri(parent::*))][not(ext:used-namespace(parent::*/descendant-or-self::*) or ext:used-namespace(parent::*/descendant-or-self::*/@*))]", @"宣言されたNamespaceが使用されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA9998_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA9998_NG1.xaml", "WpfXaml")]
		public void WPFXA9998_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA9998", "Info", @"//namespace::*[not(name()='xml')][not(parent::*/parent::*)][not(.=namespace-uri(parent::*))][not(ext:used-namespace(parent::*/descendant-or-self::*) or ext:used-namespace(parent::*/descendant-or-self::*/@*))]", @"宣言されたNamespaceが使用されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA9998_NG1.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(1, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA9999_OK.xaml", "WpfXaml")]
		public void WPFXA9999_OK()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA9999", "Info", @"//@*[local-name(.)='Key'][not(ext:contains-any(parent::*/following::*/@*))]", @"Keyが使用されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA9999_OK.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(0, errorInstances.Count);
		}

		[TestMethod]
		[TestCategory("WpfRule")]
		[DeploymentItem(@"WpfXaml\WPFXA9999_NG2.xaml", "WpfXaml")]
		public void WPFXA9999_NG()
		{
			var rule = new XmlRuleXPath(string.Empty, 0, new string[] { "WPFXA9999", "Info", @"//@*[local-name(.)='Key'][not(ext:contains-any(parent::*/following::*/@*))]", @"Keyが使用されていません。", });
			var xaml = File.ReadAllText(@"WpfXaml\WPFXA9999_NG2.xaml");
			var xdoc = XDocument.Parse(xaml, LoadOptions.SetLineInfo);
			var errorInstances = GetErrorInstances(xdoc, rule);
			Assert.AreEqual(2, errorInstances.Count);
		}

		private static List<XObject> GetErrorInstances(XDocument xdoc, XmlRuleXPath rule)
		{
			var resolver = new CustomContext();
			resolver.AddNamespace("ext", "http://ext");
			return ((IEnumerable<object>)xdoc.XPathEvaluate(rule.XPath, resolver)).Cast<XObject>().ToList();
		}
	}
}
