using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Core
{
    public static class ExtentionMethods
    {
        public static Framework.PushNotification.DeviceType ToDeviceType(this DeviceType type)
        {
            switch (type)
            {
                case DeviceType.IOS:
                    return Framework.PushNotification.DeviceType.iOS;
                case DeviceType.ANDORID:
                    return Framework.PushNotification.DeviceType.Andorid;
                case DeviceType.WEB:
                    return Framework.PushNotification.DeviceType.Web;
                default:
                    return Framework.PushNotification.DeviceType.Andorid;
            }
        }
    }
}
