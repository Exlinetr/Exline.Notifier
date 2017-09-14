namespace Exline.Notifier.Data
{
    public interface IApplicationData:IData
    {
        Result Create(string name);
        Result Remove(string applicationId);
        Result<PaginationResult<Collections.ApplicationCollection>> GetList(int pageIndex,int pageSize);
        Result<Collections.ApplicationCollection> GetById(string applicationId);


    }
}