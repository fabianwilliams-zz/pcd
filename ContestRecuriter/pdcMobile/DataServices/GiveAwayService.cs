using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#if __IOS__
using UIKit;
#elif __ANDROID__
using Mono;
#endif
using System.Threading;

namespace pdcMobile
{
	public class GiveAwayService
	{
		
		private MobileServiceClient MobileService = new MobileServiceClient(
			"https://pcdserver.azure-mobile.net/",
			"OLJpreavvHyJUHafYxKmRvafIhjqvY37"
		);

		public List<GiveAway> Items { get; private set;}

		private IMobileServiceSyncTable<GiveAway> giveawayTable;

		public async Task InitializeAsync()
		{
			var store = new MobileServiceSQLiteStore("localdata.db");
			store.DefineTable<GiveAway> ();
			await this.MobileService.SyncContext.InitializeAsync(store);

			giveawayTable = this.MobileService.GetSyncTable<GiveAway>();
		}

		public async Task SyncAsync()
		{
			// Comment this back in if you want auth
			//if (!await IsAuthenticated())
			//    return;
			await InitializeAsync();
			await this.MobileService.SyncContext.PushAsync();

			var query = giveawayTable.CreateQuery()
				//.Where(td => td.Retire == false)
				;

			await giveawayTable.PullAsync("GiveAways", query);
		}

		public async Task<IEnumerable<GiveAway>> SearchTodoItems(string searchInput)
		{
			await SyncAsync (); //ADDED THIS AFTER GETTING NULL EXCEPTION 
			var query = giveawayTable.CreateQuery ();

			if (!string.IsNullOrWhiteSpace(searchInput)) {
				query = query.Where (ga => 
					ga.Id == searchInput
					|| searchInput.ToUpper().Contains(ga.Name.ToUpper()) // workaround bug: these are backwards
					|| searchInput.ToUpper().Contains(ga.ShortName.ToUpper())
				);
			}

			return await query.ToEnumerableAsync();
		}

		public async Task<List<GiveAway>> SearchTodo()
		{
			try {
				// update the local store
				// all operations on todoTable use the local database, call SyncAsync to send changes
				await SyncAsync(); 							

				// This code refreshes the entries in the list view by querying the local TodoItems table.
				// The query excludes completed TodoItems -- not anymore
				//I took out todoItems.Complete and replaced it with todoItem.Remove -- Fabian Williams
				Items = await giveawayTable
					.Where (ga => ga.GiveAwayDateTime > DateTime.Now).ToListAsync ();

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
				return null;
			}

			return Items;
		}

	}
}


