using Mst.Common.Packages.Results;

namespace Mst.Integration.Core.Persistence.CustomerReview.Repositories
{
    public interface ICustomerReviewRepo
    {
        /// <summary>
        /// Inserts a customer review into the repository.
        /// </summary>
        /// <param name="customerReview">The customer review to insert.</param>
        /// <returns>A result indicating success or failure.</returns>
        Result Insert(Mst.Core.Domain.CustomerReview.CustomerReview customerReview);

    }
}