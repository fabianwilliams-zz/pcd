using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms;

namespace pdcMobile
{
	public class ParticipantAdd : ContentPage
	{
		private GEntryService gService = new GEntryService();

		public ParticipantAdd ()
		{
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			Title = "Register Contestant";

			var authButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				Text = "Authenticate Me"
			};

			authButton.Clicked += async (object sender, EventArgs e) => {
				await gService.SyncAsync();
			};
					

			Content = new StackLayout {

				Children = {authButton}

			};
					
		}

//		protected async override void OnAppearing()
//		{
//			base.OnAppearing ();
//			//await gService.IsAuthenticated ();
//		}



	}
}

