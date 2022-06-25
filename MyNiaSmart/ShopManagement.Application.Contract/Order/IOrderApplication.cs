using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public interface IOrderApplication
    {
        //using to Display current order Details ad items to user in his CurrentOrder View (his current cart) 
        OrderViewModel GetOrderDetailsByOrderId(long orderId);
    }
}
