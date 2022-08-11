using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairWorkShopManagement.Domain.ImpairmentReportProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Mapping
{
    public class ImpairmentReportProductMapping : IEntityTypeConfiguration<ImpairmentReportProduct>
    {
        public void Configure(EntityTypeBuilder<ImpairmentReportProduct> builder)
        {
            builder.ToTable("ImpairmentReportProducts");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.UserImapairmentReport).WithMany(x=>x.ImpairmentReportProducts).HasForeignKey(x=>x.UserImpairmentReportId);
        }
    }
}
