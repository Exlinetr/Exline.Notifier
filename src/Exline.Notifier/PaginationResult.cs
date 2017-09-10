using System;
using System.Collections.Generic;
using System.Text;

namespace Exline.Notifier
{
    public class PaginationResult<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
