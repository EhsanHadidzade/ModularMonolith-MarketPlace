using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult CallBack([FromQuery] string authority, [FromQuery] string status,
        //    [FromQuery] long woId)
        //{
        //    var personalWallet
        //    return View();
        //}
    }
}
