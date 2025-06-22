namespace Mst.Core.Contracts.Integrations.Requests
{
    public class CustomerReviewRequestDto
    {
        required public string CustomerName { get; set; }
        required public string ReviewText { get; set; }
        required public int Rating { get; set; }
    }
}