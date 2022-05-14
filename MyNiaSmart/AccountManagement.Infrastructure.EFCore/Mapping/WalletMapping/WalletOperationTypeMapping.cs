using AccountManagement.Domain.WalletAgg.OperationTypeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping.WalletMapping
{
    public class WalletOperationTypeMapping : IEntityTypeConfiguration<WalletOperationType>
    {
        public void Configure(EntityTypeBuilder<WalletOperationType> builder)
        {
            builder.ToTable("WalletOperationTypes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OperationTypeTitle).HasMaxLength(500);

            builder.HasMany(x=>x.PersonalWalletOperations).WithOne(x=>x.WalletOperationType).HasForeignKey(x=>x.WalletOperationTypeId);

            
        }
    }
}
