﻿using _0_Framework.Contract;
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

        public IActionResult _ListOfSystemService()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddServiceToRepairManPanel(List<long> ServiceId)
        {

            //var result = _repairManServiceApplication.Create(command);
            //RepairManPanelController.message = result.Message;
            return RedirectToAction("Index");
        }

        #endregion

        #region To Edit Specific Service that repairMan Has Added To Their panel
        public IActionResult EditService(long id)
        {
            var repairManService = _repairManServiceApplication.GetDetails(id);
            return View(repairManService);
        }

        [HttpPost]
        public IActionResult EditService(EditRepairManService command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var result = _repairManServiceApplication.Edit(command);
            SellerPanelController.message = result.Message;
            return RedirectToAction("Index");
        }
        #endregion

        #region To Show List Of Application Service Defined By Administrator, using while repair man want to select one to request to add tp their panel
        public IActionResult SearchService()
        {
            var services = _systemServiceApplication.GetList();
            return PartialView(services);
        }
        #endregion

        #region AJAX =>  To select specific System Service from SearchServicePartialView for create form or edit form 
        //public string addService(long id)
        //{
        //    var service = _systemServiceApplication.GetTitleAndIdById(id);
        //    var jsonObject = JsonConvert.SerializeObject(service);
        //    return jsonObject;
        //}
        #endregion
    }
}
