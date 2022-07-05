using _0_Framework.Contract;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Application.Contract.SellerProduct;
using Newtonsoft.Json;
using ShopManagement.Application.Contract.SellerProductMedia;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.OrderItem;
using ShopManagement.Application.Contract.Transition;

namespace ServiceHost.Controllers
{
    public class SellerPanelController : Controller
    {
        public static string message { get; set; }
        //public static List<long> SelectedMedias { set; get; }
        private readonly IAuthHelper _authHelper;
        private readonly IOrderApplication _orderApplication;
        private readonly IProductApplication _productApplication;
        private readonly IOrderItemApplication _orderItemApplication;
        private readonly ITransitionApplication _transitionApplication;
        private readonly ISellerPanelApplication _sellerPanelApplication;
        private readonly ISellerProductApplication _sellerProductApplication;
        private readonly ISellerProductMediaApplication _sellerProductMediaApplication;

        public SellerPanelController(ISellerProductApplication sellerProductApplication,
            ISellerPanelApplication sellerPanelApplication, IAuthHelper authHelper, IProductApplication productApplication,
            ISellerProductMediaApplication sellerProductMediaApplication, IOrderApplication orderApplication,
            IOrderItemApplication orderItemApplication, ITransitionApplication transitionApplication)
        {
            _sellerProductApplication = sellerProductApplication;
            _sellerPanelApplication = sellerPanelApplication;
            _authHelper = authHelper;
            _productApplication = productApplication;
            _sellerProductMediaApplication = sellerProductMediaApplication;
            _orderApplication = orderApplication;
            _orderItemApplication = orderItemApplication;
            _transitionApplication = transitionApplication;
        }

        public IActionResult Index()
        {
            //TO Find Seller PanelId
            var userId = _authHelper.CurrentAccountInfo().Id;
            var sellerPanelId = _sellerPanelApplication.GetSellerPanelIdByUserId(userId);


            var sellerProducts = _sellerProductApplication.GetListBySellerPanelId(sellerPanelId);
            ViewData["message"] = SellerPanelController.message;
            return View(sellerProducts);
        }

        #region Request of seller to add new product to his seller panel

        //[Route("/SellerPanel/AddProductToSellerPanel/{Slug}")]
        [Route("/SellerPanel/AddProductToSellerPanel")]
        public IActionResult AddProductToSellerPanel()
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var sellerPanelId = _sellerPanelApplication.GetSellerPanelIdByUserId(userId);
            var command = _sellerProductApplication.PrepareModelForCreationBySellerPanelId(sellerPanelId);
            command.SellerPanelId = sellerPanelId;
            return View(command);
        }

        [HttpPost]
        [Route("/SellerPanel/AddProductToSellerPanel")]
        public IActionResult AddProductToSellerPanel(CreateSellerProduct command)
        {
            //command.SelectedMediaIds = SelectedMedias;
            if (!ModelState.IsValid)
                return View(command);

            var reslut = _sellerProductApplication.Create(command);
            SellerPanelController.message = reslut.Message;
            return RedirectToAction("Index");
        }

        #endregion

        #region To Edit Specific Product Details

