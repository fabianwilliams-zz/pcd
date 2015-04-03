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
	public class GEntryService
	{
		private MobileServiceClient MobileService = new MobileServiceClient(
			"https://pcdserver.azure-mobile.net/",
			"OLJpreavvHyJUHafYxKmRvafIhjqvY37"
		);


	}
}

