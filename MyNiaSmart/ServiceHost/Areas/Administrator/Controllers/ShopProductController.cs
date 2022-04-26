using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administrator.Controllers
{
    public class ShopProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
