using System.Xml.XPath;
using System.Xml.Xsl;

namespace XmlChecker
{
	public class ContainsAnyFunction : IXsltContextFunction
	{
		public int Minargs => 2;
		public int Maxargs => 2;
		public XPathResultType[] ArgTypes => new[] { XPathResultType.Navigator, XPathResultType.Navigator, };
		public XPathResultType ReturnType => XPathResultType.Boolean;

		public ContainsAnyFunction()
		{
		}

		public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext)
		{
			var item2 = (string)args[1];
			foreach (XPathNavigator item in (XPathNodeIterator)args[0])
			{
				if (item.Value.Contains(item2))
				{
					return true;
				}
			}

			return false;
		}
	}
}
