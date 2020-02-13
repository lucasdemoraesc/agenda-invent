using AgendaInvent.Api.Models;
using AgendaInvent.Domain.Contracts.Services;
using AgendaInvent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgendaInvent.Api.Controllers
{
    public class AgendaController : ApiController
    {
        private IContactService _service;

        public AgendaController(IContactService service)
        {
            _service = service;
        }

        // /api/agenda - Post
        [HttpPost]
        public RegisterContactModel Register(RegisterContactModel CttModel)
        {
            try
            {
                _service.Register(CttModel.Name, CttModel.Phone);
                return CttModel;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
