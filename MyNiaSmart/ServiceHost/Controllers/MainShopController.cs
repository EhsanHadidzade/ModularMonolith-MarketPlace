using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Product;

namespace ServiceHost.Controllers
{
    public class MainShopController : Controller
    {
        private readonly IProductApplication _productapplication;

        public MainShopController(IProductApplication productapplication)
        {
            _productapplication = productapplication;
        }

        public IActionResult Index()
        {
            var mainShopProducts = _productapplication.GetListForMainShop();
            return View(mainShopProducts);
        }
    }
}
