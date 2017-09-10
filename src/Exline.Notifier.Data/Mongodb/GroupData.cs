using Exline.Notifier.Data.Collections;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exline.Notifier.Data.Mongodb
{
    internal class GroupData : BaseData<IClientData>, IGroupData
    {
        public GroupData(Config config) : base(config)
        {
        }

        public Result AddClient(string groupId, string clientId)
        {
            return new Result(DbConnector.Insert<GroupClientCollection>(new GroupClientCollection(clientId, groupId)));
        }

        public PaginationResult<ClientCollection> GetClients(string groupId, int pageIndex, int pageSize)
        {
            PaginationResult<ClientCollection> result = new PaginationResult<ClientCollection>();
            MongoDB.Driver.IMongoQuery query = MongoDB.Driver.Builders.Query<GroupClientCollection>.EQ(x => x.GroupId, groupId);
            result.TotalCount = (int)DbConnector.Count<GroupClientCollection>(query);
            List<GroupClientCollection> groupClients= DbConnector.Filter<GroupClientCollection>(x => x.GroupId == groupId, pageIndex, pageSize);
            List<string> clientIdList = groupClients.Select(x => x.Id).ToList();
            result.Data = DbConnector.Filter<ClientCollection>(x=> clientIdList.Contains(x.Id));
            return result;
        }

        public PaginationResult<GroupCollection> GetList(int pageIndex, int pageSize)
        {
            PaginationResult<GroupCollection> result = new PaginationResult<GroupCollection>();
            result.TotalCount = (int)DbConnector.Count<GroupCollection>();
            result.Data = DbConnector.Filter<GroupCollection>(pageIndex, pageSize);
            return result;
        }
        public Result Insert(string name)
        {
            return new Result(DbConnector.Insert<GroupCollection>(new GroupCollection()
            {
                Name = name
            }));
        }
        public Result NameUpdate(string groupId, string name)
        {
            Result result = new Result();
            MongoDB.Driver.IMongoUpdate update = MongoDB.Driver.Builders.Update<GroupCollection>.Set(x => x.Name, name);
            result = new Result(DbConnector.Update<GroupCollection>(new ObjectId(groupId), update));
            return result;
        }
        public Result Remove(string groupId)
        {
            return new Result(DbConnector.Delete<GroupCollection>(new ObjectId(groupId)));
        }
        public Result RemoveClient(string groupId, string clientId)
        {
            MongoDB.Driver.IMongoQuery query = MongoDB.Driver.Builders.Query.And(new List<MongoDB.Driver.IMongoQuery>()
            {
                MongoDB.Driver.Builders.Query<GroupClientCollection>.EQ(x=>x.GroupId,groupId),
                MongoDB.Driver.Builders.Query<GroupClientCollection>.EQ(x=>x.ClientId,clientId)
            });
            return new Result(DbConnector.Delete<GroupClientCollection>(query, MongoDB.Driver.RemoveFlags.Single));
        }
    }
}
