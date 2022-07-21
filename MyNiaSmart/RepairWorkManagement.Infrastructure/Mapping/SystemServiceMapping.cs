using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Mapping
{
    public class SystemServiceMapping : IEntityTypeConfiguration<SystemService>
    {
        public void Configure(EntityTypeBuilder<SystemService> builder)
        {
            builder.ToTable("SystemServices");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description);
            builder.Property(x => x.Duration).HasMaxLength(12);

            builder.HasMany(x => x.RepairManServices).WithOne(x => x.SystemService).HasForeignKey(x => x.SystemServiceId);
        }
    }
}
