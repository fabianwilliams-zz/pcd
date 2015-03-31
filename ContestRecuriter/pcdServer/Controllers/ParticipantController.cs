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
    public class ParticipantController : TableController<Participant>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Participant>(context, Request, Services);
        }

        // GET tables/Participant
        public IQueryable<Participant> GetAllParticipant()
        {
            return Query(); 
        }

        // GET tables/Participant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Participant> GetParticipant(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Participant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Participant> PatchParticipant(string id, Delta<Participant> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Participant
        public async Task<IHttpActionResult> PostParticipant(Participant item)
        {
            Participant current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Participant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteParticipant(string id)
        {
             return DeleteAsync(id);
        }

    }
}