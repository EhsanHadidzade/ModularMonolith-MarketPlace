using _0_Framework.Domain;
using AccountManagement.Application.Contract.UserAddress;
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
        //using when we want to check if an order has item that is not transitted or not in transitting method .
        Order GetWithOrderItemsById(long id);
        //To check order of user when new order Item is adding , if he has open order, we add new item to it
        bool DoesUserHaveOpenOrder(long userId);

        //To Get Order Of User .using in placeing new order
        Order GetCurrentOrderByUserId(long userId);

        //using to Display current order Details ad items to user in his CurrentOrder View (his current cart) 
        OrderViewModel GetOrderDetailsByOrderId(long orderId);

        //TO get Amount of order total Amount when user is changing order Items
        long GetTotalAmountById(long orderId);

        //To Show List Of All Orders With All Items In AdminPanel
        List<OrderViewModel> GetList();



        #region User personal Profile 
        //To Find List Of current user Orders in his profile
        List<OrderViewModel> GetUserCurrentOrdersByUserId(long userId);

        //To Find List Of  user RecievedOrders in his profile
        List<OrderViewModel> GetUserRecievedOrdersByUserId(long userId);

        //To Find List Of  user Canceled Orders in his profile
        List<OrderViewModel> GetUserCanceledOrdersByUserId(long userId);
        #endregion

        #region Seller User Orders Management
        //To Find List Of orders in seller panel
        List<OrderViewModel> GetCustomerOrdersInSellerPanelBySellerUserId(long userId);

        //Using To Display User Address In OrderList For AdminAnd Seller Panel TO Show Seller Where To Send Product
        UserAddressViewModel GetUserAddressById(long orderId);

        #endregion



    }
}
