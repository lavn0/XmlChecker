using System.Windows;
using System.Windows.Controls.Primitives;

namespace SilverlightDummyControl
{
	public partial class HyperlinkButton : ButtonBase
	{
		static HyperlinkButton()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(HyperlinkButton), new FrameworkPropertyMetadata(typeof(HyperlinkButton)));
		}

		public HyperlinkButton()
		{
			InitializeComponent();
		}
	}
}
