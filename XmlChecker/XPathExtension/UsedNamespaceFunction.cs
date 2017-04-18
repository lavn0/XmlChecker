using System;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XmlChecker
{
	public class UsedNamespaceFunction : IXsltContextFunction
	{
		public int Minargs => 1;
		public int Maxargs => 1;
		public XPathResultType[] ArgTypes => new[] { XPathResultType.Navigator, };
		public XPathResultType ReturnType => XPathResultType.Navigator;

		public UsedNamespaceFunction()
		{
		}

		public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext)
		{
			if (docContext.NodeType != XPathNodeType.Namespace)
			{
				throw new ArgumentException("Namespaceが渡されていません。");
			}

			foreach (XPathNavigator item in (XPathNodeIterator)args[0])
			{
				if (item.NamespaceURI == docContext.Value)
				{
					return true;
				}
			}

			return false;
		}
	}
}
