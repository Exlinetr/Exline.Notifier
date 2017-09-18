using System;

namespace Exline.Notifier.Data.Collections
{
    public class AuthorizeCollection : BaseCollection
    {
        public AuthorizeCollection()
            : base()
        {

        }
        public AuthorizeCollection(string applicationId, string apiKey)
            : this()
        {
            Token = Guid.NewGuid().ToString();
            AppId = applicationId;
            ExpireTime = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0));
            ApiKey = apiKey;
        }
        public string Token { get; set; }
        public string ApiKey { get; set; }
        public DateTime ExpireTime { get; set; }

    }
}