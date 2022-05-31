using AccountManagement.Domain.PersonalityAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class PersonalityMapping : IEntityTypeConfiguration<Personality>
    {
        public void Configure(EntityTypeBuilder<Personality> builder)
        {
            builder.ToTable("Personalities");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Title).HasMaxLength(100);
            builder.HasOne(x=>x.PersonalityType).WithMany(x=>x.Personalities).HasForeignKey(x=>x.PersonalityTypeId);
            builder.HasMany(x => x.UserPersonalities).WithOne(x => x.Personality).HasForeignKey(x => x.PersonalityId);
            //builder.HasMany(x => x.UserPersonalityRequests).WithOne(x => x.Personality).HasForeignKey(x => x.PersonalityId);
            builder.HasMany(x => x.UserCooperationRequests).WithOne(x => x.Personality).HasForeignKey(x => x.PersonalityId);

        }
    }
}
