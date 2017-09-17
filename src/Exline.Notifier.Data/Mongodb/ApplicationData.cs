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

        public ApplicationCollection GetById(string applicationId)
        {
            return DbConnector.Find<ApplicationCollection>(x=>x.Id==applicationId);
        }

        public PaginationResult<ApplicationCollection> GetList(int pageIndex, int pageSize)
        {
            PaginationResult<ApplicationCollection> result = new PaginationResult<ApplicationCollection>();
            result.TotalCount = (int)DbConnector.Count<ApplicationCollection>();
            result.Data=DbConnector.Filter<ApplicationCollection>(pageIndex,pageSize);
            return result;
        }

        public Result Remove(string applicationId)
        {
            return new Result(DbConnector.Delete<ApplicationCollection>(new ObjectId(applicationId)));
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