﻿using System;
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
		public List<Participant> currPar = new List<Participant>();

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
					await gService.SyncAsync();
					if (gService.User != null)
					{
						if (gService.Contestant.Count > 0)
						{
							//Console.WriteLine(gService.Contestant[0].UserSocialID);
							var currPar = gService.Contestant;
							await Navigation.PushAsync(new ContestEntryAdd(currPar as Participant));
						}
						else
						{
							await Navigation.PushAsync(new ParticipantAdd());
						}
					}
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
	}
}

