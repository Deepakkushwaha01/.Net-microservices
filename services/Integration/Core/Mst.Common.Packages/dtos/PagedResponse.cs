namespace Mst.Common.Packages.Dtos
{
    public class PagedResponse<T>
    {
        public bool? HasNextPage { get; }

        public int TotalRecords { get; }

        public int TotalDisplayRecords { get; }

        public IEnumerable<T> Data { get; }
        public PagedResponse(int totalRecords, int totalDisplayRecords, IEnumerable<T> data)
        {
            TotalRecords = totalRecords;
            TotalDisplayRecords = totalDisplayRecords;
            Data = data;
        }

        public PagedResponse(int totalRecords, int totalDisplayRecords, IEnumerable<T> data, bool hasNextPage)
            : this(totalRecords, totalDisplayRecords, data)
        {
            HasNextPage = hasNextPage;
        }
    }
}