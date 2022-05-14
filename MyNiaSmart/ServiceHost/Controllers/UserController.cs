using _0_Framework.Contract;
using _0_MyNiaSmartQuery.Contract.User;
using AccountManagement.Application.Contract.RejectionReason;
using AccountManagement.Application.Contract.UpAccountRequest;
using AccountManagement.Application.Contract.UpAccountRequestRejectionReason;
using AccountManagement.Application.Contract.User;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ServiceHost.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserQuery _userQuery;
        private readonly IAuthHelper _authHelper;
        private readonly IUserApplication _userApplication;
        private readonly IUPAccountRequestApplication _upAccountRequestApplication;
        private readonly IRejectionReasonApplication _rejectionReasonApplication;
        private readonly IUpAccountRequestRejectionReasonApplication _upAccountRequestRejectionReasonApplication;

        public UserController(IUserQuery userQuery, IAuthHelper authHelper, IUserApplication userApplication,
            IUPAccountRequestApplication upAccountRequestApplication, IRejectionReasonApplication rejectionReasonApplication,
            IUpAccountRequestRejectionReasonApplication upAccountRequestRejectionReasonApplication)
        {
            _userQuery = userQuery;
            _authHelper = authHelper;
            _userApplication = userApplication;
            _upAccountRequestApplication = upAccountRequestApplication;
            _rejectionReasonApplication = rejectionReasonApplication;
            _upAccountRequestRejectionReasonApplication = upAccountRequestRejectionReasonApplication;
        }


        #region for users To Edit profile details in their profile
        public IActionResult UserProfile()
        {
            long userId = _authHelper.CurrentAccountInfo().Id;
            var userInfo = _userQuery.GetUserInfo(userId);
            var EditUser = _userApplication.GetDetails(userId);
            var model = new Tuple<UserInfoQueryModel, EditUser>(userInfo, EditUser);
            return View(model);
        }

        public IActionResult _UserProfileEdit()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _UserProfileEdit(EditUser command)
        {
            var result = _userApplication.Edit(command);
            if (!result.IsSuccedded)
            {
                ViewData["message"] = result.Message;
            }
            return Redirect("./userProfile");
        }
        #endregion

        #region CreateUpAccountRequest

        public IActionResult UpgradeAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpgradeAccount(CreateUpAccountRequest command)
        {
            var result = _upAccountRequestApplication.Create(command);
            if (!result.IsSuccedded)
            {
                ViewData["UpRequestResult"] = result.Message;
                return View(command);
            }
            ViewData["UpRequestResult"] = result.Message;
            return Redirect("/user/userProfile");
        }
        #endregion

        #region EditUpAccountRequest

        public IActionResult EditUpgradeAccount(long id)
        {
            //to find if request is rejected by admin with reasons
           bool IsRequestRejected= _upAccountRequestRejectionReasonApplication.HasRequestRejectedByReason(id);
            if(IsRequestRejected)
            ViewData["IsRequestRejected"] = IsRequestRejected;

            var upAccountRequest = _upAccountRequestApplication.GetDetails(id);
            return View(upAccountRequest);
        }

        [HttpPost]
        public IActionResult EditUpgradeAccount(EditUpAccountRequest command)
        {
            _upAccountRequestApplication.Edit(command);
            return Redirect("/");
        }
        #endregion

        #region To SHow client the reasons that admin rejected their up account request
        public IActionResult ShowRejectionReason(long id)
        {
            var reasons=_rejectionReasonApplication.GetReasonsOfSpecificUpAccountRequest(id);
            return PartialView(reasons);
        }
        #endregion

        #region Personal wallets
        public IActionResult Wallet()
        {
            return View();
        }
        #endregion


    }
}
