using System;

namespace Exline.Notifier.Core.Services
{
    public abstract class BaseService : IService
    {
        protected Config Config { get; set; }
        public BaseService(Config config)
        {
            Config = config;
        }


        protected virtual void OnException(Exception ex)
        {

        }

        protected int PageIndexControl(int pageIndex)
        {
            if (pageIndex < 0)
                pageIndex = 0;
            return pageIndex;
        }
        protected int PageSizeControl(int pageSize)
        {
            if (pageSize < 0)
                pageSize = 20;
            return pageSize;
        }
    }
}
