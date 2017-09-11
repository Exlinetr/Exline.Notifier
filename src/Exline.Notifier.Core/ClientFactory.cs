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
                case DeviceType.WEB:
                    client = new Framework.PushNotification.FirebaseCloudMessage.FCMClient(clientCollection.Token, Framework.PushNotification.DeviceType.Andorid);
                    break;
                case DeviceType.IOS:
                    client = null;
                    break;
                case DeviceType.ANDORID:
                    client = new Framework.PushNotification.FirebaseCloudMessage.FCMClient(clientCollection.Token, Framework.PushNotification.DeviceType.Andorid);
                    break;
                default:
                    break;
            }
            return client;
        }
    }
}
