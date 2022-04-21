using AccountManagement.Domain.UserPersonalityAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class UserPersonalityMapping : IEntityTypeConfiguration<UserPersonality>
    {
        public void Configure(EntityTypeBuilder<UserPersonality> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("UserPersonalities");

            builder.HasOne(x => x.Personality).WithMany(x => x.UserPersonalities).HasForeignKey(x => x.PersonalityId);
            builder.HasOne(x => x.User).WithMany(x => x.UserPersonalities).HasForeignKey(x => x.UserId);
        }
    }
}
