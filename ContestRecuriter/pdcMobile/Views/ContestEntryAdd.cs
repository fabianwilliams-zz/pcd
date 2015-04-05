using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pdcMobile
{
	public class ContestEntryAdd : ContentPage
	{
		public ContestEntryAdd (Participant pa)
		{
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			Title = "Prize Giveaway Entry";

			var SocialIDLabel = new Label {
				Text = pa.UserSocialID,
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var ParticipantNameLabel = new Label {
				Text = pa.Name,
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var GoodLuckMessageLabel = new Label {
				Text = "Thank you for your Entry" + pa.Name
			};

			Content = new StackLayout {

				Children = {SocialIDLabel, ParticipantNameLabel, GoodLuckMessageLabel}

			};

		}
	}
}

