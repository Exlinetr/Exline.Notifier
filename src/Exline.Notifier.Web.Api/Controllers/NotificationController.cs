using Microsoft.AspNetCore.Mvc;
using Exline.Notifier.Web.Api.Models;
using System;

namespace Exline.Notifier.Web.Api.Controllers
{
    public class NotificationController : BaseController
    {
        public NotificationController()
            : base()
        {

        }
        [HttpGet]
        [Route("/")]
        public Result Index()
        {
            return new Result() { IsOk = true, Message = "exline.notifier.api v1" };
        }
        [HttpPost]
        [Route("api/{applicationId}/notification/send")]
        public Result Send(string applicationId, RequestNotificationModel notification)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("api/{applicationId}/notofications/{pageIndex}/{pageSize}")]
        public Result GetList(string applicationId, int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("api/{applicationId}/notification/{id}")]
        public Result GetById(string applicationId, string id)
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete]
        [Route("api/{applicationId}/notification/{id}")]
        public Result RemoveById(string applicationId, string id)
        {
            throw new System.NotImplementedException();
        }


    }

}