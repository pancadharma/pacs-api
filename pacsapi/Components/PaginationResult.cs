using System.Collections.Generic;

namespace Mahas.Components
{
    public class PaginationResult<T> where T : new()
    {
        public PaginationResult() { }

        public PaginationResult(int totalcount, IEnumerable<T> data, PaginationFilter paginationFilter)
        {
            TotalCount = totalcount;
            PageIndex = paginationFilter.PageIndex.Value;
            PageSize = paginationFilter.PageSize.Value;
            Data = data;
        }

        public int TotalCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
