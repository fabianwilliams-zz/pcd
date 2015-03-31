using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using pcdServer.DataObjects;
using pcdServer.Models;

namespace pcdServer.Controllers
{
    public class GEntryController : TableController<GEntry>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<GEntry>(context, Request, Services);
        }

        // GET tables/GEntry
        public IQueryable<GEntry> GetAllGEntry()
        {
            return Query(); 
        }

        // GET tables/GEntry/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<GEntry> GetGEntry(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/GEntry/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<GEntry> PatchGEntry(string id, Delta<GEntry> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/GEntry
        public async Task<IHttpActionResult> PostGEntry(GEntry item)
        {
            GEntry current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/GEntry/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGEntry(string id)
        {
             return DeleteAsync(id);
        }

    }
}