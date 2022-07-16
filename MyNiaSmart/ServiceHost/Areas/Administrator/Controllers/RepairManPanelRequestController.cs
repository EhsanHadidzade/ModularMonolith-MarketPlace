using Microsoft.AspNetCore.Mvc;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RepairManPanelRequestController : Controller
    {
        [TempData]
        public static string message { get; set; }
        private readonly IRepairManPanelApplication _repairManPanelApplication;
        public RepairManPanelRequestController(IRepairManPanelApplication repairManPanelApplication)
        {
            _repairManPanelApplication = repairManPanelApplication;
        }

        public IActionResult Index(string alert)
        {
            if (!string.IsNullOrWhiteSpace(alert))
                ViewData["message"] = RepairManPanelRequestController.message;

            var repairManPanels = _repairManPanelApplication.GetList();
            return View(repairManPanels);
        }

        public IActionResult ShowMoreInfo(long id)
        {
            //id==RepairManPanelId

            var repairManPanel = _repairManPanelApplication.GetDetails(id);
            return PartialView(repairManPanel);
        }

        public IActionResult Confirm(long id)
        {
            var result = _repairManPanelApplication.ConfirmByAdmin(id);
            RepairManPanelRequestController.message = result.Message;
            return Redirect("/Administrator/RepairManPanelRequest/Index?alert=notif");
        }
    }
}
