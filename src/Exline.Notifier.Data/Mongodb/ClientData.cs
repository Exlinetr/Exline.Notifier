using System;
using System.Collections.Generic;
using System.Text;
using Exline.Notifier.Data.Collections;
using MongoDB.Bson;

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

        public Result Insert(ClientCollection client)
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

    }
}
