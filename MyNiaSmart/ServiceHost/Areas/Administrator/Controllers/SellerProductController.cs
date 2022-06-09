using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.SellerProduct;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SellerProductController : Controller
    {
        public static string message { get; set; }
        private readonly ISellerProductApplication _sellerProductApplication;

        public SellerProductController(ISellerProductApplication sellerProductApplication)
        {
            _sellerProductApplication = sellerProductApplication;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = message;
            var sellerProducts = _sellerProductApplication.GetList();
            return View(sellerProducts);
        }

        public IActionResult ShowMoreInfo(long id)
        {
            //id==sellerProductId

            var sellerproduct = _sellerProductApplication.GetDetails(id);
            return View(sellerproduct);
        }

        public IActionResult ConfirmSellerProduct(long id)
        {
            //id==sellerProductId
            var result = _sellerProductApplication.ConfirmAProductByAdmin(id);
            SellerProductController.message = result.Message;
            return Redirect("/Administrator/sellerproduct/index");
        }
    }
}
