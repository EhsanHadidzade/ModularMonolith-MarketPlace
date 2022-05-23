using AccountManagement.Domain.WalletAgg.BusinessWalletAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping.WalletMapping
{
    public class BusinessWalletMapping : IEntityTypeConfiguration<BusinessWallet>
    {
        public void Configure(EntityTypeBuilder<BusinessWallet> builder)
        {
            builder.ToTable("BusinessWallets");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CardNumber).HasMaxLength(128);
            builder.Property(x => x.OwnerFullName).HasMaxLength(500);
            builder.Property(x => x.OwnerRegistrationDate).HasMaxLength(120);

            builder.HasOne(x=>x.User).WithOne(x=>x.BusinessWallet).HasForeignKey<BusinessWallet>(x=>x.UserId);

        }
    }
}
