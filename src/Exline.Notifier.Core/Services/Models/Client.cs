
namespace Exline.Notifier.Core.Services.Models
{
    public class Client : Base
    {
        public Client(string applicationId, string token, DeviceType device) : this(new Data.Collections.ClientCollection(applicationId, token, device))
        {

        }
        public Client(Data.Collections.ClientCollection clientCollection)
        {
            ApplicationId = clientCollection.AppId;
            Id = clientCollection.Id;
            Info = ClientFactory.Create(clientCollection);
            Device = new Device();
        }
        public Framework.PushNotification.IClient Info { get; set; }
        public Localization Localization { get; set; }
        public Device Device { get; set; }
    }
}
