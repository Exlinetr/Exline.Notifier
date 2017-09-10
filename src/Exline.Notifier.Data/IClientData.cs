using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Data
{
    public interface IClientData : IData
    {
        Result Insert(Collections.ClientCollection client);
        Result TokenUpdate(string clientId, string token);
        Result Remove(string clientId);

        bool ExistsByToken(string token);

    }
}
