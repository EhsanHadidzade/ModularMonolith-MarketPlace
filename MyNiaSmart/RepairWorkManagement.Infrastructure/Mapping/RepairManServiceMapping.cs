using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Mapping
{
    public class RepairManServiceMapping : IEntityTypeConfiguration<RepairManService>
    {
        public void Configure(EntityTypeBuilder<RepairManService> builder)
        {
            builder.ToTable("RepairManServices");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.SystemService).WithMany(x=>x.RepairManServices).HasForeignKey(x=>x.SystemServiceId);
            builder.HasOne(x=>x.RepairManPanel).WithMany(x=>x.RepairManServices).HasForeignKey(x=>x.RepairManPanelId);
        }
    }
}
