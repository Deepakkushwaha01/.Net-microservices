namespace Mst.Core.Contracts.Integrations.Responses
{
    public class CustomerReviewResponseDto
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public required string CustomerName { get; set; }
        public required string ReviewText { get; set; }
        public int? Rating { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}