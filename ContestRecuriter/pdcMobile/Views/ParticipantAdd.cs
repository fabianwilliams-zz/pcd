using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
//using UIKit;
using Xamarin.Forms;

namespace pdcMobile
{
	public class ParticipantAdd : ContentPage
	{
		private GEntryService gService = new GEntryService();

		public ParticipantAdd (string twitID)
		{
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			Title = "Register Contestant";

			var narrativeLabel = new Label {
				Text = "You have been Authenticated through Twitter & given a Uniuque" +
					" Id of "+ twitID +" There is only one more step to complete." +
					" Please fill out this breif survey to be entered. The information" +
					" is also used to alert you of any Prize Winnings"
			};

			var addMeButton = new Button {
//				HorizontalOptions = LayoutOptions.CenterAndExpand,
//				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				Text = "Add Me Please"
			};

			addMeButton.Clicked += async (object sender, EventArgs e) => {
				await gService.SyncAsync();
			};
					

			Content = new StackLayout {
				Spacing = 20,
				Children = {narrativeLabel, addMeButton}

			};
					
		}

//		protected async override void OnAppearing()
//		{
//			base.OnAppearing ();
//			//await gService.IsAuthenticated ();
//		}



	}
}

