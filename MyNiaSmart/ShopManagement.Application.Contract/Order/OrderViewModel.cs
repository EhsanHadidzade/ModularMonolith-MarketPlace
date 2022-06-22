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
        public List<OrderItemViewModel> orderItems  { get; set; }
}
}
