using System;
using System.Collections.Generic;
using System.Linq;

namespace Exline.Notifier
{
    public class PaginationResult<T>
    {
        public PaginationResult() : this(null, 0)
        {

        }
        public PaginationResult(List<T> data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }

        public List<T> Data { get; set; }
        public int TotalCount { get; set; }

        public PaginationResult<TResult> To<TResult>(Func<T,TResult> selector)
        {
            PaginationResult<TResult> result = new PaginationResult<TResult>();
            result.TotalCount = this.TotalCount;
            result.Data = Data.Select(selector).ToList();
            return result;
        }
    }
}
