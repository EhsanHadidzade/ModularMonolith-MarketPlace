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

        //TO get Amount of order total Amount when user is changing order Items
        long GetTotalAmountById(long orderId);


        //To Show List Of All Orders With All Items In AdminPanel
        List<OrderViewModel> GetList();



        //To Find List Of current user Orders in his profile
        List<OrderViewModel> GetUserCurrentOrdersByUserId(long userId);

        //To Find List Of  user RecievedOrders in his profile
        List<OrderViewModel> GetUserRecievedOrdersByUserId(long userId);

        //To Find List Of  user Canceled Orders in his profile
        List<OrderViewModel> GetUserCanceledOrdersByUserId(long userId);

        #region using in seller panel to manage Orders of clients

        //To Find List Of orders in seller panel
        List<OrderViewModel> GetCustomerOrdersInSellerPanelBySellerUserId(long userId);
        #endregion






    }
}
