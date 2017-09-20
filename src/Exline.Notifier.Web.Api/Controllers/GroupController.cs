using System;
using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    [CustomAuthorize]
    public class GroupController
        : BaseController<Core.Services.GroupService>
    {
        public GroupController()
            : base()
        {

        }

        [HttpPost]
        [Route("api/{applicationId}/group/create")]
        public Result<Core.Services.Models.Group> Create(string applicationId, [FromBody]Models.Request.RequestGroupModel group)
        {
            Service = new Core.Services.GroupService(applicationId, Config);
            Result<Core.Services.Models.Group> result = Service.Create(group.Name);
            Result = result;
            return result;
        }

        [HttpDelete]
        [Route("api/{applicationId}/group/{id}")]
        public Result DeleteById(string applicationId, string id)
        {
            Service = new Core.Services.GroupService(applicationId, Config);
            Result = Service.Remove(id);
            return Result;
        }
        [HttpPatch]
        [Route("api/{applicationId}/group/{id}/name")]
        public Result NameUpdate(string applicationId, string id, string name)
        {
            Service = new Core.Services.GroupService(applicationId, Config);
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/{applicationId}/groups/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Group>> GetList(string applicationId, int pageIndex, int pageSize)
        {
            Service = new Core.Services.GroupService(applicationId, Config);
            Result<PaginationResult<Core.Services.Models.Group>> result = Service.GetList(pageIndex, pageSize);
            Result = result;
            return result;
        }

        [HttpPost]
        [Route("api/{applicationId}/group/{id}/clientadd")]
        public Result ClientAdd(string applicationId, string id, string clientId)
        {
            Service = new Core.Services.GroupService(applicationId, Config);
            Result = Service.ClientAdd(id, clientId);
            return Result;
        }

        [HttpDelete]
        [Route("api/{applicationId}/group/{id}/clientremove")]
        public Result ClientRemove(string applicationId, string id, string clientId)
        {
            Service = new Core.Services.GroupService(applicationId, Config);
            Result = Service.ClientRemove(id, clientId);
            return Result;
        }

        [HttpGet]
        [Route("api/{applicationId}/group/{id}/clients/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Client>> GetClients(string applicationId, string id, int pageIndex, int pageSize)
        {
            Service = new Core.Services.GroupService(applicationId, Config);
            Result<PaginationResult<Core.Services.Models.Client>> result=Service.GetClients(id, pageIndex, pageSize);
            Result=result;
            return result;

        }

    }
}