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
            return Service.Create(application.Name);
        }

        [HttpDelete]
        [Route("api/application/{id}")]
        public Result DeleleteById(string id)
        {
            Service = new Core.Services.ApplicationService(Config);
            return Service.Remove(id);
        }
        [HttpGet]
        [Route("api/application/{id}")]
        public Result<Core.Services.Models.Application> GetById(string id)
        {
            Service = new Core.Services.ApplicationService(Config);
            return Service.GetById(id);
        }

        [HttpGet]
        [Route("api/applications/{pageIndex}/{pageSize}")]
        public Result<PaginationResult<Core.Services.Models.Application>> GetList(int pageIndex, int pageSize)
        {
            Service = new Core.Services.ApplicationService(Config);
            return Service.GetList(pageIndex, pageSize);
        }

    }
}