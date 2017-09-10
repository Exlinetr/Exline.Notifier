using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier.Core.Services.Models
{
    public abstract class Base
    {
        public Base()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

    }
}
