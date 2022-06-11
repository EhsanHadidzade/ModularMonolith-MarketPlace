using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.SellerPanel;
using System;
using System.Collections.Generic;

namespace ServiceHost.Controllers
{
    public class MainShopController : Controller
    {
        private readonly IProductApplication _productAapplication;
        private readonly ISellerPanelApplication _sellerPanelApplication;

        public MainShopController(IProductApplication productApplication,
            ISellerPanelApplication sellerPanelApplication)
        {
            _productAapplication = productApplication;
            _sellerPanelApplication = sellerPanelApplication;
        }

        //[Route("{customerName}/{slug}/{sellerPanelId?}")]
        public IActionResult Index(/*string customerName,long slug, long? sellerPanelId*/)
        {
            var mainShopProducts = _productAapplication.GetListForMainShop();
            return View(mainShopProducts);
        }

        public IActionResult ProductDetails(string id)
        {
            //id==ProductSlug
            var productDetails=_productAapplication.GetDetailsBySlug(id);
            var specialSellers=_sellerPanelApplication.GetSpecialSellersWhoSellingThisProduct(id);
            var normalSellers = _sellerPanelApplication.GetNormalSellersWhoSellingThisProduct(id);

            var model = new Tuple<EditProduct, List<SellerPanelForMainShopViewModel>, List<SellerPanelForMainShopViewModel>>(productDetails, specialSellers, normalSellers);
            return View(model);
        }

    }
}
