using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Mapping
{
    public class RepairManPanelMapping : IEntityTypeConfiguration<RepairManPanel>
    {
        public void Configure(EntityTypeBuilder<RepairManPanel> builder)
        {
            builder.ToTable("RepairManPanels");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CommericalFullName).HasMaxLength(128);
            builder.Property(x => x.MobileNumber).HasMaxLength(15);
            builder.Property(x => x.Capital).HasMaxLength(56);
            builder.Property(x => x.City).HasMaxLength(56);
            builder.Property(x => x.Address).HasMaxLength(256);

            builder.HasMany(x => x.RepairManServices).WithOne(x => x.RepairManPanel).HasForeignKey(x => x.RepairManPanelId);



        }
    }
}
