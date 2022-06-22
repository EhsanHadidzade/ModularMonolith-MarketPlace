using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.OrderItem
{
    public class OrderItemViewModel
    {
        public long SellerProductId { get; set; }
        public string SellerProductTitle { get; set; }
        public long UnitPrice { get; set; }
        public int Count { get; set; }
    }
}
