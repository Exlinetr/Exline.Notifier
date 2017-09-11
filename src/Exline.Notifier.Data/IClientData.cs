using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Data
{
    public interface IClientData : IData
    {
        Result Create(Collections.ClientCollection client);
        Result TokenUpdate(string clientId, string token);
        Result Remove(string clientId);
        Collections.ClientCollection GetById(string clientId);
        bool ExistsByToken(string token);
        string GetTokenById(string clientId);

        PaginationResult<Collections.ClientCollection> GetList(int pageIndex, int pageSize);

    }
}
