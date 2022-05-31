using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Application.Contract.SellerProduct;

namespace ServiceHost.Controllers
{
    public class SellerPanelController : Controller
    {
        private readonly ISellerProductApplication _sellerProductApplication;
        private readonly ISellerPanelApplication _sellerPanelApplication;

        public SellerPanelController(ISellerProductApplication sellerProductApplication,
            ISellerPanelApplication sellerPanelApplication)
        {
            _sellerProductApplication = sellerProductApplication;
            _sellerPanelApplication = sellerPanelApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
    }
}
