namespace Mst.Common.Packages.Dtos
{
    public class PaginatedRequest
    {
        public int? Limit { get; set; } = 50;
        public int? Offset { get; set; } = 0;
        public string? Filter { get; set; }

        public string? OrderBy { get; set; }
    }
}