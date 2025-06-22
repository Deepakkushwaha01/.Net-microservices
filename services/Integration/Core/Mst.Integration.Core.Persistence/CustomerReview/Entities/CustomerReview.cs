using Mst.Integration.Core.Persistence.Common.Sql.Entity;

namespace Mst.Core.Persistence.CustomerReview.Entity
{
    public class CustomerReview : TrackedEntity
    {
        public string CustomerName { get; protected internal set; } = string.Empty;
        public string ReviewText { get; protected internal set; } = string.Empty;
        public int Rating { get; set; } // Assuming a rating scale of 1-5

        public static CustomerReview Create(
            int id,
            string customerName,
            string reviewText,
            int rating)
        {
            return new CustomerReview
            {
                Id = id,
                CustomerName = customerName,
                ReviewText = reviewText,
                Rating = rating,
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid()
            };
        }

    }
}