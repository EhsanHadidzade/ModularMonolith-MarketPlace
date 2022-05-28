using AccountManagement.Domain.CooperationRequestAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class UserCooperationRequestMapping : IEntityTypeConfiguration<UserCooperationRequest>
    {
        public void Configure(EntityTypeBuilder<UserCooperationRequest> builder)
        {
            builder.ToTable("UserCooperationRequests");
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Role).WithMany(x => x.UserCooperationRequests).HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.Personality).WithMany(x => x.UserCooperationRequests).HasForeignKey(x => x.PersonalityId);
            builder.HasOne(x => x.User).WithMany(x => x.UserCooperationRequests).HasForeignKey(x => x.UserId);
        }
    }
}
