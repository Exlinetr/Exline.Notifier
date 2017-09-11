using Exline.Notifier.Data.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Data
{
    public interface IGroupData : IData
    {
        Result Create(string name);
        Result Remove(string groupId);
        Result NameUpdate(string groupId, string name);
        Result AddClient(string groupId, string clientId);
        Result RemoveClient(string groupId, string clientId);

        PaginationResult<GroupCollection> GetList(int pageIndex, int pageSize);

        PaginationResult<ClientCollection> GetClients(string groupId, int pageIndex, int pageSize);
    }
}
