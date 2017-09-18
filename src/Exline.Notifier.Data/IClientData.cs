
namespace Exline.Notifier.Data
{
    public interface IClientData : IData
    {
        Result Create(Collections.ClientCollection client);
        Result TokenUpdate(string applicationId, string clientId, string token);
        Result Remove(string applicationId, string clientId);
        Collections.ClientCollection GetById(string applicationId, string clientId);
        bool ExistsByToken(string applicationId, string token);
        string GetTokenById(string applicationId, string clientId);
        PaginationResult<Collections.ClientCollection> GetList(string applicationId, int pageIndex, int pageSize);
    }
}
