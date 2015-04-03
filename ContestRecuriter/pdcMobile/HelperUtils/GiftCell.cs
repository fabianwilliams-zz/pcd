using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace pdcMobile
{
	public class GiftCell : ViewCell
	{
		public GiftCell ()
		{
			var ShortNameLabel = new Label {

				Font = Font.SystemFontOfSize (NamedSize.Medium)
			};
			ShortNameLabel.SetBinding (Label.TextProperty, new Binding ("ShortName"));

			var GiveAwayDTLabel = new Label {
				Font = Font.SystemFontOfSize (NamedSize.Medium),
				XAlign = TextAlignment.End,
				HorizontalOptions = LayoutOptions.FillAndExpand

			};
			GiveAwayDTLabel.SetBinding (Label.TextProperty, new Binding ("GiveAwayDateTime"));


			View = new StackLayout {
				Children = {ShortNameLabel, GiveAwayDTLabel},
				Orientation = StackOrientation.Horizontal

			};
		}
	}
}

