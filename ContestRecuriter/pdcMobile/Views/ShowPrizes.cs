using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pdcMobile
{
	public class ShowPrizes : ContentPage
	{
		private ListView listView;
		private SearchBar searchBar;
		private GiveAwayService giveawayService;
		public List<GiveAway> Items { get; private set; }

		public ShowPrizes ()
		{
			giveawayService = new GiveAwayService ();

			listView = new ListView {
				HasUnevenRows = true

			};
			//need to add a Details Push Event on the ITemSelected here when working done
			listView.ItemSelected += (sender, e) => {
				Navigation.PushAsync(new PrizeDetail(e.SelectedItem as GiveAway));
			};

			searchBar = new SearchBar { Placeholder = "Enter Search" };
			searchBar.SearchButtonPressed += async (object sender, EventArgs e) => {
				await RefreshAsync();
			};

			var syncButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				Text = "Sync Me"
			};
			syncButton.Clicked += async (object sender, EventArgs e) => {
				try
				{
				syncButton.Text = "Syncing...";
				await giveawayService.SyncAsync();
				await this.RefreshAsync();
				}
				finally
				{
					syncButton.Text = "Synced";
				}
			};

			this.Title = "All Availale Drawings";
			this.Content = new StackLayout {
				Padding = new Thickness(0, Device.OnPlatform(20,0,0),0,0),
				Spacing = 10,
				Orientation = StackOrientation.Vertical,
				Children = {
					searchBar,
					new StackLayout {
						Orientation = StackOrientation.Horizontal,
						Children = {
							syncButton
						}
					},
					listView
				}

			};
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.RefreshAsync ();
		}

		private async Task RefreshAsync()
		{
			Items = await giveawayService.SearchTodo ();
			listView.ItemsSource = Items;

			var cell = new DataTemplate (typeof(TextCell));
			listView.ItemTemplate = new DataTemplate (typeof(GiftCell));
		}

	}
}

