using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping.ProductCategoryMapping
{
    public class ProductUsageTypeMapping : IEntityTypeConfiguration<ProductUsageType>
    {
        public void Configure(EntityTypeBuilder<ProductUsageType> builder)
        {
            builder.ToTable("ProductUsageTypes");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Products).WithOne(x => x.ProductUsageType).HasForeignKey(x => x.ProductUsageTypeId);
        }
    }
}
