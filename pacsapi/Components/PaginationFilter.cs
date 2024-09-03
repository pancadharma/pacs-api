namespace Mahas.Components
{
    public class PaginationFilter
    {
        public PaginationFilter()
        {

        }

        public PaginationFilter(string orderBy)
        {
        }

        public const int DefaultPageSize = 25;

        public int? PageIndex { get; set; } = 0;

        public int? PageSize { get; set; } = 25;

        internal int SkipSize
        {
            get { return PageIndex.Value * PageSize.Value; }
        }
    }
}
