using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Data.Collections
{
    public class ClientCollection
        : BaseCollection
    {
        public ClientCollection(string token, Framework.PushNotification.DeviceType device)
        {
            Token = token;
            DeviceType = device;
        }
        public string Token { get; set; }
        public Framework.PushNotification.DeviceType DeviceType { get; set; }
    }
}
