using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Core
{
    internal class ClientFactory
    {
        public static Framework.PushNotification.IClient Create(Data.Collections.ClientCollection clientCollection)
        {
            Framework.PushNotification.IClient client = null;
            switch (clientCollection.DeviceType)
            {
                case Framework.PushNotification.DeviceType.Web:
                    client = new Framework.PushNotification.FirebaseCloudMessage.FCMClient(clientCollection.Token, Framework.PushNotification.DeviceType.Andorid);
                    break;
                case Framework.PushNotification.DeviceType.iOS:
                    client = null;
                    break;
                case Framework.PushNotification.DeviceType.Andorid:
                    client = new Framework.PushNotification.FirebaseCloudMessage.FCMClient(clientCollection.Token, Framework.PushNotification.DeviceType.Andorid);
                    break;
                default:
                    break;
            }
            return client;
        }
    }
}
