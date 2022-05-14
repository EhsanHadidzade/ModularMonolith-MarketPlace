using AccountManagement.Domain.UpAccountRequestRejectionReasonAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class UpAccountRequestRejectionReasonMapping : IEntityTypeConfiguration<UpAccountRequestRejectionReason>
    {
        public void Configure(EntityTypeBuilder<UpAccountRequestRejectionReason> builder)
        {
            builder.ToTable("UpAccountRequestRejectionReasons");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.UpAccountRequest).WithMany(x=>x.UpAccountRequestRejectionReasons).HasForeignKey(x=>x.UpAccountRequestId);
            builder.HasOne(x=>x.RejectionReason).WithMany(x=>x.UpAccountRequestRejectionReasons).HasForeignKey(x=>x.RejectionReasonId);

        }
    }
}
