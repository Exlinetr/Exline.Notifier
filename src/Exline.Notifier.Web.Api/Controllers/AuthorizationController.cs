
using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api.Controllers
{

    public class AuthorizationController : BaseController<Core.Services.AuthorizationService>
    {
        public AuthorizationController()
            : base()
        {

        }

        [HttpGet]
        [Route("api/Auth/{applicationId}/{apiKey}")]
        public Result<Core.Services.Models.Authorize> Authorize(string applicationId, string apiKey)
        {
            Service = new Core.Services.AuthorizationService(Config);
            return Service.TokenCreate(applicationId, apiKey);
        }

    }

}