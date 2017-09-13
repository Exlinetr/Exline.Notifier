using System;

namespace Exline.Notifier.Data.Collections
{
    public abstract class BaseCollection
    {
        public BaseCollection()
        {
            if (string.IsNullOrEmpty(Id))
                Id = Guid.NewGuid().ToString();

            LastUpdatedDate = DateTime.MinValue;
            CreatedDate = DateTime.Now;
        }
        public string Id { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
