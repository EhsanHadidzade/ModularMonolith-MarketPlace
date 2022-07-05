using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserOrderController : Controller
    {
        public static string message { get; set; }
        private readonly IOrderApplication _orderApplication;
        private readonly IOrderItemApplication _orderItemApplication;

        public UserOrderController(IOrderApplication orderApplication,
            IOrderItemApplication orderItemApplication)
        {
            _orderApplication = orderApplication;
            _orderItemApplication = orderItemApplication;
        }

        public IActionResult Index()
        {
            var orders = _orderApplication.GetList();
            return View(orders);
        }

        public IActionResult ShowOrderItems(long id)
        {
            //id==Order Id Passed
            var orderItems = _orderItemApplication.GetListByOrderId(id);
            return PartialView(orderItems);
        }

        public IActionResult DisplayUserAddressToSendProduct(long id)
        {
            //id==Order Id Passed To Find Address
            var userAddress = _orderApplication.GetUserAddressById(id);
            return PartialView(userAddress);
        }

       
    }
}
