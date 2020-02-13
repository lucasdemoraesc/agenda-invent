using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace AgendaInvent.Api.Controllers
{
	[Authorize]
	public class TestController : ApiController
	{
		public string Get()
		{
			return User.Identity.Name;
		}
	}
}