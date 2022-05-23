using AccountManagement.Application.Contract.PersonalWalletOperation;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class PersonalWalletWithdrawRequestController : Controller
    {
        private readonly IPersonalWalletOperationApplication _personalWalletOperationApplication;

        public PersonalWalletWithdrawRequestController(IPersonalWalletOperationApplication personalWalletOperationApplication)
        {
            _personalWalletOperationApplication = personalWalletOperationApplication;
        }

        public IActionResult Index()
        {
            var withdrawRequests=_personalWalletOperationApplication.GetWithdrawRequests();
            return View(withdrawRequests);
        }

        public IActionResult SetWithdrawRequestStatus(long id)
        {
            ViewData["PersonalWalletOperationId"] = id;
            return PartialView();
        }
        
        [HttpPost]
        public IActionResult SetWithdrawRequestStatus(SetPersonalWalletOperationWithdrawRequestStatus command)
        {
            _personalWalletOperationApplication.SetWithdrawRequestStatus(command);
            return Redirect("./index");
        }

        public IActionResult AllWalletOperations(long id)
        {
            var operations = _personalWalletOperationApplication.GetAllOperationsByWalletId(id);
            return PartialView(operations);
        }
    }
}
