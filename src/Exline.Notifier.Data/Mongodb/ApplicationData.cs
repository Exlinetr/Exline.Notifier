using System.Linq;
using Exline.Notifier.Data.Collections;
using MongoDB.Bson;

namespace Exline.Notifier.Data.Mongodb
{
    public class ApplicationData : BaseData<IApplicationData>, IApplicationData
    {
        public ApplicationData(Config config) 
            : base(config)
        {
        }

        public Result Create(ApplicationCollection application)
        {
            return new Result(DbConnector.Insert<Collections.ApplicationCollection>(application));
        }

        public bool ExistsByName(string name)
        {
            return DbConnector.Exists<Collections.ApplicationCollection>(x => x.Name.ToLower() == name.ToLower());
        }

        public string GetApplicationIdByApiKeyId(string apiKeyId)
        {
            return DbConnector.Filter<Collections.ApplicationCollection,string>(x=>x.CurrentApiKeyId==apiKeyId,x=>x.Id).FirstOrDefault();
        }

        public ApplicationCollection GetById(string applicationId)
        {
            return DbConnector.Find<ApplicationCollection>(x=>x.Id==applicationId);
        }

        public PaginationResult<ApplicationCollection> GetList(int pageIndex, int pageSize)
        {
            PaginationResult<ApplicationCollection> result = new PaginationResult<ApplicationCollection>();
            result.TotalCount = (int)DbConnector.Count<ApplicationCollection>();
            result.Items=DbConnector.Filter<ApplicationCollection>(pageIndex,pageSize);
            return result;
        }

        public Result Remove(string applicationId)
        {
            MongoDB.Driver.IMongoQuery query = MongoDB.Driver.Builders.Query<ApplicationCollection>.EQ(x => x.Id, applicationId);
            return new Result(DbConnector.Delete<ApplicationCollection>(query, MongoDB.Driver.RemoveFlags.Single));
        }

        public Result TokenAdd(AuthorizeCollection authorize)
        {
            return new Result(DbConnector.Insert<AuthorizeCollection>(authorize));
        }

        public Result TokenAdd(string applicationId, AuthorizeCollection authorize)
        {
            throw new System.NotImplementedException();
        }

        public Result TotalClientCountIncrement(string applicationId, int value)
        {
            MongoDB.Driver.IMongoQuery query = MongoDB.Driver.Builders.Query<ApplicationCollection>.EQ(x => x.Id, applicationId);
            MongoDB.Driver.IMongoUpdate update = MongoDB.Driver.Builders.Update<ApplicationCollection>.Inc(x => x.TotalClientCount, value);
            return new Result(DbConnector.Update<ApplicationCollection>(query, update));
        }

        public Result TotalSendNotificationCountIncrement(string applicationId, int value)
        {
            MongoDB.Driver.IMongoQuery query = MongoDB.Driver.Builders.Query<Collections.ApplicationCollection>.EQ(x => x.Id, applicationId);
            MongoDB.Driver.IMongoUpdate update = MongoDB.Driver.Builders.Update<Collections.ApplicationCollection>.Inc(x => x.TotalSendNotificationCount, value);
            return new Result(DbConnector.Update<Collections.ApplicationCollection>(query, update));
        }
    }
}