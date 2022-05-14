using AccountManagement.Domain.UPAccountRequestsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class UpAccountRequestMapping : IEntityTypeConfiguration<UpAccountRequest>
    {
        public void Configure(EntityTypeBuilder<UpAccountRequest> builder)
        {
            builder.ToTable("UpAccountRequests");
            builder.HasKey(x => x.Id);
            //PersonalInfo
            builder.Property(x => x.PI_FUllName).HasMaxLength(128);
            builder.Property(x => x.PI_FatherName).HasMaxLength(128);
            builder.Property(x => x.PI_IdentityNumber).HasMaxLength(128);
            builder.Property(x => x.PI_NationalCode).HasMaxLength(128);
            builder.Property(x => x.Capital).HasMaxLength(128);
            builder.Property(x => x.City).HasMaxLength(128);
            //PersonalDocument
            builder.Property(x => x.PD_IdentityCard).HasMaxLength(128);
            builder.Property(x => x.PD_NationalCardFrontSide).HasMaxLength(128);
            builder.Property(x => x.PD_NationalCardBackSide).HasMaxLength(128);
            builder.Property(x => x.PD_NationalCodeTrackingPaper).HasMaxLength(128);
            //bank info
            builder.Property(x => x.BI_BankName).HasMaxLength(128);
            builder.Property(x => x.BI_BankAccountNumber).HasMaxLength(128);
            builder.Property(x => x.BI_CreditCardNumber).HasMaxLength(128);
            builder.Property(x => x.BI_ShabaNumber).HasMaxLength(128);
            //bank document
            builder.Property(x => x.BD_CreditCardBackSide).HasMaxLength(128);
            builder.Property(x => x.BD_CreditCardFrontSide).HasMaxLength(128);
            builder.Property(x => x.BD_ShabaPrint).HasMaxLength(128);
            //guaranty info
            builder.Property(x => x.GI_ChequeNumber).HasMaxLength(128);
            builder.Property(x => x.GI_SafteNumber).HasMaxLength(128);
            builder.Property(x => x.GI_ChequeBankBranch).HasMaxLength(128);
            builder.Property(x => x.GI_ShenaseSayadiCheque).HasMaxLength(128);
            //guaranty document
            builder.Property(x => x.GD_ChequeFrontSide).HasMaxLength(128);
            builder.Property(x => x.GD_ChequeBackSide).HasMaxLength(128);
            builder.Property(x => x.GD_SafteFrontSide).HasMaxLength(128);
            builder.Property(x => x.GD_SafteBackSide).HasMaxLength(128);

            builder.Property(x => x.RejectionReason);

            //relations
            builder.HasMany(x=>x.UpAccountRequestRejectionReasons).WithOne(x=>x.UpAccountRequest).HasForeignKey(x=>x.UpAccountRequestId);



        }
    }
}
