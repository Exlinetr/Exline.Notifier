using Exline.Notifier.Data.Collections;

namespace Exline.Notifier.Data
{
    public interface IGroupData : IData
    {
        Result Create(string applcationId, string name);
        Result Remove(string applcationId, string groupId);
        Result NameUpdate(string applcationId, string groupId, string name);
        Result ClientAdd(string applcationId, string groupId, string clientId);
        Result ClientRemove(string applcationId, string groupId, string clientId);

        PaginationResult<GroupCollection> GetList(string applcationId, int pageIndex, int pageSize);

        PaginationResult<ClientCollection> GetClients(string applcationId, string groupId, int pageIndex, int pageSize);
    }
}
