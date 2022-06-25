using AccountManagement.Domain.UserAddressAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class UserAddressMapping : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddresses");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Address).HasMaxLength(256);
            builder.Property(x => x.PostalCode).HasMaxLength(20);
            builder.Property(x => x.PlaqueNumber).HasMaxLength(5);
            builder.Property(x => x.Capital).HasMaxLength(35);
            builder.Property(x => x.City).HasMaxLength(35);

            builder.HasOne(x => x.User).WithMany(x => x.UserAddresses).HasForeignKey(x => x.UserId);
        }
    }
}
