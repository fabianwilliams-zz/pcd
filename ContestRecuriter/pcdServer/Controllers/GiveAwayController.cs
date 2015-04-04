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

    public class GiveAwayController : TableController<GiveAway>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<GiveAway>(context, Request, Services);
        }

        // GET tables/GiveAway
        public IQueryable<GiveAway> GetAllGiveAway()
        {
            return Query(); 
        }

        // GET tables/GiveAway/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<GiveAway> GetGiveAway(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/GiveAway/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<GiveAway> PatchGiveAway(string id, Delta<GiveAway> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/GiveAway
        public async Task<IHttpActionResult> PostGiveAway(GiveAway item)
        {
            GiveAway current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/GiveAway/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGiveAway(string id)
        {
             return DeleteAsync(id);
        }

    }
}