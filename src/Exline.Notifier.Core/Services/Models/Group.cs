using System.Collections.Generic;

namespace Exline.Notifier.Core.Services.Models
{
    public class Group : Base
    {
        public Group() : base()
        {

        }
        public Group(string name) : this(name, null)
        {

        }
        public Group(string name, List<Client> clients)
        {
            Name = name;
            Clients = clients;
        }
        public Group(Data.Collections.GroupCollection group)
        {
            Name = group.Name;
            Id = group.Id;
        }
        public string Name { get; set; }
        public int TotalClientCount { get; set; }
        public List<Client> Clients { get; set; }
    }
}
