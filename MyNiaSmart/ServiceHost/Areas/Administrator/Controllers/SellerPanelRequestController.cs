using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SellerPanelRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
