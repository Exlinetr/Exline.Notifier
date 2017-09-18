using Exline.Notifier;

namespace Exline.Notifier.Core.Services.Models
{
    public class Application : Base
    {
        public Application()
        {


        }
        public Application(Data.Collections.ApplicationCollection applicationCollection)
        {
            Id = applicationCollection.Id;
            Name = applicationCollection.Name;
            FirebaseConfig = applicationCollection.FirebaseConfig;
            APNSConfig = applicationCollection.APNSConfig;
            TotalClientCount = applicationCollection.TotalClientCount;
            TotalSendNotificationCount = applicationCollection.TotalSendNotificationCount;
        }
        public string Name { get; set; }
        public FirebaseCloudMessageServiceConfig FirebaseConfig { get; set; }
        public APNSServiceConfig APNSConfig { get; set; }
        public int TotalClientCount { get; set; }
        public int TotalSendNotificationCount { get; set; }

    }
}