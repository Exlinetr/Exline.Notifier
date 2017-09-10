using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier
{
    public class Config
    {
        #region members

        private static Config _config;

        #endregion

        public string LOG_PATH { get; private set; }
        public DbServer DbServer { get; set; }
        public static Config Current { get { return _config; } private set { _config = value; } }

        public Config()
        {
#if WEB
            LOG_PATH = "";
#else
            LOG_PATH = "/app/logs/";
#endif
            Current = this;
        }


        public Config SetLogPath(string logPath)
        {
            LOG_PATH = logPath;
            return this;
        }

        public Config SetDbServer(DbServer server)
        {
            DbServer = server;
            return this;
        }

    }
}
