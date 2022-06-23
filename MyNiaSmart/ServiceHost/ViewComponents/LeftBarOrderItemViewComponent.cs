using _0_Framework.Contract;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.OrderItem;

namespace ServiceHost.ViewComponents
{
    public class LeftBarOrderItemViewComponent:ViewComponent
    {
        private readonly IOrderItemApplication _orderItemApplication;
        private readonly IAuthHelper _authHelper;

        public LeftBarOrderItemViewComponent(IOrderItemApplication orderItemApplication,
            IAuthHelper authHelper)
        {
            _orderItemApplication = orderItemApplication;
            _authHelper = authHelper;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var orderItems = _orderItemApplication.GetCurrdentOrderItemsByUserId(userId);
            return View(orderItems);    
        }
    }
}
