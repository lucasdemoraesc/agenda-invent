using AgendaInvent.Api.Models;
using AgendaInvent.Common.Resources;
using AgendaInvent.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgendaInvent.Api.Controllers
{
    [RoutePrefix("api/contacts")]
    public class AgendaController : ApiController
    {
        private IContactService _service;

        public AgendaController(IContactService service)
        {
            _service = service;
        }

        // /api/agenda - Post
        [Authorize]
        [HttpPost]
        public Task<HttpResponseMessage> Register(RegisterContactModel CttModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Register(CttModel.Name, CttModel.Phone);
                response = Request.CreateResponse(HttpStatusCode.OK, Messages.RegisteredSuccessfully);
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Authorize]
        [HttpDelete]
        public Task<HttpResponseMessage> Remove(RemoveContactModel CttModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Remove(CttModel.Phone);
                response = Request.CreateResponse(HttpStatusCode.OK, Messages.SuccessfullyRemoved);
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
