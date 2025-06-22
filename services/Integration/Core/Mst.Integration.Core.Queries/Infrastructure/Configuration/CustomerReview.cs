using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mst.Core.Queries.Entities;

namespace Mst.Core.Queries.Infrastructure.Configuration
{

    public class CustomerReviewConfiguration : IEntityTypeConfiguration<CustomerReview>
    {
        public void Configure(EntityTypeBuilder<CustomerReview> builder)
        {
            builder.ToTable(nameof(CustomerReview), "Integration");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime").HasDefaultValue(null);
            builder.Property(x => x.CustomerName).HasColumnName("CustomerName").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.ReviewText).HasColumnName("ReviewText").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Rating).HasColumnName("Rating").HasColumnType("int").HasMaxLength(255);

            builder.HasIndex(x => x.Uid).IsUnique();
        }
    }
}