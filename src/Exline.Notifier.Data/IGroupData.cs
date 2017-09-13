using Exline.Notifier.Data.Collections;

namespace Exline.Notifier.Data
{
    public interface IGroupData : IData
    {
        Result Create(string name);
        Result Remove(string groupId);
        Result NameUpdate(string groupId, string name);
        Result ClientAdd(string groupId, string clientId);
        Result ClientRemove(string groupId, string clientId);

        PaginationResult<GroupCollection> GetList(int pageIndex, int pageSize);

        PaginationResult<ClientCollection> GetClients(string groupId, int pageIndex, int pageSize);
    }
}
