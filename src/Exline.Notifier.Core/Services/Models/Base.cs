using System;

namespace Exline.Notifier.Core.Services.Models
{
    public abstract class Base
    {
        public Base()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string ApplicationId { get; set; }

    }
}
