using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Core.Services
{
    public abstract class BaseService : IService
    {
        protected Config Config { get; set; }
        public BaseService(Config config)
        {
            Config = config;
        }
    }
}
