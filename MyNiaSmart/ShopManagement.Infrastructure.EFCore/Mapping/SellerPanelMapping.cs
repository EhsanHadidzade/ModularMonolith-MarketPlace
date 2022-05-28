using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SellerPanel;
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
            builder.Property(x => x.StoreMobileNumber).HasMaxLength(50);
            builder.Property(x=>x.Address).HasMaxLength(1000);



        }
    }
}
