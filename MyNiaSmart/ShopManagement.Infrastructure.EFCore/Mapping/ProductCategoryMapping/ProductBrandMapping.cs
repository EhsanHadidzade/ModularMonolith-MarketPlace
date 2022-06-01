using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping.ProductCategoryMapping
{
    public class ProductBrandMapping : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.ToTable("ProductBrands");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Products).WithOne(x => x.ProductBrand).HasForeignKey(x => x.ProductBrandId);
            builder.HasMany(x=>x.ProductModels).WithOne(x=>x.ProductBrand).HasForeignKey(x => x.ProductBrandId);
        }
    }
}
