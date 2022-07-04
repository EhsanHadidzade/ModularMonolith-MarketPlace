using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public class GetOrderInfoToPay
    {
        public long Id { get; set; }
        public long UserAddressId { get; set; }
        public bool IsTransitionPartByPart { get; set; }

    }
}
