using _0_Framework.Contract;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Application.Contract.SellerProduct;
using Newtonsoft.Json;

namespace ServiceHost.Controllers
{
    public class SellerPanelController : Controller
    {
        public static string message { get; set; }
        private readonly ISellerProductApplication _sellerProductApplication;
        private readonly ISellerPanelApplication _sellerPanelApplication;
        private readonly IProductApplication _productApplication;
        private readonly IAuthHelper _authHelper;

        public SellerPanelController(ISellerProductApplication sellerProductApplication,
            ISellerPanelApplication sellerPanelApplication, IAuthHelper authHelper, IProductApplication productApplication)
        {
            _sellerProductApplication = sellerProductApplication;
            _sellerPanelApplication = sellerPanelApplication;
            _authHelper = authHelper;
            _productApplication = productApplication;
        }

        public IActionResult Index()
        {
            var sellerProducts = _sellerProductApplication.GetList();
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
            if (!ModelState.IsValid)
                return View(command);

            var result = _sellerProductApplication.Edit(command);
            SellerPanelController.message = result.Message;
            return RedirectToAction("Index");
        }

        #endregion


        public IActionResult SearchProduct()
        {
            var products = _productApplication.GetList();
            return PartialView(products);
        }


        #region To select specific Product for create form or edit form

        public string addproduct(long id)
        {
            //var product = _productApplication.GetTitleAndIdBySlug(id);
            var product = _productApplication.GetTitleAndIdById(id);
            var jsonObject = JsonConvert.SerializeObject(product);
            return jsonObject;
        }
        #endregion




    }
}
