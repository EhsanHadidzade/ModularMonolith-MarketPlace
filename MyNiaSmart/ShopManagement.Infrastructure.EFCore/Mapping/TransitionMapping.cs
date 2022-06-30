using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.TransitionAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class TransitionMapping : IEntityTypeConfiguration<Transition>
    {
        public void Configure(EntityTypeBuilder<Transition> builder)
        {
            builder.ToTable("Transitions");
            builder.HasKey(x =>x.Id);

            builder.Property(x => x.TrackingNumber).HasMaxLength(10);

            builder.HasOne(x => x.SellerPanel).WithMany(x => x.Transitions).HasForeignKey(x => x.SellerPanelId);
            //builder.HasMany(x=>x.OrderItems).WithOne(x=>x.Transition).HasForeignKey(x => x.TransitionId);
        }
    }
}
