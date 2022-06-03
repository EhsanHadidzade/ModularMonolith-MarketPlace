    using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Application.Contract.ProductModel;
using ShopManagement.Application.Contract.ProductStatus;
using ShopManagement.Application.Contract.ProductType;
using ShopManagement.Application.Contract.ProductUsageType;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductApplication _productApplication;

        private readonly IProductTypeApplication _productTypeApplication;
        private readonly IProductBrandApplication _productBrandApplication;
        private readonly IProductModelApplication _productModelApplication;
        private readonly IProductStatusApplication _productStatusApplication;
        private readonly IProductUsageTypeApplication _productUsageTypeApplication;

        public ProductController(IProductApplication productApplication, IProductTypeApplication productTypeApplication,
            IProductBrandApplication productBrandApplication, IProductModelApplication productModelApplication,
            IProductStatusApplication productStatusApplication, IProductUsageTypeApplication productUsageTypeApplication)
        {
            _productApplication = productApplication;
            _productTypeApplication = productTypeApplication;
            _productBrandApplication = productBrandApplication;
            _productModelApplication = productModelApplication;
            _productStatusApplication = productStatusApplication;
            _productUsageTypeApplication = productUsageTypeApplication;
        }


        public IActionResult Index()
        {
            var products = _productApplication.GetList();
            return View(products);
        }

        #region CreateNewProduct

        public IActionResult Create()
        {
            
            ViewData["ProductTypes"] = new SelectList(_productTypeApplication.GetList(), "Id", "EngTitle");
            ViewData["ProductBrands"] = new SelectList(_productBrandApplication.GetList(), "Id", "EngTitle");
            ViewData["ProductModels"] = new SelectList(_productModelApplication.GetList(), "Id", "EngTitle");
            ViewData["ProductUsageTypes"] = new SelectList(_productUsageTypeApplication.GetList(), "Id", "EngTitle");
            ViewData["ProductStatuses"] = new SelectList(_productStatusApplication.GetList(), "Id", "EngTitle");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProduct command)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ProductTypes"] = new SelectList(_productTypeApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductBrands"] = new SelectList(_productBrandApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductModels"] = new SelectList(_productModelApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductUsageTypes"] = new SelectList(_productUsageTypeApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductStatuses"] = new SelectList(_productStatusApplication.GetList(), "Id", "EngTitle");
                return View(command);
            }

            var result = _productApplication.Create(command);
            if (!result.IsSuccedded)
            {
                ViewData["ProductTypes"] = new SelectList(_productTypeApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductBrands"] = new SelectList(_productBrandApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductModels"] = new SelectList(_productModelApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductUsageTypes"] = new SelectList(_productUsageTypeApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductStatuses"] = new SelectList(_productStatusApplication.GetList(), "Id", "EngTitle");
                ViewData["Message"] = result.Message;
                return View(command);
            }

            return Redirect("./index");
        }
        #endregion


        #region EditProduct
        public IActionResult Edit(long id)
        {
            var product = _productApplication.GetDetails(id);
            ViewData["ProductTypes"] = new SelectList(_productTypeApplication.GetList(), "Id", "EngTitle");
            ViewData["ProductBrands"] = new SelectList(_productBrandApplication.GetList(), "Id", "EngTitle");
            ViewData["ProductModels"] = new SelectList(_productModelApplication.GetList(), "Id", "EngTitle");
            ViewData["ProductUsageTypes"] = new SelectList(_productUsageTypeApplication.GetList(), "Id", "EngTitle");
            ViewData["ProductStatuses"] = new SelectList(_productStatusApplication.GetList(), "Id", "EngTitle");
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(EditProduct command)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ProductTypes"] = new SelectList(_productTypeApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductBrands"] = new SelectList(_productBrandApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductModels"] = new SelectList(_productModelApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductUsageTypes"] = new SelectList(_productUsageTypeApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductStatuses"] = new SelectList(_productStatusApplication.GetList(), "Id", "EngTitle");
                return View(command);
            }

            var result = _productApplication.Edit(command);
            if (!result.IsSuccedded)
            {
                ViewData["ProductTypes"] = new SelectList(_productTypeApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductBrands"] = new SelectList(_productBrandApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductModels"] = new SelectList(_productModelApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductUsageTypes"] = new SelectList(_productUsageTypeApplication.GetList(), "Id", "EngTitle");
                ViewData["ProductStatuses"] = new SelectList(_productStatusApplication.GetList(), "Id", "EngTitle");
                ViewData["Message"] = result.Message;
                return View(command);
            }

            return Redirect("/administrator/product/index");
        }

        #endregion

        #region FilterProductModels
        public IActionResult FilterModels(long brandId)
        {
            ViewData["FilteredProductModels"] = new SelectList(_productModelApplication.GetFilteredModels(brandId), "Id", "EngTitle");
            return PartialView("productModelSelectList");
        }
        #endregion


    }
}
