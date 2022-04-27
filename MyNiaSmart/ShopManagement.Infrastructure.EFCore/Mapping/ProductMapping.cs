using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(256);
            builder.Property(x => x.Descriotion);
            builder.Property(x => x.Picture).HasMaxLength(256);
            builder.Property(x => x.CountryMadeIn).HasMaxLength(100);
            builder.Property(x => x.Dimensions).HasMaxLength(100);

            builder.HasOne(x=>x.ProductBrand).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductBrandId);
            builder.HasOne(x=>x.ProductModel).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductModelId);
            builder.HasOne(x=>x.ProductStatus).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductStatusId);
            builder.HasOne(x=>x.ProductType).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductTypeId);
            builder.HasOne(x=>x.ProductUsageType).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductUsageTypeId);
        }
    }
}
