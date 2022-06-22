using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.OrderItemAgg
{
    public interface IOrderItemRepository:IRepository<long,OrderItem>
    {

    }
}
