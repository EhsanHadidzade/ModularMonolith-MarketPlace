using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairWorkShopManagement.Domain.ImpairmentReportServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Mapping 
{
    public class ImpairmentReportServiceMapping : IEntityTypeConfiguration<ImpairmentReportService>
    {
        public void Configure(EntityTypeBuilder<ImpairmentReportService> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("ImpairmentReportServices");

            builder.HasOne(x => x.UserImapairmentReport).WithMany(x => x.ImpairmentReportServices).HasForeignKey(x => x.UserImpairmentReportId);

        }
    }
}
