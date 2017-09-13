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
            Service = new Core.Services.GroupService(Config);
        }

        [HttpPost]
        [Route("api/group/create")]
        public Result Create(Models.Request.RequestGroupModel group)
        {
            Result result = new Result();
            return result;
        }

        [HttpDelete]
        [Route("api/group/{id}/delete")]
        public Result DeleteById(string id)
        {
            return Service.Remove(id);
        }
        [HttpPatch]
        [Route("api/group/{id}/name")]
        public Result NameUpdate(string id, string name)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/groups/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Group>> GetList(int pageIndex, int pageSize)
        {
            return Service.GetList(pageIndex, pageSize);
        }

        [HttpPost]
        [Route("api/group/{id}/clientadd")]
        public Result ClientAdd(string id,string clientId)
        {
            return Service.ClientAdd(id,clientId);
        }

        [HttpDelete]
        [Route("api/group/{id}/clientremove")]
        public Result ClientRemove(string id,string clientId)
        {
            return Service.ClientRemove(id,clientId);
        }

        [HttpGet]
        [Route("api/group/{id}/clients/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Client>> GetClients(string id,int pageIndex,int pageSize)
        {
            return Service.GetClients(id,pageIndex,pageSize);

        }

    }
}