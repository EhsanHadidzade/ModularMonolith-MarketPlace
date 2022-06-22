using _0_Framework.Infrastructure;
using ShopManagement.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository:BaseRepository<long,Order>, IOrderRepository
    {
        private readonly ShopContext _shopContext;

        public OrderRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public bool DoesUserHaveOpenOrder(long userId)
        {
            return _shopContext.Orders.Any(x => x.UserId == userId && !x.IsPaid &&!x.IsCanceled);
        }

        public Order GetCurrentOrderByUserId(long userId)
        {
            return _shopContext.Orders.FirstOrDefault(x=>x.UserId == userId &&!x.IsPaid && !x.IsCanceled);
        }
    }
}
