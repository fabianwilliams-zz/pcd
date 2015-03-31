using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace pcdServer.DataObjects
{
    public class Participant : EntityData
    {
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