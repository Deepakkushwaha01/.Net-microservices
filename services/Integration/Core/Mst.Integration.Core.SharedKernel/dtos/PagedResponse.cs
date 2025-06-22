namespace Mst.SharedKernel.Common.Dtos
{
    public class PagedResponse<T>
    {
        public bool? HasNextPage { get; }

        public string? NextPageToken { get; }

        public int TotalRecords { get; }

        public int TotalDisplayRecords { get; }

        public IEnumerable<T> Data { get; }
        public PagedResponse(int totalRecords, int totalDisplayRecords, IEnumerable<T> data)
        {
            TotalRecords = totalRecords;
            TotalDisplayRecords = totalDisplayRecords;
            Data = data;
        }

        public PagedResponse(int totalRecords, int totalDisplayRecords, IEnumerable<T> data, bool hasNextPage, string? nextPageToken)
            : this(totalRecords, totalDisplayRecords, data)
        {
            HasNextPage = hasNextPage;
            NextPageToken = nextPageToken;
        }
    }
}