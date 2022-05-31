using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.SellerPanel;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SellerPanelRequestController : Controller
    {
        private readonly ISellerPanelApplication _sellerPanelApplication;

        public SellerPanelRequestController(ISellerPanelApplication sellerPanelApplication)
        {
            _sellerPanelApplication = sellerPanelApplication;
        }

        public IActionResult Index()
        {
            var sellerPanelRequest = _sellerPanelApplication.GetList();
            return View(sellerPanelRequest);
        }

        public IActionResult ShowMoreInfo(long id)
        {
            var sellerPanelRequest = _sellerPanelApplication.GetDetails(id);
            return PartialView(sellerPanelRequest);
        }

        [HttpPost]
        public IActionResult Confirm(long sellerpanelid)
        {
            _sellerPanelApplication.ConfirmByAdmin(sellerpanelid);
            return Redirect("./index");
        }
    }
}
