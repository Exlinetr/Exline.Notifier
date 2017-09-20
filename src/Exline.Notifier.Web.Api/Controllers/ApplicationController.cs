using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    [Authorize]
    public class ApplicationController : BaseController<Exline.Notifier.Core.Services.ApplicationService>
    {
        public ApplicationController() : base()
        {
        }

        [HttpPost]
        [Route("api/application")]
        public Result<Core.Services.Models.Application> Create([FromBody]Models.Request.RequestApplicationModel application)
        {
            Service = new Core.Services.ApplicationService(Config);
            Result<Core.Services.Models.Application> result = Service.Create(application.Name);
            Result = result;
            return result;
        }

        [HttpDelete]
        [Route("api/application/{id}")]
        public Result DeleleteById(string id)
        {
            Service = new Core.Services.ApplicationService(Config);
            Result = Service.Remove(id);
            return Result;
        }
        [HttpGet]
        [Route("api/application/{id}")]
        public Result<Core.Services.Models.Application> GetById(string id)
        {
            Service = new Core.Services.ApplicationService(Config);
            Result<Core.Services.Models.Application> result = Service.GetById(id);
            Result = result;
            return result;
        }

        [HttpGet]
        [Route("api/applications/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Application>> GetList(int pageIndex, int pageSize)
        {
            Service = new Core.Services.ApplicationService(Config);
            Result<PaginationResult<Core.Services.Models.Application>> result = Service.GetList(pageIndex, pageSize);
            Result = result;
            return result;
        }

    }
}