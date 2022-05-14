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

            builder.HasOne(x => x.PersonalWallet).WithMany(x => x.PersonalWalletOperations).HasForeignKey(x => x.PersonalWalletId);
            builder.HasOne(x=>x.WalletOperationType).WithMany(x=>x.PersonalWalletOperations).HasForeignKey(x=>x.WalletOperationTypeId);
        }
    }
}
