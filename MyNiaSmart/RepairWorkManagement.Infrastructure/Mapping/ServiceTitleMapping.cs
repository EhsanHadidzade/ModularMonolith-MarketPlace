using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairWorkShopManagement.Domain.ServiceTitleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Mapping
{
    public class ServiceTitleMapping : IEntityTypeConfiguration<ServiceTitle>
    {
        public void Configure(EntityTypeBuilder<ServiceTitle> builder)
        {
            builder.ToTable("ServiceTitles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FarsiTitle).HasMaxLength(256);
            builder.Property(x => x.EngTitle).HasMaxLength(256);
        }
    }
}
