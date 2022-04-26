using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductStatusAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductStatusMapping : IEntityTypeConfiguration<ProductStatus>
    {
        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            builder.ToTable("ProductStatuses");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Products).WithOne(x => x.ProductStatus).HasForeignKey(x => x.ProductStatusId);
        }
    }
}
