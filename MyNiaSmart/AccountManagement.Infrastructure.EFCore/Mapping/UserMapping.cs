using AccountManagement.Domain.UPAccountRequestsAgg;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.WalletAgg.BusinessWalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.FullName).HasMaxLength(100);
            builder.Property(x=>x.MobileNumber).HasMaxLength(100);
            builder.Property(x=>x.Capital).HasMaxLength(100);
            builder.Property(x=>x.City).HasMaxLength(100);
            builder.Property(x=>x.Address).HasMaxLength(256);
            builder.Property(x=>x.NationalCode).HasMaxLength(100);
            builder.Property(x=>x.ProfilePhoto).HasMaxLength(100);
            builder.Property(x=>x.IntroductorFullname).HasMaxLength(100);
            builder.Property(x=>x.IntroductorMobileNumber).HasMaxLength(100);
            builder.Property(x => x.Grade);

            //Relations
            builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.UserCooperationRequests).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.UpAccountRequest).WithOne(x => x.User).HasForeignKey<UpAccountRequest>(x => x.UserId);
            builder.HasOne(x => x.PersonalWallet).WithOne(x => x.User).HasForeignKey<PersonalWallet>(x => x.UserId);
            builder.HasOne(x => x.BusinessWallet).WithOne(x => x.User).HasForeignKey<BusinessWallet>(x => x.UserId);




        }
    }
}
