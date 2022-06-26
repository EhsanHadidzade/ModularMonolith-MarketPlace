using _0_Framework.Contract;
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
        private readonly IUserAddressApplication _userAddressApplication;
        private readonly IAuthHelper _authHelper;
        public OrderController(IOrderApplication orderApplication, IOrderItemApplication orderItemApplication,
            IAuthHelper authHelper, IUserAddressApplication userAddressApplication)
        {
            _orderApplication = orderApplication;
            _orderItemApplication = orderItemApplication;
            _authHelper = authHelper;
            _userAddressApplication = userAddressApplication;
        }

        public IActionResult CurrentOrder(long id)
        {
            //id==OrderId Of clicked Items
            var currentOrderItems = _orderApplication.GetOrderDetailsByOrderId(id);
            return View(currentOrderItems);
        }

        public IActionResult SearchUserAddress()
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var userAddresses = _userAddressApplication.GetListByUserId(userId);
            return PartialView(userAddresses);

        }

        public long UpdateOrder(long orderItemId, int count)
        {
            //we return related OrderId
            long orderId = _orderItemApplication.UpdateByIdAndCount(orderItemId, count);
            var orderTotalAmount=_orderApplication.GetTotalAmountById(orderId);
            return orderTotalAmount;
        }

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
