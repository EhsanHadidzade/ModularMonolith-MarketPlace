using ShopManagement.Application.Contract.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public class OrderViewModel
    {
        public long UserId { get; set; }
        public long TotalAmount { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderItemViewModel> orderItems { get; set; }
    }
}
