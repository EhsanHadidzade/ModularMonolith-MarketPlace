using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OrderItemAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.Order).WithMany(x=>x.OrderItems).HasForeignKey(x=>x.OrderId);
            //builder.HasOne(x=>x.Transition).WithMany(x=>x.OrderItems).HasForeignKey(x=>x.TransitionId);
        }
    }
}
