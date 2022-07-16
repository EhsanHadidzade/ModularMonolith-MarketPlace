using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using ShopManagement.Application.Contract.ProductCategory.ProductModel;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SystemServiceController : Controller
    {
        public static string message { get; set; }
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
            if(SystemServiceController.message != null)
                ViewData["Message"] = message;

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
            SystemServiceController.message=result.Message;
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
            SystemServiceController.message = result.Message;
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
