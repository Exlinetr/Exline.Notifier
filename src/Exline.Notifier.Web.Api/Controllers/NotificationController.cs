using Microsoft.AspNetCore.Mvc;
using Exline.Notifier.Web.Api.Models;

namespace Exline.Notifier.Web.Api.Controllers
{
    public class NotificationController : BaseController
    {
        public NotificationController() 
            : base()
        {

        }

        [HttpPost]
        [Route("api/notification/send")]
        public Result Send(RequestNotificationModel notification)
        {
            throw new System.NotImplementedException();
        } 

        [HttpGet]
        [Route("api/notofications/{pageIndex}/{pageSize}")]
        public Result GetList(int pageIndex,int pageSize)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        [Route("api/notification/{id}")]
        public Result GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete]
        [Route("api/notification/{id}")]
        public Result RemoveById(string id)
        {
            throw new System.NotImplementedException();
        }


    }

}