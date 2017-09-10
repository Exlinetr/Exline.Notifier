using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Data.Mongodb
{
    internal abstract class BaseData<T> : Data.BaseData<T> where T : IData
    {
        protected Framework.Data.MongoDb.DbConnector DbConnector { get; set; }
        public BaseData(Config config) : base(config)
        {
            DbConnector = new Framework.Data.MongoDb.DbConnector(config.DbServer.Host, config.DbServer.DatabaseName, config.DbServer.Username, config.DbServer.Password, config.DbServer.Port, config.DbServer.TimeOut);
        }
    }
}