        public IActionResult EditProduct(long id)
        {
            var product = _sellerProductApplication.GetDetails(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(EditSellerProduct command)
        {
            //command.SelectedMediaIds = SelectedMedias;
            if (!ModelState.IsValid)
                return View(command);

            var result = _sellerProductApplication.Edit(command);
            SellerPanelController.message = result.Message;
            return RedirectToAction("Index");
        }

        #endregion

        #region To Show List of products of application that seller is going to cooperate to sell them

        public IActionResult SearchProduct()
        {
            var products = _productApplication.GetList();
            return PartialView(products);
        }
        #endregion

        #region To select specific Product from SearchProductPartialView  for create form or edit form

        public string addproduct(long id)
        {
            //var product = _productApplication.GetTitleAndIdBySlug(id);
            var product = _productApplication.GetTitleAndIdById(id);
            var jsonObject = JsonConvert.SerializeObject(product);
            return jsonObject;
        }
        #endregion

        #region To Show The Gallery Of user that need to use for thier products
        public IActionResult ShowGallery(long id)
        {
            //id==SellerProductId
            var userId = _authHelper.CurrentAccountInfo().Id;
            var sellerMedias = _sellerProductMediaApplication.GetUserGalleryMediasByUserId(userId);
            var selectedMediaIds = _sellerProductMediaApplication.GetSelectedMediaIdsOfSellerProductBySellerProductIdAndUserId(id, userId);
            var model = new Tuple<List<SellerGalleryViewModel>, List<long>, long>(sellerMedias, selectedMediaIds, id);
            return PartialView(model);
        }

        [HttpPost]
        public string AddMediaToGallery(IFormFile newMedia)
        {
            var command = new CreateMediaForSellerGallery() { Media = newMedia };
            var result = _sellerProductMediaApplication.CreateMediaForGallery(command);
            if (result.IsSuccedded)
            {
                var MediaURL = _sellerProductMediaApplication.GetMediaById(result.Id).MediaURL;
                result.Message = MediaURL;
                var jsonResult = JsonConvert.SerializeObject(result);
                return jsonResult;
            }
            var jsonObject = JsonConvert.SerializeObject(result);
            return jsonObject;


        }
        #endregion  

        #region To Choose the selected Media For specific Product
        // این متد تنها جنبه ی نمایش عکس روی صفحه اصلی فرم افزودن محصول دارد. و در هنگام سابمیت فرم محصول ، تصاویر برای محصول مورد نظر ذخیره خواهد شد
        [HttpPost]
        public string ChooseMedia(List<long> selectedMedia)
        {
            //SellerPanelController.SelectedMedias = selectedMedia;
            var SelectedMediaList = new List<SellerGalleryViewModel>();
            foreach (var id in selectedMedia.Where(x => x > 0))
            {
                var media = _sellerProductMediaApplication.GetMediaById(id);
                SelectedMediaList.Add(media);
            }
            var jsonResult = JsonConvert.SerializeObject(SelectedMediaList);
            return jsonResult;

        }
        #endregion

        #region To Delete Selected media from Gallery of seller
        [HttpPost]
        public string DeleteMedia(List<long> selectedMedia)
        {
            var result = _sellerProductMediaApplication.DeleteSellerMediasByMediaIds(selectedMedia);
            result.Message = "done";
            var jsonObject = JsonConvert.SerializeObject(result);
            return jsonObject;

        }
        #endregion

        #region To manage orders which are including items that are related to seller
        public IActionResult UserOrderManagement()
        {
            if (SellerPanelController.message != null)
                ViewData["message"] = message;

            var userId = _authHelper.CurrentAccountInfo().Id;
            var orders = _orderApplication.GetCustomerOrdersInSellerPanelBySellerUserId(userId);
            return View(orders);
        }

        public IActionResult UserOrderItemsManagement(long id)
        {
            //id==order id passed to find orderItems
            var userId = _authHelper.CurrentAccountInfo().Id;
            var sellerPanelId=_sellerPanelApplication.GetSellerPanelIdByUserId(userId);
            var orderItems=_orderItemApplication.GetListWhichRelatedToSellerByOrderIdAndSellerPanelId(id,sellerPanelId);
            return PartialView(orderItems);
        }

        //To Create New Transition For Specific Items
        [HttpPost]
        public IActionResult SendItemsBySeller(List<long> OrderItemIdsOwnedBySeller)
        {
            if (OrderItemIdsOwnedBySeller.Count == 0)
            {
                SellerPanelController.message = "موردی یافت نشد";
                return Redirect("/SellerPanel/UserOrderManagement");
            }

            var result=_orderItemApplication.SendOrderItemsBySellerWithIds(OrderItemIdsOwnedBySeller);
            SellerPanelController.message=result.Message;
            return Redirect("/SellerPanel/UserOrderManagement");
        }

        //TO Display Specific Address That user choosed To Receive product
        public IActionResult DisplayUserAddressToSendProduct(long id)
        {
            //id==Order Id Passed To Find Address

            var userAddress = _orderApplication.GetUserAddressById(id);
            return PartialView(userAddress);
        }
        #endregion

        #region To Manage All Transitions which are operated By Seller
        public IActionResult SellerTransition()
        {
            if (SellerPanelController.message != null)
                ViewData["message"] = message;

            //TO Find Seller PanelId
            var userId = _authHelper.CurrentAccountInfo().Id;
            var sellerPanelId = _sellerPanelApplication.GetSellerPanelIdByUserId(userId);

            var transitions = _transitionApplication.GetListBySellerPanelId(sellerPanelId);
            return View(transitions);
        }
        
        public IActionResult DisplayTransitionOrderItems(long id)
        {
            //id== Transition Id Passed TO Find orderItems
            var orderItems=_orderItemApplication.GetListByTransitionId(id);
            return PartialView(orderItems);
        }

        public IActionResult SetTransitionFinished(long id)
        {
            //id== Transition Id Passed TO Find orderItems
            var result = _transitionApplication.FinishTransitionById(id);
            SellerPanelController.message = result.Message;
            return Redirect("/SellerPanel/SellerTransition");

        }
        #endregion


    }
}
