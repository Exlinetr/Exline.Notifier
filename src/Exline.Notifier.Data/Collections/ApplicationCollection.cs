using System;

namespace Exline.Notifier.Data.Collections
{
    public class ApplicationCollection
    {
        
        public ApplicationCollection()
        {
            if (string.IsNullOrEmpty(Id))
                Id = Guid.NewGuid().ToString();

            LastUpdatedDate = DateTime.MinValue;
            CreatedDate = DateTime.Now;
        }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Id { get; set; }
        public string Name{get;set;}

        public string FCMApiKey{get;set;}
        public string FCMSenderId{get;set;}
        public string APNSCertificateFilePath{get;set;}
        public int TotalClientCount{get;set;}
        public int TotalSendNotificationCount{get;set;}
    }
}