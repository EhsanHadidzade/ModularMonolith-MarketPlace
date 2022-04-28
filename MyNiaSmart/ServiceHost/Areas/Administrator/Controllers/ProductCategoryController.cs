using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Application.Contract.ProductModel;
using ShopManagement.Application.Contract.ProductStatus;
using ShopManagement.Application.Contract.ProductType;
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

        #region ProductBrand
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
        #endregion


        #region ProductModel
        public IActionResult _ProductModelCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _ProductModelCreate(CreateProductModel command)
        {
            var result = _productModelApplication.Create(command);
            return Redirect("./index");
        }
        public IActionResult _ProductModelEdit(long id)
        {
            var productModel = _productModelApplication.GetDetails(id);
            return PartialView(productModel);
        }
        [HttpPost]
        public IActionResult _ProductModelEdit(EditProductModel command)
        {
            var result = _productModelApplication.Edit(command);
            return Redirect("./index");
        }
        #endregion


        #region ProductStatus
        public IActionResult _ProductStatusCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _ProductStatusCreate(CreateProductStatus command)
        {
            var result = _productStatusApplication.Create(command);
            return Redirect("./index");
        }
        public IActionResult _ProductStatusEdit(long id)
        {
            var productStatus = _productStatusApplication.GetDetails(id);
            return PartialView(productStatus);
        }
        [HttpPost]
        public IActionResult _ProductStatusEdit(EditProductStatus command)
        {
            var result = _productStatusApplication.Edit(command);
            return Redirect("./index");
        }
        #endregion


        #region ProductType
        public IActionResult _ProductTypeCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _ProductTypeCreate(CreateProductType command)
        {
            var result = _productTypeApplication.Create(command);
            return Redirect("./index");
        }
        public IActionResult _ProductTypeEdit(long id)
        {
            var productType = _productTypeApplication.GetDetails(id);
            return PartialView(productType);
        }
        [HttpPost]
        public IActionResult _ProductTypeEdit(EditProductType command)
        {
            var result = _productTypeApplication.Edit(command);
            return Redirect("./index");
        }
        #endregion


        #region Productusagetype
        public IActionResult _ProductUsageTypeCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _ProductUsageTypeCreate(CreateProductUsageType command)
        {
            var result = _productUsageTypeApplication.Create(command);
            return Redirect("./index");
        }
        public IActionResult _ProductUsageTypeEdit(long id)
        {
            var productUsageType = _productUsageTypeApplication.GetDetails(id);
            return PartialView(productUsageType);
        }
        [HttpPost]
        public IActionResult _ProductUsageTypeEdit(EditProductUsageType command)
        {
            var result = _productUsageTypeApplication.Edit(command);
            return Redirect("./index");
        }
        #endregion
      
    }
}
