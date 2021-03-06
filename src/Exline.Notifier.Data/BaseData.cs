﻿
namespace Exline.Notifier.Data
{
    public abstract class BaseData<T> where T : IData
    {
        protected Framework.Logger.ILogger ILogger { get; private set; }

        public BaseData(Config config)
        {

#if DEBUG
            ILogger = new Framework.Logger.OutputLogger();
#else
            ILogger = new Framework.Logger.FileLogger(string.Format(@"{0}\{1}.txt", config.LOG_PATH, typeof(T).Name));
#endif

        }
    }
}
