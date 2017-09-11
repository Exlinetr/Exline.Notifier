using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exline.Notifier.Core.Services
{
    public sealed class GroupService : BaseService
    {
        public GroupService(Config config) : base(config)
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
                Data.IGroupData groupData = new Data.DataFactory<Data.IGroupData>(Config).Create();
                result = new Result<Models.Group>(groupData.Create(name));
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
                Data.IGroupData groupData = new Data.DataFactory<Data.IGroupData>(Config).Create();
                result = groupData.Remove(groupId);
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
                PaginationResult<Data.Collections.GroupCollection> pageResult = groupData.GetList(pageIndex, pageSize);
                result.OK(pageResult.To(x => new Models.Group(x)));
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
