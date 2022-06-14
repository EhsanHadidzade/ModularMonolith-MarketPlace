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
        public IActionResult Index()
        {
            var mainShopProducts = _productAapplication.GetListForMainShop();
            return View(mainShopProducts);
        }

        public IActionResult ProductDetails(string id)
        {
            //id==ProductSlug
            var productDetails = _productAapplication.GetDetailsBySlug(id);
            var specialSellers = _sellerPanelApplication.GetSpecialSellersWhoSellingThisProduct(id, 0);
            var normalSellers = _sellerPanelApplication.GetNormalSellersWhoSellingThisProduct(id, 0);

            var model = new Tuple<EditProduct, List<SellerPanelForMainShopViewModel>, List<SellerPanelForMainShopViewModel>>(productDetails, specialSellers, normalSellers);
            return View(model);
        }

        //[Route("{ShopName}/{slug}/{sellerPanelId?}")]
        //[Route("Shop")]
        [Route("/sellerProduct/{slug}/{ShopName}")]
        public IActionResult SellerProductDetails(string slug, string ShopName)
        {
            return View();
        }

        #region TO Filter sellers Tables of one product that is in product details view
        public IActionResult _SpecialSellers(string slug, int filterType)
        {
            var filteredSpecialSellers = _sellerPanelApplication.GetSpecialSellersWhoSellingThisProduct(slug, filterType);
            return PartialView(filteredSpecialSellers);
        }
        public IActionResult _NormalSellers(string slug, int filterType)
        {
            var filteredSpecialSellers = _sellerPanelApplication.GetNormalSellersWhoSellingThisProduct(slug, filterType);
            return PartialView(filteredSpecialSellers);
        }
        #endregion


    }
}
