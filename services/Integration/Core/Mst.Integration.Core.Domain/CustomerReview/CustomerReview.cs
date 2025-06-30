namespace Mst.Core.Domain.CustomerReview
{
    using Mst.Common.Packages.Results;
    using Mst.Core.Domain.Common.Entities;
    using Mst.SharedKernel.Statics;

    /// <summary>
    /// Represents a customer review.
    /// </summary>
    public class CustomerReview : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public required string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the review text.
        /// </summary>
        public required string ReviewText { get; set; }

        /// <summary>
        /// Gets or sets the rating given by the customer.
        /// </summary>
        public int Rating { get; set; } // Assuming a rating scale of 1-5

        public Result Validate()
        {
            if (string.IsNullOrWhiteSpace(CustomerName))
            {
                return Result.Invalid(ResultErrorCodes.CustomerReviewRequiredCustomerName);
            }

            if (string.IsNullOrWhiteSpace(ReviewText))
            {
                return Result.Invalid(ResultErrorCodes.CustomerReviewRequiredReviewText);
            }

            if (Rating < 0 || Rating > 5)
            {
                return Result.Invalid(ResultErrorCodes.CustomerReviewRatingInvalid);
            }
            return Result.Ok();
        }

        public static Result<CustomerReview> Create(string customerName, string reviewText, int rating)
        {
            return Result.Ok(new CustomerReview
            {
                CustomerName = customerName,
                ReviewText = reviewText,
                Rating = rating
            });
        }

    }
}
