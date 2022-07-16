using Microsoft.AspNetCore.Mvc;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;

namespace ServiceHost.Controllers
{
    public class RepairManPanelController : Controller
    {
        private readonly IRepairManPanelApplication _repairManPanelApplication;

        public RepairManPanelController(IRepairManPanelApplication repairManPanelApplication)
        {
            _repairManPanelApplication = repairManPanelApplication;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
