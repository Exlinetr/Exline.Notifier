using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Core.Services.Models
{
    public class Client : Base
    {
        public Client(Data.Collections.ClientCollection clientCollection)
        {
            Id = clientCollection.Id;
            Info = ClientFactory.Create(clientCollection);
        }
        public Framework.PushNotification.IClient Info { get; set; }
    }
}
