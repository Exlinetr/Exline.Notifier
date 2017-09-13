using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController:Controller
    {

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