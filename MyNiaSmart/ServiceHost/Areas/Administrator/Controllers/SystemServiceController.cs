using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using ShopManagement.Application.Contract.ProductCategory.ProductModel;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SystemServiceController : Controller
    {
        private readonly ISystemServiceApplication _systemServiceApplication;
        private readonly IProductModelApplication _productModelApplication;

        public SystemServiceController(ISystemServiceApplication systemServiceApplication, 
            IProductModelApplication productModelApplication)
        {
            _systemServiceApplication = systemServiceApplication;
            _productModelApplication = productModelApplication;
        }

        public IActionResult Index()
        {
            var systemServices = _systemServiceApplication.GetList();
            return View(systemServices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateSystemService command)
        {
            var result = _systemServiceApplication.Create(command);
            return Redirect("/Administrator/SystemService/Index");
        }

        public IActionResult Edit(long id)
        {
            var systemService = _systemServiceApplication.GetDetails(id);
            return View(systemService);
        }

        [HttpPost]
        public IActionResult Edit(EditSystemService command)
        {
            var result = _systemServiceApplication.Edit(command);
            return Redirect("/Administrator/SystemService/Index");
        }


        #region FilterProductModels
        public IActionResult FilterModels(long brandId)
        {
            ViewData["FilteredProductModels"] = new SelectList(_productModelApplication.GetFilteredModels(brandId), "Id", "EngTitle");
            return PartialView("productModelSelectList");
        }
        #endregion


    }
}
