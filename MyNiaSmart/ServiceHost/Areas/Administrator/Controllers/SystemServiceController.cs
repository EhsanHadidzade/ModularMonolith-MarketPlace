using Microsoft.AspNetCore.Mvc;
using RepairWorkShopManagement.Application.Contracts.SystemService;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SystemServiceController : Controller
    {
        private readonly ISystemServiceApplication _systemServiceApplication;

        public SystemServiceController(ISystemServiceApplication systemServiceApplication)
        {
            _systemServiceApplication = systemServiceApplication;
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
            return RedirectToAction("./index");
        }

        public IActionResult Edit(long id)
        {
            var systemService=_systemServiceApplication.GetDetails(id);
            return View(systemService);
        }

        [HttpPost]
        public IActionResult Edit(EditSystemService command)
        {
            var result=_systemServiceApplication.Edit(command);
            return RedirectToAction("./index");
        }
    }
}
