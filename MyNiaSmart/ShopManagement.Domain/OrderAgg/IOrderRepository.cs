using _0_Framework.Domain;
using ShopManagement.Application.Contract.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.OrderAgg
{
    public interface IOrderRepository : IRepository<long, Order>
    {
        //To check order of user when new order Item is adding , if he has open order, we add new item to it
        bool DoesUserHaveOpenOrder(long userId);

        //To Get Order Of User .using in placeing new order
        Order GetCurrentOrderByUserId(long userId);

        //using to Display current order Details ad items to user in his CurrentOrder View (his current cart) 
        OrderViewModel GetOrderDetailsByOrderId(long orderId);




    }
}
