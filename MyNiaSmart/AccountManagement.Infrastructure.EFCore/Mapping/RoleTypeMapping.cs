using AccountManagement.Domain.RoleTypeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class RoleTypeMapping : IEntityTypeConfiguration<RoleType>
    {
        public void Configure(EntityTypeBuilder<RoleType> builder)
        {
            builder.ToTable("RoleTypes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoleTypeName).HasMaxLength(100);

            //relations
            builder.HasMany(x => x.Roles).WithOne(x => x.RoleType).HasForeignKey(x => x.RoleTypeId);
        }
    }
}
