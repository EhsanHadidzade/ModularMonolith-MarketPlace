using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.SellerProductMedia;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SellerProductMediaController : Controller
    {
        private readonly ISellerProductMediaApplication _sellerProductMediaApplication;

        public SellerProductMediaController(ISellerProductMediaApplication sellerProductMediaApplication)
        {
            _sellerProductMediaApplication = sellerProductMediaApplication;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
