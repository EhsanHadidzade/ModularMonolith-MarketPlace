using AccountManagement.Domain.PersonalityTypeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class PerosnalityTypeMapping : IEntityTypeConfiguration<PersonalityType>
    {
        public void Configure(EntityTypeBuilder<PersonalityType> builder)
        {
            builder.ToTable("PersonalityTypes");
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Title).HasMaxLength(256);

            builder.HasMany(x => x.Personalities).WithOne(x => x.PersonalityType).HasForeignKey(x => x.PersonalityTypeId);
        }
    }
}
