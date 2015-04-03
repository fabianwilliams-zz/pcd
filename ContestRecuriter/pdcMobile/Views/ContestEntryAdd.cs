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
		public ContestEntryAdd ()
		{
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			Title = "Prize Giveaway Entry";

			var SocialIDLabel = new Label {

			};

			var ParticipantNameLabel = new Label {

			};

			var GoodLuckMessageLabel = new Label {

			};

			Content = new StackLayout {

				Children = {}

			};

		}
	}
}

