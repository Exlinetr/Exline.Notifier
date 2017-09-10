using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Data.Collections
{
    public class GroupClientCollection : BaseCollection
    {
        public GroupClientCollection(string clientId, string groupId)
        {
            ClientId = clientId;
            GroupId = groupId;
        }
        public string ClientId { get; set; }
        public string GroupId { get; set; }
    }
}
