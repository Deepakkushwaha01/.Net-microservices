using Mst.Core.Domain.CustomerReview;

namespace Mst.Core.Persistence.CustomerReview.Factory
{
    using Mst.Core.Persistence.CustomerReview.Entity;
    internal static class CustomerReviewFactory
    {
        public static CustomerReview ToCustomerReviewEntity(this Domain.CustomerReview.CustomerReview customerReview)
        {
            return CustomerReview.Create(
                customerReview.Id,
                customerReview.CustomerName,
                customerReview.ReviewText,
                customerReview.Rating);
        }

        public static Domain.CustomerReview.CustomerReview ToCustomerReviewDomain(this CustomerReview customerReviewEntity)
        {
            return Domain.CustomerReview.CustomerReview.Create(
                customerReviewEntity.CustomerName,
                customerReviewEntity.ReviewText,
                customerReviewEntity.Rating);
        }
    }
}