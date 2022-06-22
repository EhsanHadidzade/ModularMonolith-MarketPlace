using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.OrderItem
{
    public interface IOrderItemApplication
    {
        //To Use when client want to buy a product and click on button(افزودن به سبد خرید)
        OperationResult AddOrderItem(CreateOrderItem command);

       
        List<OrderItemViewModel> GetCurrdentOrderItemsByUserId(long userId);
    }
}
