using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SellerProductMediaAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SellerProductMediaMapping : IEntityTypeConfiguration<SellerProductMedia>
    {
        public void Configure(EntityTypeBuilder<SellerProductMedia> builder)
        {
            builder.ToTable("SellerProductMedias");
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.MediaURL).HasMaxLength(256);
            builder.Property(x=>x.MediaAlt).HasMaxLength(500);
            builder.Property(x=>x.MediaTitle).HasMaxLength(500);

            //builder.HasOne(x => x.SellerProduct).WithMany(x => x.SellerProductMedias).HasForeignKey(x => x.SellerProductId);
            
        }
    }
}
