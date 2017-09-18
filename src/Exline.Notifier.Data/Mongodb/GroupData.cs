using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using Exline.Notifier.Data.Collections;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Exline.Notifier.Data.Mongodb
{
    internal class GroupData : BaseData<IClientData>, IGroupData
    {
        public GroupData(Config config) : base(config)
        {
        }

        public Result ClientAdd(string applcationId, string groupId, string clientId)
        {
            return new Result(DbConnector.Insert<GroupClientCollection>(new GroupClientCollection(clientId, groupId) { AppId = applcationId }));
        }

        public PaginationResult<ClientCollection> GetClients(string applcationId, string groupId, int pageIndex, int pageSize)
        {
            PaginationResult<ClientCollection> result = new PaginationResult<ClientCollection>();
            IMongoQuery query = Query<GroupClientCollection>.EQ(x => x.GroupId, groupId);
            result.TotalCount = (int)DbConnector.Count<GroupClientCollection>(query);
            List<GroupClientCollection> groupClients = DbConnector.Filter<GroupClientCollection>(x => x.GroupId == groupId && x.AppId == applcationId, pageIndex, pageSize);
            List<string> clientIdList = groupClients.Select(x => x.Id).ToList();
            result.Items = DbConnector.Filter<ClientCollection>(x => clientIdList.Contains(x.Id));
            return result;
        }

        public PaginationResult<GroupCollection> GetList(string applcationId, int pageIndex, int pageSize)
        {
            PaginationResult<GroupCollection> result = new PaginationResult<GroupCollection>();
            result.TotalCount = (int)DbConnector.Count<GroupCollection>();
            result.Items = DbConnector.Filter<GroupCollection>(x => x.AppId == applcationId, pageIndex, pageSize);
            return result;
        }
        public Result Create(string applcationId, string name)
        {
            return new Result(DbConnector.Insert<GroupCollection>(new GroupCollection()
            {
                Name = name,
                AppId = applcationId
            }));
        }
        public Result NameUpdate(string applcationId, string groupId, string name)
        {
            Result result = new Result();

            IMongoUpdate update = Update<GroupCollection>.Set(x => x.Name, name);
            IMongoQuery query = Query.And(new List<IMongoQuery>(){
                Query<GroupCollection>.EQ(x=>x.Id,groupId),
                Query<GroupCollection>.EQ(x=>x.AppId,applcationId)
            });
            result = new Result(DbConnector.Update<GroupCollection>(query, update));
            return result;
        }
        public Result Remove(string applcationId, string groupId)
        {
            IMongoQuery query = Query.And(new List<IMongoQuery>()
            {
                Query<GroupCollection>.EQ(x => x.Id, groupId),
                Query<GroupCollection>.EQ(x=>x.AppId,applcationId)
            });
            return new Result(DbConnector.Delete<GroupCollection>(query, RemoveFlags.Single));
        }
        public Result ClientRemove(string applcationId, string groupId, string clientId)
        {
            IMongoQuery query = Query.And(new List<IMongoQuery>()
            {
                Query<GroupClientCollection>.EQ(x=>x.GroupId,groupId),
                Query<GroupClientCollection>.EQ(x=>x.ClientId,clientId),
                Query<GroupCollection>.EQ(x=>x.AppId,applcationId)
            });
            return new Result(DbConnector.Delete<GroupClientCollection>(query, RemoveFlags.Single));
        }
    }
}
