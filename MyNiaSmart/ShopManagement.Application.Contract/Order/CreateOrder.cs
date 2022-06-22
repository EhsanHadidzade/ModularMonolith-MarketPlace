using ShopManagement.Application.Contract.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public class CreateOrder
    {
        public long UserId { get;  set; }
        public long TotalAmount { get;  set; }
        public int PaymentMethod { get;  set; }

        public List<CreateOrderItem> OrderItems { get;  set; }
    }
}
