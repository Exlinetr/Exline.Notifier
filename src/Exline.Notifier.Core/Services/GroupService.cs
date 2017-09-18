using System;

namespace Exline.Notifier.Core.Services
{
    public sealed class GroupService : BaseService
    {
        public GroupService(string applicationId, Config config)
            : base(applicationId, config)
        {

        }

        public Result<Models.Group> Create(string name)
        {
            Result<Models.Group> result = new Result<Models.Group>();
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    result.SetErr("$gecersiz_grup_adi");
                    return result;
                }
                Data.IGroupData groupData = new Data.DataFactory<Data.IGroupData>(Config).Create(ApplicationId);
                result = new Result<Models.Group>(groupData.Create(ApplicationId, name));
                if (result)
                    result.OK(new Models.Group(name));

            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }

        public Result Remove(string groupId)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(groupId))
                {
                    result.SetErr("$gecersiz_group_id");
                    return result;
                }
                Data.IGroupData groupData = new Data.DataFactory<Data.IGroupData>(Config).Create(ApplicationId);
                result = groupData.Remove(ApplicationId, groupId);
                if (result)
                    result.OK();
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }

        public Result<PaginationResult<Models.Group>> GetList(int pageIndex, int pageSize)
        {
            Result<PaginationResult<Models.Group>> result = new Result<PaginationResult<Models.Group>>();
            try
            {
                pageIndex = PageIndexControl(pageIndex);
                pageSize = PageSizeControl(pageSize);

                Data.IGroupData groupData = new Data.DataFactory<Data.IGroupData>(Config).Create();
                PaginationResult<Data.Collections.GroupCollection> pageResult = groupData.GetList(ApplicationId, pageIndex, pageSize);
                pageResult.SetPageInfo(pageIndex, pageSize);
                result.OK(pageResult.To(x => new Models.Group(x)));
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }

        public Result<PaginationResult<Models.Client>> GetClients(string groupId, int pageIndex, int pageSize)
        {
            Result<PaginationResult<Models.Client>> result = new Result<PaginationResult<Models.Client>>();
            try
            {
                if (string.IsNullOrEmpty(groupId))
                {
                    result.SetErr("$gecersiz_group_id");
                    return result;
                }
                pageIndex = PageIndexControl(pageIndex);
                pageSize = PageSizeControl(pageSize);

                Data.IGroupData groupData = new Data.DataFactory<Data.IGroupData>(Config).Create(ApplicationId);
                PaginationResult<Data.Collections.ClientCollection> pageResult = groupData.GetClients(ApplicationId, groupId, pageIndex, pageSize);
                pageResult.SetPageInfo(pageIndex, pageSize);
                result.OK(pageResult.To<Models.Client>(x => new Models.Client(x)));
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result ClientAdd(string groupId, string clientId)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(groupId))
                {
                    result.SetErr("$gecersiz_group_id");
                }
                if (string.IsNullOrEmpty(clientId))
                {
                    result.SetErr("$gecersiz_client_id");
                }
                Data.IGroupData groupData = new Data.DataFactory<Data.IGroupData>(Config).Create(ApplicationId);
                result = groupData.ClientAdd(ApplicationId, groupId, clientId);
                result.OK();
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result ClientRemove(string groupId, string clientId)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(groupId))
                {
                    result.SetErr("$gecersiz_group_id");
                }
                if (string.IsNullOrEmpty(clientId))
                {
                    result.SetErr("$gecersiz_client_id");
                }
                Data.IGroupData groupData = new Data.DataFactory<Data.IGroupData>(Config).Create(ApplicationId);
                result = groupData.ClientRemove(ApplicationId, groupId, clientId);
                result.OK();
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }


    }
}
