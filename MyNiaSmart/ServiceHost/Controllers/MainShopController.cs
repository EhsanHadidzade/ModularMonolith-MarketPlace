using _0_Framework.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagement.Application.Contract.OrderItem;
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
        private readonly IOrderItemApplication _orderItemApplication;
        private readonly IAuthHelper _authHelper;

        public MainShopController(IProductApplication productApplication,
            ISellerPanelApplication sellerPanelApplication, ISellerProductApplication sellerProductApplication,
            IOrderItemApplication orderItemApplication, IAuthHelper authHelper)
        {
            _productAapplication = productApplication;
            _sellerPanelApplication = sellerPanelApplication;
            _sellerProductApplication = sellerProductApplication;
            _orderItemApplication = orderItemApplication;
            _authHelper = authHelper;
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

        #region To Add SellerProduct To User current open order
        public IActionResult AddItem(long sellerProductId,long unitPrice)
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var command = new CreateOrderItem()
            {
                SellerProductId = sellerProductId,
                UnitPrice = unitPrice,
                Count = 1
            };
            var result=_orderItemApplication.AddOrderItem(command);
            var orderItems = _orderItemApplication.GetCurrdentOrderItemsByUserId(userId);
            ViewData["AddOrderItemResult"] = result.Message;
           
            return PartialView("LeftBarOrderItem",orderItems);
            //var jsonResult=JsonConvert.SerializeObject(result);
            //return jsonResult;
        }

        #endregion


    }
}
