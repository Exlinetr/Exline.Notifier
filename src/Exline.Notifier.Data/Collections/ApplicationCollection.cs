using System;

namespace Exline.Notifier.Data.Collections
{
    public class ApplicationCollection
    {
        public enum ServiceType : byte
        {
            FIREBASE_CLOUD_MESSAGE = 0,
            APNS = 2
        }
        public ApplicationCollection()
        {
            if (string.IsNullOrEmpty(Id))
                Id = Guid.NewGuid().ToString();

            LastUpdatedDate = DateTime.MinValue;
            CreatedDate = DateTime.Now;
        }
        public ApplicationCollection(string name)
            : this()
        {
            Name = name;
        }

        public DateTime LastUpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public string CurrentApiKeyId { get; set; }

        public Exline.Notifier.FirebaseCloudMessageServiceConfig FirebaseConfig{get;set;}
        public Exline.Notifier.APNSServiceConfig APNSConfig{get;set;}
        public int TotalClientCount { get; set; }
        public int TotalSendNotificationCount { get; set; }
    }
}