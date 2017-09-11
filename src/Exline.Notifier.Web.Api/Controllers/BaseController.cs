using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController<TCore> : Controller where TCore : Core.Services.IService
    {
        public TCore Service { get; set; }
        public Config Config { get; set; }

        public BaseController() : base()
        {
            Config = Startup.Config;
        }
    }
}