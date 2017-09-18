using System;
using System.Collections.Generic;
using System.Linq;
using Exline.Notifier.Data.Collections;

namespace Exline.Notifier.Data.Mongodb
{
    public class AuthorizationData : BaseData<IAuthorizationData>, IAuthorizationData
    {
        public AuthorizationData(Config config) : base(config)
        {

        }

        public Result Insert(AuthorizeCollection authorizeCollection)
        {
            return new Result(DbConnector.Insert<AuthorizeCollection>(authorizeCollection));
        }

        public string GetApplicationIdByApiKey(string apiKey)
        {
            return DbConnector.Filter<ApplicationApiKeyCollection, string>(x => x.ApiKey.ToLower() == apiKey.ToLower(), x => x.AppId).FirstOrDefault();
        }

        public string GetApplicationIdByToken(string token)
        {
            return DbConnector.Filter<AuthorizeCollection, string>(x => x.Token == token, x => x.AppId).FirstOrDefault();
        }



        public Result RemoveFromExpiredToken(string applicationId)
        {
            MongoDB.Driver.IMongoQuery query = MongoDB.Driver.Builders.Query.And(new List<MongoDB.Driver.IMongoQuery>(){
                MongoDB.Driver.Builders.Query<AuthorizeCollection>.LTE(x=>x.ExpireTime,DateTime.Now),
                MongoDB.Driver.Builders.Query<AuthorizeCollection>.EQ(x=>x.AppId,applicationId)
            });
            return new Result(DbConnector.Delete<AuthorizeCollection>(query, MongoDB.Driver.RemoveFlags.None));
        }
    }
}