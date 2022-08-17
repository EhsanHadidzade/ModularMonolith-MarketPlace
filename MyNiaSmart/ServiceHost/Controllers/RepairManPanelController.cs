using _0_Framework.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepairWorkShopManagement.Application.Contracts.ImpairmentReportProduct;
using RepairWorkShopManagement.Application.Contracts.ImpairmentReportService;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;
using RepairWorkShopManagement.Application.Contracts.RepairManService;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using System;
using System.Collections.Generic;

namespace ServiceHost.Controllers
{
    public class RepairManPanelController : Controller
    {
        [TempData]
        public static string message { get; set; }
        private readonly long userId;
        private readonly IRepairManPanelApplication _repairManPanelApplication;
        private readonly IUserImpairmentReportApplication _userImpairmentReportApplication;
        private readonly IAuthHelper _authHelper;
        private readonly IRepairManServiceApplication _repairManServiceApplication;
        private readonly ISystemServiceApplication _systemServiceApplication;
        private readonly IImpairmentReportProductApplication _impairmentReportProductApplication;
        private readonly IImpairmentReportServiceApplication _impairmentReportServiceApplication;

        public RepairManPanelController(IRepairManPanelApplication repairManPanelApplication, IAuthHelper authHelper,
            IRepairManServiceApplication repairManServiceApplication, ISystemServiceApplication systemServiceApplication,
            IUserImpairmentReportApplication userImpairmentReportApplication, IImpairmentReportProductApplication impairmentReportProductApplication, 
            IImpairmentReportServiceApplication impairmentReportServiceApplication)
        {
            _authHelper = authHelper;
            _systemServiceApplication = systemServiceApplication;
            _repairManPanelApplication = repairManPanelApplication;
            _repairManServiceApplication = repairManServiceApplication;
             userId = _authHelper.CurrentAccountInfo().Id;
            _userImpairmentReportApplication = userImpairmentReportApplication;
            _impairmentReportProductApplication = impairmentReportProductApplication;
            _impairmentReportServiceApplication = impairmentReportServiceApplication;
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

        #region  Checking The Impairment Reports that are choosed To Handle By RepairMan panel
        public IActionResult ShowRelatedImpairmentReports()
        {
            var reports = _userImpairmentReportApplication.GetRepairManRelatedReports();
            return View(reports);
        }
        #endregion

        #region Show ImpairmentReport Details
        public IActionResult ShowReportDetails(long id)
        {
            //id=UserImpairmentReport
            var reportDetails = _userImpairmentReportApplication.GetDetails(id);
            var reportServices=_impairmentReportServiceApplication.GetListByImpairmentReportId(id);
            var reportProducts = _impairmentReportProductApplication.GetListByImpairmentReportId(id);

            var model = new Tuple<EditUserImpairmentReport, List<ImpairmentReportServiceViewModel>, List<ImpairmentReportProductViewModel>>
                (reportDetails, reportServices, reportProducts);

            return View(model);
        }
        #endregion

        #region Done Impairmet Reports Of RepairMan
        public IActionResult DoneImpairmentReports()
        {
            var userId=_authHelper.CurrentAccountInfo().Id;
            var list = _userImpairmentReportApplication.GetRepairmanDoneImpairment(userId);
            return View(list);
        }
        #endregion



    }
}
