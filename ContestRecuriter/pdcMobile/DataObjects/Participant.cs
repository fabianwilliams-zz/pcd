using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;


namespace pdcMobile
{
	public class Participant
	{
		public String Id { get; set;}
		public string UserSocialID { get; set; }
		public string UserSocialName { get; set; }
		public string Name { get; set; }
		public string EmailAddress { get; set; }
		public string MobilePhone { get; set; }
		public bool ITPro { get; set; }
		public bool Developer { get; set; }
		public bool BusinessAnalyst { get; set; }
		public string Other { get; set; }
	}
}

