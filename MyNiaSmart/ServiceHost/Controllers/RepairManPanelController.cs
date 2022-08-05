using _0_Framework.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;
using RepairWorkShopManagement.Application.Contracts.RepairManService;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using System.Collections.Generic;

namespace ServiceHost.Controllers
{
    public class RepairManPanelController : Controller
    {
        [TempData]
        public static string message { get; set; }
        private readonly long userId;
        private readonly IRepairManPanelApplication _repairManPanelApplication;
        private readonly IAuthHelper _authHelper;
        private readonly IRepairManServiceApplication _repairManServiceApplication;
        private readonly ISystemServiceApplication _systemServiceApplication;

        public RepairManPanelController(IRepairManPanelApplication repairManPanelApplication, IAuthHelper authHelper,
            IRepairManServiceApplication repairManServiceApplication, ISystemServiceApplication systemServiceApplication)
        {
            _authHelper = authHelper;
            _systemServiceApplication = systemServiceApplication;
            _repairManPanelApplication = repairManPanelApplication;
            _repairManServiceApplication = repairManServiceApplication;
            userId = _authHelper.CurrentAccountInfo().Id;
        }


        public IActionResult Index(string alert)
        {
            if (!string.IsNullOrWhiteSpace(alert))
                ViewData["message"] = message;

            var repairManPanelId = _repairManPanelApplication.GetRepairManPanelIdByUserId(userId);
            if (repairManPanelId == 0)
            {
                return BadRequest("Not Allowed");
            }

            var repairManServices = _repairManServiceApplication.GetListByRepairManPanelId(repairManPanelId);
            return View(repairManServices);
        }


        #region Requesting repair man to cooperate for list of SystemServices 

        public IActionResult AddServiceToRepairManPanel()
        {
            var systemServices = _systemServiceApplication.GetList();
            return View(systemServices);
        }

        // To Filter All SystemServices While RepairMan Is Adding New Services
        public IActionResult _FilteredSystemServices(long brandId, long modelId, long typeId, long usageTypeId)
        {
            var command = new FilterSystemServiceViewModel() { BrandId = brandId, ModelId = modelId, TypeId = typeId, usageTypeId = usageTypeId };
            var filteredServices = _systemServiceApplication.GetFilteredListByCategoryIds(command);
            return PartialView(filteredServices);
        }


        [HttpPost]
        public IActionResult AddServiceToRepairManPanel(List<long> ServiceIds)
        {
            var repairManPanelId = _repairManPanelApplication.GetRepairManPanelIdByUserId(userId);

            var command = new CreateRepairManService() { SelectedSystemServiceIds = ServiceIds, RepairManPanelId = repairManPanelId };
            var result = _repairManServiceApplication.Create(command);
            RepairManPanelController.message = result.Message;
            return RedirectToAction("/RepairManPanel/Index?alert=notif");
        }

        #endregion

        #region To Edit Specific Service that repairMan Has Added To Their panel
        public IActionResult EditRepairManService(long id)
        {
            var repairManService = _repairManServiceApplication.GetDetails(id);
            return View(repairManService);
        }


        [HttpPost]
        public IActionResult EditRepairManService(EditRepairManService command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var result = _repairManServiceApplication.Edit(command);
            RepairManPanelController.message = result.Message;
            return Redirect("/RepairManPanel/Index?alert=notif");
        }
        #endregion



    }
}
