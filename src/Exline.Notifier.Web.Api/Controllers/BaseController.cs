using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
        }
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
        }
    }

    public abstract class BaseController<TCore> : BaseController where TCore : Core.Services.IService
    {
        public TCore Service { get; set; }
        public Config Config { get; set; }

        public BaseController() : base()
        {
            Config = Startup.Config;
        }
    }
}