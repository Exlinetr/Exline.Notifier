using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Exline.Notifier.Data.Mongodb
{
    internal abstract class BaseData<T> : Data.BaseData<T> where T : IData
    {
        protected Expression<Func<Collections.BaseCollection, bool>> DefaultQuery{get;set;};
        protected MongoDB.Driver.IMongoQuery DefaultIMongoQuery{get;set;}
        protected Framework.Data.MongoDb.DbConnector DbConnector { get; set; }
        public BaseData(Config config) : base(config)
        {
            DefaultQuery = (x => x.CustomerId == config.CustomerId);
            DefaultIMongoQuery=MongoDB.Driver.Builders.Query<Collections.BaseCollection>.EQ(x=>x.CustomerId,config.CustomerId);

            DbConnector = new Framework.Data.MongoDb.DbConnector(config.DbServer.Host, config.DbServer.DatabaseName, config.DbServer.Username, config.DbServer.Password, config.DbServer.Port, config.DbServer.TimeOut);
        }

        protected Expression<Func<TCollection, bool>> Combine<TCollection>(Expression<Func<TCollection, bool>> condition, string paramName) where TCollection : Collections.BaseCollection
        {
            ParameterExpression param = Expression.Parameter(typeof(TCollection), paramName);
            BinaryExpression body = Expression.AndAlso(DefaultQuery, condition);
            return Expression.Lambda<Func<TCollection, bool>>(body, param);
        }
        protected MongoDB.Driver.IMongoQuery Combine<TCollection>(MongoDB.Driver.IMongoQuery query) where TCollection : Collections.BaseCollection
        {
            MongoDB.Driver.IMongoQuery combineQuery=MongoDB.Driver.Builders.Query.And(new List<MongoDB.Driver.IMongoQuery>(){
                DefaultIMongoQuery,
                query
            });
            return combineQuery;
        }
    }
}
