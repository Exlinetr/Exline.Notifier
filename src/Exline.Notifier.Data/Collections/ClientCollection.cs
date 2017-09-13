
namespace Exline.Notifier.Data.Collections
{
    public class ClientCollection
        : BaseCollection
    {
        public ClientCollection(string token, DeviceType device)
        {
            Token = token;
            DeviceType = device;
        }
        public string Token { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
