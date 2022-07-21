using Microsoft.AspNetCore.Mvc;
using RepairWorkShopManagement.Application.Contracts.ServiceTitle;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ServiceTitleController : Controller
    {
        public static string message { get; set; }
        private readonly IServiceTitleApplication _serviceTitleApplication;

        public ServiceTitleController(IServiceTitleApplication serviceTitleApplication)
        {
            _serviceTitleApplication = serviceTitleApplication;
        }

        public IActionResult Index(string alert)
        {
            if(!string.IsNullOrWhiteSpace(alert))
                ViewData["message"] = message;

            var serviceTitles=_serviceTitleApplication.GetList();
            return View(serviceTitles);
        }

        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(CreateServiceTitle command)
        {
            var result=_serviceTitleApplication.Create(command);
            message = result.Message;
            return Redirect("/Administrator/ServiceTitle/Index?alert=notif");
        }

        public IActionResult Edit(long id)
        {
            var systemService = _serviceTitleApplication.GetDetails(id);
            return PartialView(systemService);
        }

        [HttpPost]
        public IActionResult Edit(EditServiceTitle command)
        {
            var result = _serviceTitleApplication.Edit(command);
            message = result.Message;
            return Redirect("/Administrator/ServiceTitle/Index?alert=notif");
        }
    }
}
