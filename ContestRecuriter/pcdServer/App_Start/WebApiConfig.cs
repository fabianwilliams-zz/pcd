using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using pcdServer.DataObjects;
using pcdServer.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace pcdServer
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            List<GiveAway> giveAways = new List<GiveAway>
            {
                new GiveAway {Id = Guid.NewGuid().ToString(), AssetTag = "012345", Name = "SwissGear Computer Backpack for 15.6-Inch Laptops", ShortName = "SwissGear BackPack", Description = "Large packing capacity to fit binders and anything else you need. Audio interface, Laptop compartment, Contoured shoulder straps, Airflow back system, Sunglasses holder and Mobile phone pocket", EventName = "SharePoint Evolution London", GiveAwayDateTime = new DateTime(2015,4,23,10,30,0), GiveAwayOfficialEmail = "xavier@fabiansworld.com", GiveAwayOfficialName = "Xavier Nicholas", PicURL = "http://ecx.images-amazon.com/images/I/51iZGeJYssL._AA160_.jpg"},
                new GiveAway {Id = Guid.NewGuid().ToString(), AssetTag = "678910", Name = "Logitech M510 Wireless Mouse", ShortName = "Wireless Mouse", Description = "Contoured shape with soft rubber grips provide all-day comfort. Back/forward buttons and side-to-side scrolling plus zoom let you do more. Comes with a tiny Logitech Unifying receiver that stays in your computer", EventName = "SharePoint Evolution London", GiveAwayDateTime = new DateTime(2015,4,23,13,30,0), GiveAwayOfficialEmail = "fabian@adotob.com", GiveAwayOfficialName = "Fabian Williams", PicURL = "http://ecx.images-amazon.com/images/I/41%2BcyeIQuSL._SL500_SR100,100_.jpg"},
                new GiveAway {Id = Guid.NewGuid().ToString(), AssetTag = "111213", Name = "Samsung 850 Pro 256GB 2.5-Inch SATA III Internal SSD (MZ-7KE256BW)", ShortName = "256GB SSD", Description = "Sequential read and write performance up to 550 megabytes per second and 520MB/s respectively, and random read and write input/output operations-per-second (IOPS) up to 100,000 and 90,000 each.", EventName = "SharePoint Evolution London", GiveAwayDateTime = new DateTime(2015,4,23,15,30,0), GiveAwayOfficialEmail = "catpaint1@twitter.com", GiveAwayOfficialName = "Cathy Dew", PicURL = "http://ecx.images-amazon.com/images/I/412M8LGGfrL._SL500_SR100,100_.jpg"},
                new GiveAway {Id = Guid.NewGuid().ToString(), AssetTag = "141516", Name = "Jabra REVO Wireless Bluetooth Stereo Headphones", ShortName = "Wireless Headphones", Description = "Touch controls on the headphone turntable for easy music and phone call management. Wireless or 3.5mm jack connector for corded option", EventName = "Microsoft Ignite Chicago", GiveAwayDateTime = new DateTime(2015,5,3,15,30,0), GiveAwayOfficialEmail = "fabian@adotob.com", GiveAwayOfficialName = "Fabian Williams", PicURL = "http://ecx.images-amazon.com/images/I/41dBtVssU3L._AA160_.jpg"},
                new GiveAway {Id = Guid.NewGuid().ToString(), AssetTag = "171819", Name = "Microsoft Surface Pro 3 (64 GB, Intel Core i3)", ShortName = "Surface Pro 3", Description = "Intel 4th Generation Core i3 Processor. 12-Inch HD (2160 x 1440) Touchscreen Display. 4 GB RAM; 64 GB Storage Capacity. Windows 8.1 Pro. 36W Power Supply and Surface Pen Included.", EventName = "Microsoft Ignite Chicago", GiveAwayDateTime = new DateTime(2015,5,4,15,30,0), GiveAwayOfficialEmail = "wbaer@microsoft.com", GiveAwayOfficialName = "William Baer", PicURL = "http://ecx.images-amazon.com/images/I/410G6h8sH3L._AA160_.jpg"}
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            foreach (GiveAway ga in giveAways)
            {
                context.Set<GiveAway>().Add(ga);
            }

            base.Seed(context);
        }
    }
}

