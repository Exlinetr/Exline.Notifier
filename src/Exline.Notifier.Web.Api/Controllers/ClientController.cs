using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    [CustomAuthorize]
    public class ClientController : BaseController<Core.Services.ClientService>
    {
        public ClientController() 
            : base()
        {
            //Service = new Core.Services.ClientService(Config);
        }

        [HttpPost]
        [Route("api/{applicationId}/client")]
        public Result<Core.Services.Models.Client> Create(string applicationId,[FromBody]Models.Request.RequestClientModel client)
        {
            Service = new Core.Services.ClientService(applicationId,Config);
            return Service.Create(client.Token, client.DeviceType);
        }

        [HttpDelete]
        [Route("api/{applicationId}/client/{id}")]
        public Result DeleleteById(string applicationId,string id)
        {
            Service = new Core.Services.ClientService(applicationId,Config);
            return Service.Remove(id);
        }

        [HttpPatch]
        [Route("api/{applicationId}/client/{id}/token")]
        public Result TokenUpdate(string applicationId,string id, string token)
        {
            Service = new Core.Services.ClientService(applicationId,Config);
            return Service.TokenUpdate(id, token);
        }

        [HttpGet]
        [Route("api/{applicationId}/client/{id}")]
        public Result<Core.Services.Models.Client> GetById(string applicationId,string id)
        {
            Service = new Core.Services.ClientService(applicationId,Config);
            return Service.GetById(id);
        }

        [HttpGet]
        [Route("api/{applicationId}/client/{id}/token")]
        public Result<string> GetToken(string applicationId,string id)
        {
            Service = new Core.Services.ClientService(applicationId,Config);
            return Service.GetTokenById(id);
        }

        [HttpGet]
        [Route("api/{applicationId}/clients/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Client>> GetList(string applicationId,int pageIndex,int pageSize)
        {
            Service = new Core.Services.ClientService(applicationId,Config);
            return Service.GetList(pageIndex, pageSize);
        }
    }
}