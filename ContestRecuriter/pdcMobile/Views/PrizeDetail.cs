using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using UIKit;

namespace pdcMobile
{
	public class PrizeDetail : ContentPage
	{
		private GEntryService gService = new GEntryService();

		public PrizeDetail (GiveAway ga)
		{
			Padding = new Thickness (0, Device.OnPlatform (20, 10, 10), 0, 0);
			this.Title = ga.ShortName;

			var giftImage = new Image {
				Aspect = Aspect.AspectFit
			};

			var picUrl = ga.PicURL;
			giftImage.Source = ImageSource.FromUri (new Uri (picUrl));

			var GiftNameLabel = new Label {
				Text = ga.Name,
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var GiftDesc = new Label {
				Text = ga.Description,
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};

			var GAOfficial = new Label {
				Text = ga.GiveAwayOfficialName,
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};

			var drawingButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				Text = "Win a " + ga.ShortName
			};

			drawingButton.Clicked += async (object sender, EventArgs e) => {
				try 
				{
					await Navigation.PushAsync(new ParticipantAdd());
				} 
				catch (Exception ex) 
				{
					Console.Error.WriteLine (@"ERROR {0}", ex.Message);
				
				}
			};

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 10,
					Children = {giftImage, GiftNameLabel, GiftDesc, GAOfficial, drawingButton}
				}
			};

		}
		private async Task CheckUserAuth()
		{
			if (gService.User == null)
			{
				await gService.IsAuthenticated();
				if (gService.User == null) {
					await Navigation.PushAsync (new ParticipantAdd ()); //Push the User to 
					Console.WriteLine ("couldn't login!!");
					return;
				} else {
					await Navigation.PushAsync (new ContestEntryAdd ());
				}
			}
		}
	}
}

