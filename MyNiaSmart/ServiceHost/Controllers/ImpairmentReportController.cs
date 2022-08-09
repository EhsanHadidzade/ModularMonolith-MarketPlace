using _0_Framework.Contract;
using AccountManagement.Application.Contract.UserDevice;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;

namespace ServiceHost.Controllers
{
    public class ImpairmentReportController : Controller
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserDeviceApplication _userDeviceApplication;
        private readonly ISystemServiceApplication _systemServiceApplication;
        private readonly IUserImpairmentReportApplication _userImpairmentReportApplication;

        public ImpairmentReportController(IUserImpairmentReportApplication userImpairmentReportApplication,
            IUserDeviceApplication userDeviceApplication, IAuthHelper authHelper, ISystemServiceApplication systemServiceApplication)
        {
            _userImpairmentReportApplication = userImpairmentReportApplication;
            _userDeviceApplication = userDeviceApplication;
            _authHelper = authHelper;
            _systemServiceApplication = systemServiceApplication;
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

        //MODAL => To Show List of System service To let user select between them
        public IActionResult ShowSystemService()
        {
            var list = _systemServiceApplication.GetList();
            return PartialView(list);
        }

        // To Filter All SystemServices While RepairMan Is Adding New Services
        public IActionResult _FilteredSystemServices(long brandId, long modelId, long typeId, long usageTypeId)
        {
            var command = new FilterSystemServiceViewModel() { BrandId = brandId, ModelId = modelId, TypeId = typeId, usageTypeId = usageTypeId };
            var filteredServices = _systemServiceApplication.GetFilteredListByCategoryIds(command);
            return PartialView(filteredServices);
        }

        //AJAX => To Find Title Of SystemService While User Is selecting Between them in Impairment Report Form
        public string SelectSystemService(long id)
        {
            var systemService = _systemServiceApplication.GetInfoById(id);
            return JsonConvert.SerializeObject(systemService);
          
        }

        [HttpPost]
        public IActionResult ReportNewImpairment(CreateUserImpairmentReport command)
        {
            command.UserId = _authHelper.CurrentAccountInfo().Id;
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
    }
}

