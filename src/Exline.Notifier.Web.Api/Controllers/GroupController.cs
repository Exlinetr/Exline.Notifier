using System;
using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    public class GroupController 
        : BaseController<Core.Services.GroupService>
    {
        public GroupController()
            : base()
        {
            
        }

        [HttpPost]
        [Route("api/{applicationId}/group/create")]
        public Result<Core.Services.Models.Group> Create(string applicationId,Models.Request.RequestGroupModel group)
        {
            Service = new Core.Services.GroupService(applicationId,Config);
            return Service.Create(group.Name);
        }

        [HttpDelete]
        [Route("api/{applicationId}/group/{id}")]
        public Result DeleteById(string applicationId,string id)
        {
            Service = new Core.Services.GroupService(applicationId,Config);
            return Service.Remove(id);
        }
        [HttpPatch]
        [Route("api/{applicationId}/group/{id}/name")]
        public Result NameUpdate(string applicationId,string id, string name)
        {
            Service = new Core.Services.GroupService(applicationId,Config);
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/{applicationId}/groups/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Group>> GetList(string applicationId,int pageIndex, int pageSize)
        {
            Service = new Core.Services.GroupService(applicationId,Config);
            return Service.GetList(pageIndex, pageSize);
        }

        [HttpPost]
        [Route("api/{applicationId}/group/{id}/clientadd")]
        public Result ClientAdd(string applicationId,string id,string clientId)
        {
            Service = new Core.Services.GroupService(applicationId,Config);
            return Service.ClientAdd(id,clientId);
        }

        [HttpDelete]
        [Route("api/{applicationId}/group/{id}/clientremove")]
        public Result ClientRemove(string applicationId,string id,string clientId)
        {
            Service = new Core.Services.GroupService(applicationId,Config);
            return Service.ClientRemove(id,clientId);
        }

        [HttpGet]
        [Route("api/{applicationId}/group/{id}/clients/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Client>> GetClients(string applicationId,string id,int pageIndex,int pageSize)
        {
            Service = new Core.Services.GroupService(applicationId,Config);
            return Service.GetClients(id,pageIndex,pageSize);

        }

    }
}