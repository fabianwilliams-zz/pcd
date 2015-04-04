using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Xamarin.Forms;
#if __IOS__
using UIKit;
#elif __ANDROID__
using Mono;
#endif
using System.Threading;

namespace pdcMobile
{
	public class GEntryService
	{
		//Mobile User Login
		private MobileServiceUser user;
		public MobileServiceUser User { get { return user; } }

		private MobileServiceClient MobileService = new MobileServiceClient(
			"https://pcdserver.azure-mobile.net/",
			"OLJpreavvHyJUHafYxKmRvafIhjqvY37"
		);



		public async Task<bool> IsAuthenticated()
		{
			if(this.MobileService.CurrentUser == null)
			{
				await this.MobileService.LoginAsync(App.UIContext, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
			}

			return this.MobileService.CurrentUser != null;                
		}

		public List<GEntry> Items { get; private set;}
		public List<Participant> Contestant { get; private set; }

		private IMobileServiceSyncTable<GEntry> gentryTable;
		private IMobileServiceSyncTable<Participant> pTable;

		public async Task InitializeAsync()
		{
			var store = new MobileServiceSQLiteStore("localdata.db");
			store.DefineTable<GEntry> ();
			await this.MobileService.SyncContext.InitializeAsync(store);

			gentryTable = this.MobileService.GetSyncTable<GEntry>();
			pTable = this.MobileService.GetSyncTable<Participant> ();
		}

		public async Task SyncAsync()
		{
			//Comment this back in if you want auth
			if (!await IsAuthenticated())
			    return;
			await InitializeAsync();
			await this.MobileService.SyncContext.PushAsync();

			var query1 = gentryTable.CreateQuery()
				//.Where(td => td.Retire == false)
				;
			var query2 = pTable.CreateQuery ();

			await gentryTable.PullAsync("GEntry", query1);
			await pTable.PullAsync ("Participant", query2);
		}

		public async Task InsertGEntryAsync (GEntry ge)
		{
			try 
			{
				await gentryTable.InsertAsync(ge);
				await SyncAsync();
			} 
			catch (MobileServiceInvalidOperationException e) 
			{
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

		public async Task<List<Participant>> FindParticipants()
		{
			try 
			{
				await SyncAsync(); 
				Contestant = await pTable
					.Where (c => c.UserSocialID == user.UserId).ToListAsync();
			} 
			catch (MobileServiceInvalidOperationException e) 
			{
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
				return null;
			}
			return Contestant;
		}

	}
}

