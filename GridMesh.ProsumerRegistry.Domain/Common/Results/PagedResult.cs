namespace GridMesh.ProsumerRegistry.Domain.Common.Results
{

    public class PagedResult<TCollection> : Result
    {
        private readonly ICollection<TCollection> _items;

        protected PagedResult(
            ICollection<TCollection> items,
            int page,
            int pageSize,
            int totalCount,
            bool isSuccess,
            Error error)
            : base(isSuccess, error)
        {
            _items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public ICollection<TCollection> Items => _items;
        public int Page { get; }
        public int PageSize { get; }
        public int TotalCount { get; }


        public int TotalPages =>
            (int)Math.Ceiling(TotalCount / (double)PageSize);

        public bool HasNextPage =>
            Page < TotalPages;

        public bool HasPreviousPage =>
            Page > 1;

        public static PagedResult<TCollection> Success(
            ICollection<TCollection> items,
            int page,
            int pageSize,
            int totalCount) =>
            new(
                items: items,
                page: page,
                pageSize: pageSize,
                totalCount: totalCount,
                isSuccess: true,
                error: Error.None);
    }
}