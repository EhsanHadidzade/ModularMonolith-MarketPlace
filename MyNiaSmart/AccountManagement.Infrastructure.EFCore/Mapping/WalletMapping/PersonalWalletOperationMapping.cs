using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping.WalletMapping
{
    public class PersonalWalletOperationMapping : IEntityTypeConfiguration<Personalwalletoperation>
    {
        public void Configure(EntityTypeBuilder<Personalwalletoperation> builder)
        {
            builder.ToTable("PersonalWalletOperations");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.VerifyCode).HasMaxLength(20);
            builder.Property(x=>x.ReceiverFullName).HasMaxLength(300);
            builder.Property(x=>x.SenderFullName).HasMaxLength(300);

            builder.HasOne(x => x.PersonalWallet).WithMany(x => x.PersonalWalletOperations).HasForeignKey(x => x.PersonalWalletId);
            builder.HasOne(x=>x.WalletOperationType).WithMany(x=>x.PersonalWalletOperations).HasForeignKey(x=>x.WalletOperationTypeId);
        }
    }
}
