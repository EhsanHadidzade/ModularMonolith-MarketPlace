using AccountManagement.Domain.RejectionReasonAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class RejectionReasonMapping : IEntityTypeConfiguration<RejectionReason>
    {
        public void Configure(EntityTypeBuilder<RejectionReason> builder)
        {
            builder.ToTable("RejectionReasons");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(1000);

            builder.HasMany(x => x.UpAccountRequestRejectionReasons).WithOne(x => x.RejectionReason).HasForeignKey(x => x.RejectionReasonId);

            
        }
    }
}
