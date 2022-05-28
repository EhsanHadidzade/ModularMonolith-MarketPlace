using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
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
