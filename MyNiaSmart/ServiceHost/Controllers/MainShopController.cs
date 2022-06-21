using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Application.Contract.SellerProduct;
using System;
using System.Collections.Generic;

namespace ServiceHost.Controllers
{
    public class MainShopController : Controller
    {
        private readonly IProductApplication _productAapplication;
        private readonly ISellerPanelApplication _sellerPanelApplication;
        private readonly ISellerProductApplication _sellerProductApplication;

        public MainShopController(IProductApplication productApplication,
            ISellerPanelApplication sellerPanelApplication, ISellerProductApplication sellerProductApplication)
        {
            _productAapplication = productApplication;
            _sellerPanelApplication = sellerPanelApplication;
            _sellerProductApplication = sellerProductApplication;
        }

        public IActionResult Index()
        {
            var mainShopProducts = _productAapplication.GetListForMainShop();
            return View(mainShopProducts);
        }

        #region To Display Product Details Which Admin made
        public IActionResult ProductDetails(string id)
        {
            //id==ProductSlug
            var productDetails = _productAapplication.GetDetailsBySlug(id);
            var specialSellers = _sellerPanelApplication.GetSpecialSellersWhoSellingThisProduct(id, 0);
            var normalSellers = _sellerPanelApplication.GetNormalSellersWhoSellingThisProduct(id, 0);

            var model = new Tuple<EditProduct, List<SellerPanelForMainShopViewModel>, List<SellerPanelForMainShopViewModel>>(productDetails, specialSellers, normalSellers);
            return View(model);
        }

        #endregion

        #region To Display Product Details Which Seller Made
        [Route("/sellerProduct/{ShopName}/{slug}")]
        public IActionResult SellerProductDetails(string slug, string ShopName)
        {
            var ProductInfo = _sellerProductApplication.GetDetailsBySellerPanelNameAndProductSlug(ShopName, slug);
            return View(ProductInfo);
        }
        #endregion

        #region TO Filter sellers Tables of one product that is in product details view
        public IActionResult _SpecialSellers(string slug, int filterType)
        {
            var filteredSpecialSellers = _sellerPanelApplication.GetSpecialSellersWhoSellingThisProduct(slug, filterType);
            ViewData["ProductSlug"] = slug;
            return PartialView(filteredSpecialSellers);
        }
        public IActionResult _NormalSellers(string slug, int filterType)
        {
            var filteredSpecialSellers = _sellerPanelApplication.GetNormalSellersWhoSellingThisProduct(slug, filterType);
            ViewData["ProductSlug"] = slug;
            return PartialView(filteredSpecialSellers);
        }
        #endregion


    }
}
