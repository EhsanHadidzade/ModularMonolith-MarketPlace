using _0_Framework.Contract;
using AccountManagement.Application.Contract.PersonalWallet;
using AccountManagement.Application.Contract.UserAddress;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;

namespace ServiceHost.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApplication _orderApplication;
        private readonly IOrderItemApplication _orderItemApplication;
        private readonly IPersonalWalletApplication _personalWalletApplication;
        private readonly IUserAddressApplication _userAddressApplication;
        private readonly IAuthHelper _authHelper;
        public OrderController(IOrderApplication orderApplication, IOrderItemApplication orderItemApplication,
            IAuthHelper authHelper, IUserAddressApplication userAddressApplication,
            IPersonalWalletApplication personalWalletApplication)
        {
            _orderApplication = orderApplication;
            _orderItemApplication = orderItemApplication;
            _authHelper = authHelper;
            _userAddressApplication = userAddressApplication;
            _personalWalletApplication = personalWalletApplication;
        }

        public IActionResult CurrentOrder(long id)
        {
            //id==OrderId Of clicked Items
            var currentOrderItems = _orderApplication.GetOrderDetailsByOrderId(id);
            return View(currentOrderItems);
        }

        #region To open the modal in view of current order to display userAddresses

        public IActionResult SearchUserAddress()
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var userAddresses = _userAddressApplication.GetListByUserId(userId);
            return PartialView(userAddresses);

        }
        #endregion

        #region Pay Order With using Wallet PayMent method

        public IActionResult PayOrderByPersonalWallet(long id)
        {
            //id==Order Id 

            var userId= _authHelper.CurrentAccountInfo().Id;
            long personalWalletBalace=_personalWalletApplication.GetBalanceByUserId(userId);
            ViewData["PersonalWalletBalance"]=personalWalletBalace;

            var order = _orderApplication.GetOrderDetailsByOrderId(id);
            //ViewData["CurrentOrderAmount"] = order.TotalAmount;

            if (personalWalletBalace<order.TotalAmount)
                ViewData["NotAllowPay"] = true;

            return PartialView(order);
        }

        //[HttpPost]
        //public IActionResult PayOrderByPersonalWallet()
        //{

        //}

        #endregion


        #region To Update order of user while changing the count of orderItems

        public long UpdateOrder(long orderItemId, int count)
        {
            //we return related OrderId
            long orderId = _orderItemApplication.UpdateByIdAndCount(orderItemId, count);
            var orderTotalAmount = _orderApplication.GetTotalAmountById(orderId);
            return orderTotalAmount;
        }

        #endregion


        #region To find and select specific address for order
        public string SelectAddress(long id)
        {
            //id==UserAddressId
            var address = _userAddressApplication.GetDetails(id);
            var jsonresult = JsonConvert.SerializeObject(address);
            return jsonresult;
        }
        #endregion
    }
}
