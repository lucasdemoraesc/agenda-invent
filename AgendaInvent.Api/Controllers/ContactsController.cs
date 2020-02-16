using AgendaInvent.Api.Attributes;
using AgendaInvent.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace AgendaInvent.Api.Controllers
{
	[RoutePrefix("api/contacts")]
	public class ContactsController : ApiController
	{
		private IContactService _service;

		public ContactsController(IContactService service)
		{
			_service = service;
		}

		[HttpGet]
		[Route("")]
		[Authorize]
		[DeflateCompression]
		//[CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
		public Task<HttpResponseMessage> Get()
		{
			HttpResponseMessage response = new HttpResponseMessage();

			try
			{
				var result = _service.GetByRange(0, 25);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			}
			catch (Exception ex)
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