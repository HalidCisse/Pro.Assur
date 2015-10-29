using System;
using System.Collections.Generic;

namespace Pro.Assur.Models
{
    public class Pager<T> : List<T>
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public Pager(IEnumerable<T> dataSource, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            CurrentPage = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            AddRange(dataSource);
        }
    }
}