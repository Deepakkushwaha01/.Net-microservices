namespace Mst.Core.Queries.Entities
{
    public class CustomerReview : Entity
    {
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string CustomerName { get; protected internal set; } = string.Empty;

        /// <summary>
        /// Gets or sets the review text.
        /// </summary>
        public string ReviewText { get; protected internal set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rating given by the customer.
        /// </summary>
        public int? Rating { get; protected internal set; } // Assuming a rating scale of 1-5
    }
}