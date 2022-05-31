using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SellerProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SellerProductMapping : IEntityTypeConfiguration<SellerProduct>
    {
        public void Configure(EntityTypeBuilder<SellerProduct> builder)
        {
            builder.ToTable("SellerProducts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description);

            builder.HasOne(x => x.SellerPanel).WithMany(x => x.SellerProducts).HasForeignKey(x => x.SellerPanelId);
            builder.HasOne(x => x.Product).WithMany(x => x.SellerProducts).HasForeignKey(x => x.ProductId);
        }
    }
}
