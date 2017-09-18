
namespace Exline.Notifier.Data.Collections
{
    public class ClientCollection
        : BaseCollection
    {
        public ClientCollection(string applicationId, string token, DeviceType device)
        {
            AppId = applicationId;
            Token = token;
            DeviceType = device;
        }
        public string Token { get; set; }
        public DeviceType DeviceType { get; set; }
        public int TimeZone { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string DeviceOS { get; set; }
        public string DeviceModel { get; set; }
    }
}
