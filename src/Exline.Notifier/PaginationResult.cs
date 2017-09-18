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
        public PaginationResult(int currentPageIndex, int currentPageSize):this(null,currentPageIndex,currentPageSize,0){

        }
        public PaginationResult(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
        public PaginationResult(List<T> items, int currentPageIndex, int currentPageSize, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
            CurrentPageSize = currentPageSize;
            CurrentPageIndex = currentPageIndex;
        }

        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPageSize { get; set; }
        public int CurrentPageIndex { get; set; }

        public int TotalPageCount
        {
            get
            {
                int result = 0;
                result = TotalCount / CurrentPageSize;
                if (TotalCount % CurrentPageSize > 0)
                    result++;
                return result;
            }
        }
        public int NextPageIndex
        {
            get
            {
                if (CurrentPageIndex + 1 < TotalPageCount)
                    return CurrentPageIndex + 1;
                return 0;
            }
        }
        public int BackPageIndex
        {
            get
            {
                if (CurrentPageIndex > 0)
                {
                    return CurrentPageIndex - 1;
                }

                return 0;
            }
        }

        public PaginationResult<TResult> To<TResult>(Func<T, TResult> selector)
        {
            PaginationResult<TResult> result = new PaginationResult<TResult>();
            result.TotalCount = this.TotalCount;
            result.Items = Items.Select(selector).ToList();
            result.CurrentPageSize = this.CurrentPageSize;
            result.CurrentPageIndex = this.CurrentPageIndex;
            return result;
        }

        public void SetPageInfo(int currentPageIndex,int currentPageSize){
            this.CurrentPageIndex=currentPageIndex;
            this.CurrentPageSize=currentPageSize;
        }
    }
}
