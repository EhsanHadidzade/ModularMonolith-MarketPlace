using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);

            //Relations
            builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
            builder.HasMany(x => x.UserCooperationRequests).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            builder.HasOne(x=>x.RoleType).WithMany(x=>x.Roles).HasForeignKey(x=>x.RoleTypeId);
        }
    }
}
