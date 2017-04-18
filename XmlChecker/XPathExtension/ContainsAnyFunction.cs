using System.Xml.XPath;
using System.Xml.Xsl;

namespace XmlChecker
{
	public class ContainsAnyFunction : IXsltContextFunction
	{
		public int Minargs => 1;
		public int Maxargs => 1;
		public XPathResultType[] ArgTypes => new[] { XPathResultType.Navigator, };
		public XPathResultType ReturnType => XPathResultType.Boolean;

		public ContainsAnyFunction()
		{
		}

		public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext)
		{
			foreach (XPathNavigator item in (XPathNodeIterator)args[0])
			{
				if (item.Value.Contains(docContext.Value))
				{
					return true;
				}
			}

			return false;
		}
	}
}
