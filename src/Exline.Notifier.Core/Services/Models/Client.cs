
namespace Exline.Notifier.Core.Services.Models
{
    public class Client : Base
    {
        public Client(string token, DeviceType device) : this(new Data.Collections.ClientCollection(token, device))
        {

        }
        public Client(Data.Collections.ClientCollection clientCollection)
        {
            Id = clientCollection.Id;
            Info = ClientFactory.Create(clientCollection);
            Device=new Device();
        }
        public Framework.PushNotification.IClient Info { get; set; }
        public Localization Localization{get;set;}
        public Device Device{get;set;}
    }
}
