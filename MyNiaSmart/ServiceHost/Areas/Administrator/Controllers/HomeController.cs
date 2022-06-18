using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        [Area("Administrator")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
