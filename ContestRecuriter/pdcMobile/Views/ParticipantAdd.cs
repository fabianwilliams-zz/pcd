using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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

			Content = new StackLayout {

				Children = {}

			};
					
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await gService.IsAuthenticated ();
		}

	}
}

