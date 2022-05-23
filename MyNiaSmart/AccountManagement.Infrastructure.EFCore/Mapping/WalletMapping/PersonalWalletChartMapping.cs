using AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping.WalletMapping
{
    public class PersonalWalletChartMapping : IEntityTypeConfiguration<PersonalWalletChart>
    {
        public void Configure(EntityTypeBuilder<PersonalWalletChart> builder)
        {
            builder.ToTable("PersonalWalletCharts");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.PersonalWallet).WithMany(x=>x.PersonalWalletCharts).HasForeignKey(x=>x.PersonalwalletId);
        }
    }
}
