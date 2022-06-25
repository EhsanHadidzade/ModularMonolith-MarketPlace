using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping.WalletMapping
{
    public class PersonalWalletMapping : IEntityTypeConfiguration<PersonalWallet>
    {
        public void Configure(EntityTypeBuilder<PersonalWallet> builder)
        {
            builder.ToTable("PersonalWallets");
            builder.HasKey(x => x.Id);  

            builder.Property(x=>x.CardNumber).HasMaxLength(128);
            builder.Property(x=>x.OwnerFullName).HasMaxLength(500);
            builder.Property(x=>x.OwnerRegistrationDate).HasMaxLength(120);

            builder.HasOne(x => x.User).WithOne(x => x.PersonalWallet).HasForeignKey<PersonalWallet>(x => x.UserId);

            builder.HasMany(x => x.PersonalWalletOperations).WithOne(x => x.PersonalWallet).HasForeignKey(x => x.PersonalWalletId);
            builder.HasMany(x => x.PersonalWalletCharts).WithOne(x => x.PersonalWallet).HasForeignKey(x => x.PersonalwalletId);

        }
    }
}
