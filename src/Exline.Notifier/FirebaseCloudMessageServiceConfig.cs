namespace Exline.Notifier
{
    public class FirebaseCloudMessageServiceConfig : ServiceConfig
    {
        public FirebaseCloudMessageServiceConfig(string apiKey, string senderId)
        {
            ApiKey = apiKey;
            SenrderId = senderId;
        }
        public string ApiKey { get; set; }
        public string SenrderId { get; set; }

    }
}