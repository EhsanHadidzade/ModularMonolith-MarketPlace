using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairWorkShopManagement.Domain.UserImapairmentReportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Mapping
{
    public class UserImpairmentReportMapping : IEntityTypeConfiguration<UserImapairmentReport>
    {
        public void Configure(EntityTypeBuilder<UserImapairmentReport> builder)
        {
            builder.ToTable("UserImapairmentReports");
            builder.HasKey(t => t.Id);

            builder.HasMany(x => x.ImpairmentReportServices).WithOne(x => x.UserImapairmentReport).HasForeignKey(x => x.UserImpairmentReportId);
            builder.HasMany(x => x.ImpairmentReportProducts).WithOne(x => x.UserImapairmentReport).HasForeignKey(x => x.UserImpairmentReportId);
        }
    }
}
