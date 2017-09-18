namespace Exline.Notifier.Data
{
    public interface IApplicationData:IData
    {
        Result Create(Collections.ApplicationCollection application);
        Result Remove(string applicationId);
        PaginationResult<Collections.ApplicationCollection> GetList(int pageIndex,int pageSize);
        Collections.ApplicationCollection GetById(string applicationId);

        Result TotalSendNotificationCountIncrement(string applicationId,int value);

        Result TotalClientCountIncrement(string applicationId,int value);

        bool ExistsByName(string name);

        string GetApplicationIdByApiKeyId(string apiKeyId);
    }
}