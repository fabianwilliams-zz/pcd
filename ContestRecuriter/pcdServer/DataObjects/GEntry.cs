using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace pcdServer.DataObjects
{
    public class GEntry : EntityData
    {
        public String UserSocialID { get; set; }
        public String AssetTag { get; set; }
        public String ShortName { get; set; }
    }
}