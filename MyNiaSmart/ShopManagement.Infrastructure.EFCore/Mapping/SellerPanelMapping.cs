using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SellerPanelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SellerPanelMapping : IEntityTypeConfiguration<SellerPanel>

    {
        public void Configure(EntityTypeBuilder<SellerPanel> builder)
        {
            builder.ToTable("SellerPanels");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StoreName).HasMaxLength(256);
            builder.Property(x => x.SellerMobileNumber).HasMaxLength(50);
            builder.Property(x=>x.Address).HasMaxLength(1000);
            builder.Property(x=>x.CompanyName).HasMaxLength(1000);
            builder.Property(x=>x.CompanyRegistrationCode).HasMaxLength(100);
            builder.Property(x=>x.CompanyEconomicCode).HasMaxLength(100);
            builder.Property(x=>x.Capital).HasMaxLength(100);
            builder.Property(x=>x.City).HasMaxLength(100);

            builder.HasMany(x => x.SellerProducts).WithOne(x => x.SellerPanel).HasForeignKey(x => x.SellerPanelId);
            builder.HasMany(x => x.Transitions).WithOne(x => x.SellerPanel).HasForeignKey(x => x.SellerPanelId);
            

        }
    }
}
