using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Exline.Notifier.Web.Api
{
    public class CustomAuthorizeAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            string applicationId = string.Empty;
            if (context.ActionArguments.ContainsKey("applicationId"))
                applicationId = context.ActionArguments["applicationId"].ToString();

            Result result = new Result();
            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Key=",StringComparison.CurrentCultureIgnoreCase))
            {
                Core.Services.AuthorizationService authorization = new Core.Services.AuthorizationService(Config.Current);
                result = authorization.TokenCheck(applicationId, authHeader.Replace("key=","",StringComparison.CurrentCultureIgnoreCase), string.Empty);
                if (!result)
                {
                    context.HttpContext.Response.StatusCode = result.Code;
                    context.Result = new JsonResult(result);
                }
            }
            else
            {
                result.Unauthorized();
                context.HttpContext.Response.StatusCode = result.Code;
                context.Result = new JsonResult(result);
            }
        }
    }
    public class CustomAuthorize
    {
        private readonly RequestDelegate _next;

        public CustomAuthorize(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            string applicationId = string.Empty;
            var req = context.Request;
            if (string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Key="))
            {
                Core.Services.AuthorizationService authorization = new Core.Services.AuthorizationService(Config.Current);
                Result result = authorization.TokenCheck(applicationId, authHeader, string.Empty);
                if (result)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = result.Code;
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                return;
            }
        }
    }
}