using System;
using System.Collections.Generic;

namespace Exline.Notifier.Data.Collections
{
    public class NotificationCollection:BaseCollection
    {
        public List<string> Clients{get;set;}
        public string ClientId{get;set;}
        public string GroupId{get;set;}
        public string Name{get;set;}
        public string Title{get;set;}
        public string Body{get;set;}
        public string Icon{get;set;}
        public SoundType SoundType{get;set;}
        public object Data{get;set;}
        public DateTime SendingDate{get;set;}
        public NotificationCollection()
        {

        }
    }
}