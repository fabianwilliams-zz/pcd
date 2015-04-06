using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;

namespace pdcMobile
{
	public class GiveAway
	{
		public String Id { get; set;}
		public String AssetTag { get; set; }
		public String Name { get; set; }
		public String ShortName { get; set; }
		public String Description { get; set; }
		public String EventName { get; set; }
		public String GiveAwayOfficialEmail { get; set; }
		public String GiveAwayOfficialName { get; set; }
		public DateTime GiveAwayDateTime { get; set; }
		public String PicURL { get; set; }
	}
}

