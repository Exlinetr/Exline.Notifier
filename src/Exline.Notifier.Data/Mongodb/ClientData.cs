using System;
using MongoDB.Bson;
using System.Linq;
using Exline.Notifier.Data.Collections;

namespace Exline.Notifier.Data.Mongodb
{
    internal class ClientData : BaseData<IClientData>, IClientData
    {
        public ClientData(Config config)
            : base(config)
        {
        }

        public bool ExistsByToken(string token)
        {
            return DbConnector.Exists<ClientCollection>(x => x.Token == token);
        }

        public ClientCollection GetById(string clientId)
        {
            return DbConnector.Find<ClientCollection>(x => x.Id == clientId);
        }

        public string GetTokenById(string clientId)
        {
            return DbConnector.Filter<ClientCollection, string>(x => x.Id == clientId, x => x.Token).FirstOrDefault();
        }

        public Result Create(ClientCollection client)
        {
            return new Result(DbConnector.Insert<ClientCollection>(client));
        }

        public Result Remove(string clientId)
        {
            return new Result(DbConnector.Delete<ClientCollection>(new ObjectId(clientId)));
        }

        public Result TokenUpdate(string clientId, string token)
        {
            Result result = new Result();
            MongoDB.Driver.IMongoQuery query = MongoDB.Driver.Builders.Query<ClientCollection>.EQ(x => x.Id, clientId);
            MongoDB.Driver.IMongoUpdate update = MongoDB.Driver.Builders.Update<ClientCollection>.Set(x => x.Token, token).Set(x => x.LastUpdatedDate, DateTime.Now);
            return result;
        }

        public PaginationResult<ClientCollection> GetList(int pageIndex, int pageSize)
        {
            PaginationResult<ClientCollection> result = new PaginationResult<ClientCollection>();
            result.TotalCount = (int)DbConnector.Count<ClientCollection>();
            result.Data = DbConnector.Filter<ClientCollection>(pageIndex, pageSize);
            return result;
        }
    }
}
