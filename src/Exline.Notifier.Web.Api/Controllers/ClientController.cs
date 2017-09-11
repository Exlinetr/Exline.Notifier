using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    public class ClientController : BaseController<Core.Services.ClientService>
    {
        public ClientController() : base()
        {
            Service = new Core.Services.ClientService(Config);
        }

        [HttpPost]
        [Route("api/client/create")]
        public Result<Core.Services.Models.Client> Create(Models.Request.RequestClientModel client)
        {
            return Service.Create(client.Token, client.DeviceType);
        }

        [HttpDelete]
        [Route("api/client/{id}/delete")]
        public Result DeleleteById(string id)
        {
            return Service.Remove(id);
        }

        [HttpPatch]
        [Route("api/client/{id}/token")]
        public Result TokenUpdate(string id, string token)
        {
            return Service.TokenUpdate(id, token);
        }

        [HttpGet]
        [Route("api/client/{id}")]
        public Result<Core.Services.Models.Client> GetById(string id)
        {
            return Service.GetById(id);
        }

        [HttpGet]
        [Route("api/client/{id}/token")]
        public Result<string> GetToken(string id)
        {
            return Service.GetTokenById(id);
        }

        [HttpGet]
        [Route("api/clients/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Client>> GetList(int pageIndex,int pageSize)
        {
            return Service.GetList(pageIndex, pageSize);
        }
    }
}