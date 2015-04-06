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
		public ContestEntryAdd (List<Participant> pa)
		{
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			Title = "Prize Giveaway Entry";

			var SocialIDLabel = new Label {
				Text = pa[0].UserSocialID,
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var ParticipantNameLabel = new Label {
				Text = pa[0].Name,
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var GoodLuckMessageLabel = new Label {
				Text = "Thank you for your Entry " + pa[0].Name + ". You are now entered and should you" +
					" win, you will be notified by a text to " + pa[0].MobilePhone + " or an email" +
					" to " + pa[0].EmailAddress
			};

			var enterToWinButton = new Button {

			};

			var changeMyInfoButton = new Button {

			};

			Content = new StackLayout {

				Children = {SocialIDLabel, ParticipantNameLabel, GoodLuckMessageLabel}

			};

		}
	}
}

