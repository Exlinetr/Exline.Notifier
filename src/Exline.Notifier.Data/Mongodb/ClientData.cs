using System;
using MongoDB.Bson;
using System.Linq;
using Exline.Notifier.Data.Collections;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Exline.Notifier.Data.Mongodb
{
    internal class ClientData : BaseData<IClientData>, IClientData
    {
        public ClientData(Config config)
            : base(config)
        {
        }

        public bool ExistsByToken(string applicationId, string token)
        {
            return DbConnector.Exists<ClientCollection>(x => x.AppId == applicationId && x.Token == token);
        }

        public ClientCollection GetById(string applicationId, string clientId)
        {
            return DbConnector.Find<ClientCollection>(x => x.AppId == applicationId && x.Id == clientId);
        }

        public string GetTokenById(string applicationId, string clientId)
        {
            return DbConnector.Filter<ClientCollection, string>(x => x.AppId == applicationId && x.Id == clientId, x => x.Token).FirstOrDefault();
        }

        public Result Create(ClientCollection client)
        {
            return new Result(DbConnector.Insert<ClientCollection>(client));
        }

        public Result Remove(string applicationId, string clientId)
        {
            IMongoQuery query = Query.And(new List<IMongoQuery>()
            {
                 Query<ClientCollection>.EQ(x => x.Id, clientId),
                 Query<ClientCollection>.EQ(x=>x.AppId,applicationId)
            });
            return new Result(DbConnector.Delete<ClientCollection>(query, RemoveFlags.Single));
        }

        public Result TokenUpdate(string applicationId, string clientId, string token)
        {
            Result result = new Result();
            IMongoQuery query = Query.And(new List<IMongoQuery>()
            {
                Query<ClientCollection>.EQ(x => x.Id, clientId),
                Query<ClientCollection>.EQ(x=>x.AppId,applicationId)
            });

            IMongoUpdate update = Update<ClientCollection>.Set(x => x.Token, token).Set(x => x.LastUpdatedDate, DateTime.Now);
            return result;
        }

        public PaginationResult<ClientCollection> GetList(string applicationId, int pageIndex, int pageSize)
        {
            PaginationResult<ClientCollection> result = new PaginationResult<ClientCollection>();
            result.TotalCount = (int)DbConnector.Count<ClientCollection>();
            result.Items = DbConnector.Filter<ClientCollection>(x => x.AppId == applicationId, pageIndex, pageSize);
            return result;
        }
    }
}
