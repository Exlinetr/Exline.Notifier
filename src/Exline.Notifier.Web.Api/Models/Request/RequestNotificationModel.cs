using System.Collections.Generic;

namespace Exline.Notifier.Web.Api.Models
{
    public class RequestNotificationModel
    {
        public RequestNotificationModel()
        {

        }

        public string GroupId { get; set; }
        public List<string> Clients { get; set; }
        public string ClientId { get; set; }
        
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public SoundType Sound { get; set; }
    }
}