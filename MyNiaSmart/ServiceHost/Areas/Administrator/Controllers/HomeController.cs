using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        [Area("Administrator")]
        public IActionResult Index()
        
        {
            return View();
        }
    }
}
