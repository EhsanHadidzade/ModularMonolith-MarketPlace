using _0_Framework.Infrastructure;
using ShopManagement.Domain.OrderItemAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderItemRepository:BaseRepository<long,OrderItem>,IOrderItemRepository
    {
        private readonly ShopContext _shopContext;

        public OrderItemRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }
    }
}
