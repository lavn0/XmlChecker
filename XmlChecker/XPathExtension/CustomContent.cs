using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XmlChecker
{
	public class CustomContext : XsltContext
	{
		public CustomContext() { }

		public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
		{
			switch (name)
			{
				case "contains-any": return new XPathRegExExtensionFunction();
			}

			return null;
		}

		public override IXsltContextVariable ResolveVariable(string prefix, string name) => null;
		public override int CompareDocument(string baseUri, string nextbaseUri) => 0;
		public override bool PreserveWhitespace(XPathNavigator node) => true;
		public override bool Whitespace => true;
	}
}
