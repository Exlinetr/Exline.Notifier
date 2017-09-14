using System;
using System.Collections.Generic;

namespace Exline.Notifier.Web.Api.Models
{
    public class RequestNotificationModel
    {
        public class NotificationModel
        {
            public NotificationModel()
            {

            }
            public SoundType Sound{get;set;}
            public string Title{get;set;}
            public string Body{get;set;}
            public string Icon{get;set;}

        }
        public RequestNotificationModel()
        {

        }
        public string AppId { get; set; }
        public string GroupId { get; set; }
        public List<string> Clients { get; set; }
        public string ClientId { get; set; }
        public DateTime SendingDate{get;set;}
        public NotificationModel Notification{get;set;}
        public object Data { get; set; }
    }
}