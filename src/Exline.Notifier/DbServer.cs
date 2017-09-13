using System;

namespace Exline.Notifier
{
    public class DbServer : Framework.Net.Server
    {
        public string DatabaseName { get; set; }
        public TimeSpan TimeOut { get; set; }
        public DbType Type { get; set; }
    }
}
