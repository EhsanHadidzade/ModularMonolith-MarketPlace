using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.SellerPanel;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SellerPanelRequestController : Controller
    {
        public static string message { get; set; }
        private readonly ISellerPanelApplication _sellerPanelApplication;
        public SellerPanelRequestController(ISellerPanelApplication sellerPanelApplication)
        {
            _sellerPanelApplication = sellerPanelApplication;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrWhiteSpace(message))
                ViewData["Message"] = message;
            var sellerPanelRequest = _sellerPanelApplication.GetList();
            return View(sellerPanelRequest);
        }

        public IActionResult ShowMoreInfo(long id)
        {
            var sellerPanelRequest = _sellerPanelApplication.GetDetails(id);
            return PartialView(sellerPanelRequest);
        }

        public IActionResult Confirm(long id)
        {
            var result = _sellerPanelApplication.ConfirmByAdmin(id);
            SellerPanelRequestController.message = result.Message;
            return Redirect("/Administrator/SellerPanelRequest/index");
        }

        public IActionResult Cancel(long id)
        {
            var result = _sellerPanelApplication.CancelByAdmin(id);
            SellerPanelRequestController.message = result.Message;
            return Redirect("/Administrator/SellerPanelRequest/index");
        }

        public IActionResult SelectAsSpecial(long id)
        {
            var result = _sellerPanelApplication.SelectAsSpecial(id);
            SellerPanelRequestController.message = result.Message;
            return Redirect("/Administrator/SellerPanelRequest/index");
        }
    }
}
