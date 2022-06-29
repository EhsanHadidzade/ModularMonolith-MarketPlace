using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserOrderController : Controller
    {
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
    }
}
