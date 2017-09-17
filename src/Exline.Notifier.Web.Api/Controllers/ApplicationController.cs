using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    public class ApplicationController : BaseController<Exline.Notifier.Core.Services.ApplicationService>
    {
        public ApplicationController() : base()
        {
        }

        [HttpPost]
        [Route("api/application/create")]
        public Result<Core.Services.Models.Application> Create(Models.Request.RequestApplicationModel application)
        {
            Service = new Core.Services.ApplicationService(Config);
            return Service.Create(application.Name);
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