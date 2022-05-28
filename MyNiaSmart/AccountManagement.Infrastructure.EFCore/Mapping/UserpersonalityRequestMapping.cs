using AccountManagement.Domain.UserPersonalityRequestAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class UserpersonalityRequestMapping : IEntityTypeConfiguration<UserPersonalityRequest>
    {
        public void Configure(EntityTypeBuilder<UserPersonalityRequest> builder)
        {
            builder.ToTable("UserPersonalityRequests");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithMany(x => x.UserPersonalityRequests).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Personality).WithMany(x => x.UserPersonalityRequests).HasForeignKey(x => x.PersonalityId);
        }
    }
}
