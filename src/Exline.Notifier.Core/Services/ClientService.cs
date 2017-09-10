using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Core.Services
{
    public class ClientService : BaseService
    {
        public ClientService(Config config) : base(config)
        {

        }

        public Result<Models.Client> Insert(string token, Framework.PushNotification.DeviceType deviceType)
        {
            Result<Models.Client> result = new Result<Models.Client>();
            Data.IClientData clientData = new Data.DataFactory<Data.IClientData>(Config).Create();

            if (!clientData.ExistsByToken(token))
            {
                Data.Collections.ClientCollection clientCollection = new Data.Collections.ClientCollection(token, deviceType))
                result = new Result<Models.Client>(clientData.Insert(clientCollection);
                if (result.IsOk)
                {
                    result.OK(new Models.Client(clientCollection));
                }
            }
            else
            {
                result.SetError("$bu_token_ile_bir_kullanici_katiyli", 0);
            }

            return result;
        }

    }
}
