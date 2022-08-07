using Microsoft.AspNetCore.Mvc;
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;

namespace ServiceHost.Controllers
{
    public class ImpairmentReportController : Controller
    {
        private readonly IUserImpairmentReportApplication _userImpairmentReportApplication;

        public ImpairmentReportController(IUserImpairmentReportApplication userImpairmentReportApplication)
        {
            _userImpairmentReportApplication = userImpairmentReportApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportNewImpairment()
        {
            return View();
        }

        //To Show List Of UserDevices To Select Between Them for reporting new Impairment
        public IActionResult ShowUserDevice()
        {
            return PartialView();
        }
    }
}
