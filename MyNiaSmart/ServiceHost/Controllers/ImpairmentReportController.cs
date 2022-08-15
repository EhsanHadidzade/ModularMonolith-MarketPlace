using _0_Framework.Contract;
using AccountManagement.Application.Contract.UserDevice;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Controllers
{
    public class ImpairmentReportController : Controller
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserDeviceApplication _userDeviceApplication;
        private readonly ISystemServiceApplication _systemServiceApplication;
        private readonly IUserImpairmentReportApplication _userImpairmentReportApplication;
        private readonly IProductApplication _productApplication;
        private readonly IRepairManPanelApplication _repairManPanelApplication;

        public ImpairmentReportController(IUserImpairmentReportApplication userImpairmentReportApplication,
            IUserDeviceApplication userDeviceApplication, IAuthHelper authHelper, ISystemServiceApplication systemServiceApplication,
            IProductApplication productApplication, IRepairManPanelApplication repairManPanelApplication)
        {
            _userImpairmentReportApplication = userImpairmentReportApplication;
            _userDeviceApplication = userDeviceApplication;
            _authHelper = authHelper;
            _systemServiceApplication = systemServiceApplication;
            _productApplication = productApplication;
            _repairManPanelApplication = repairManPanelApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region To Report New Impairment By User

        public IActionResult ReportNewImpairment()
        {
            return View();
        }



        //MODAL => To Show List Of UserDevices To Select Between Them for reporting new Impairment
        public IActionResult ShowUserDevice()
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var userDevices = _userDeviceApplication.GetListByUserId(userId);
            return PartialView(userDevices);
        }

        //AJAX => To Find Title OF Device While User Is selecting them in Impairment Report Form
        public string SelectDevice(long id)
        {
            var userDevice = _userDeviceApplication.GetInfoById(id);
            var jsonObject = JsonConvert.SerializeObject(userDevice);
            return jsonObject;
        }

        // To Filter All SystemServices While RepairMan Is Adding New Services
        public IActionResult _FilteredSystemServices(long brandId, long modelId, long typeId, long usageTypeId)
        {
            var command = new FilterSystemServiceViewModel() { BrandId = brandId, ModelId = modelId, TypeId = typeId, usageTypeId = usageTypeId };
            var filteredServices = _systemServiceApplication.GetFilteredListByCategoryIds(command);
            return PartialView(filteredServices);
        }

        [HttpPost]
        public IActionResult ReportNewImpairment(CreateUserImpairmentReport command,List<long> serviceIds)
        {
            command.UserId = _authHelper.CurrentAccountInfo().Id;
            command.SelectedSystemServiceIds = serviceIds;
            var result = _userImpairmentReportApplication.Create(command);
            return Redirect("/home/Index");

        }

        #endregion

        #region To Show Current List Of  User Impairment Reports That are in process By RepairMans
        public IActionResult CurrentImpairmentReport()
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var userImpairment = _userImpairmentReportApplication.GetCurrentUserImpairmentReports(userId);

            return View(userImpairment);
        }

        #endregion

        #region To Edit ImpairmentReport And Its Services
        public IActionResult EditUserImpairmentReport(long id)
        {
            var model = _userImpairmentReportApplication.GetDetails(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditUserImpairmentReport(EditUserImpairmentReport command, List<long> serviceIds)
        {
            command.SelectedSystemServiceIds = serviceIds;
            var result = _userImpairmentReportApplication.Edit(command);
            return Redirect("/Home/Index");
        }
        #endregion

        #region To show and add filtered products Based On User Device Categories
        public IActionResult AddProduct(long id)
        {
            ViewData["UserImpairmentReportId"]=id;
            var userImpairmentReport = _userImpairmentReportApplication.GetDetails(id);
            var userDevice = _userDeviceApplication.GetInfoById(userImpairmentReport.UserDeviceId);
            var product = _productApplication.GetDetails(userDevice.ProductId);
            var model = _productApplication.GetFilteredByCategories(product.ProductBrandId, product.ProductModelId, product.ProductTypeId, product.ProductUsageTypeId);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddProduct(long userImpairmentReportId, List<long> productIds)
        {
            var command=new AddProductToImpairmentReport() { ImpairmentReportId=userImpairmentReportId, ProductIds=productIds};
            var result = _userImpairmentReportApplication.AddProduct(command);
            return Redirect("/Home/Index");
        }
        #endregion

        #region Choosing A Repairman For An Specific Report
        public IActionResult ChooseRepairman(long id)
        {
            //id==UserImpairmentReportId
            ViewData["UserImpairmentReportId"] = id;
            var list =_repairManPanelApplication.GetListBasedOnImpairmentReport(id);
            return PartialView(list);
        }

        [HttpPost]
        public IActionResult ChooseRepairman(long repairmanPanelId, long userImpairmentReportId)
        {
            var result=_userImpairmentReportApplication.ChooseRepairMan(repairmanPanelId, userImpairmentReportId);
            return Redirect("/ImpairmentReport/CurrentImpairmentReport");

        }
        #endregion

    }
}

