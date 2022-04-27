using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Application.Contract.ProductStatus;
using ShopManagement.Application.Contract.ProductUsageType;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductTypeApplication _productTypeApplication;
        private readonly IProductBrandApplication _productBrandApplication;
        private readonly IProductModelApplication _productModelApplication;
        private readonly IProductStatusApplication _productStatusApplication;
        private readonly IProductUsageTypeApplication _productUsageTypeApplication;

        public ProductCategoryController(IProductTypeApplication productTypeApplication,
            IProductBrandApplication productBrandApplication,
            IProductModelApplication productModelApplication,
            IProductStatusApplication productStatusApplication,
            IProductUsageTypeApplication productUsageTypeApplication)
        {
            _productTypeApplication = productTypeApplication;
            _productBrandApplication = productBrandApplication;
            _productModelApplication = productModelApplication;
            _productStatusApplication = productStatusApplication;
            _productUsageTypeApplication = productUsageTypeApplication;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _ProductBrand()
        {
            var productBrand = _productBrandApplication.GetList();
            return PartialView(productBrand);
        }
        public IActionResult _ProductBrandCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _ProductBrandCreate(CreateProductBrand command)
        {
            var result=_productBrandApplication.Create(command);
            return Redirect("./index");
        }
        public IActionResult _ProductBrandEdit(long id)
        {
            var productBrand = _productBrandApplication.GetDetails(id);
            return PartialView(productBrand);
        }
        [HttpPost]
        public IActionResult _ProductBrandEdit(EditProductBrand command)
        {
            var result=_productBrandApplication.Edit(command);
            return Redirect("./index");
        }



        public IActionResult ProductModel()
        {
            var productModel = _productModelApplication.GetList();
            return PartialView(productModel);
        }
        public IActionResult ProductStatus()
        {
            var productStatus = _productStatusApplication.GetList();
            return PartialView(productStatus);
        }
        public IActionResult ProductType()
        {
            var productTypes = _productTypeApplication.GetList();
            return PartialView(productTypes);
        }
        public IActionResult ProductUsageType()
        {
            var productUsageType = _productStatusApplication.GetList();
            return PartialView(productUsageType);
        }
    }
}
