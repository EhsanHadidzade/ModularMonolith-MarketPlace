using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;

namespace ServiceHost.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApplication _orderApplication;
        private readonly IOrderItemApplication _orderItemApplication;

        public OrderController(IOrderApplication orderApplication, IOrderItemApplication orderItemApplication)
        {
            _orderApplication = orderApplication;
            _orderItemApplication = orderItemApplication;
        }

        public IActionResult CurrentOrder(long id)
        {
            var currentOrderItems=_orderApplication.GetCurrentOrderWithItemsByOrderId(id);
            return View();
        }
    }
}
