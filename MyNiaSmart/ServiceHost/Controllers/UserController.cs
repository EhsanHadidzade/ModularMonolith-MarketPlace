using _0_Framework.Utilities;
using _0_MyNiaSmartQuery.Contract.User;
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

        public UserController(IUserQuery userQuery, IAuthHelper authHelper, IUserApplication userApplication)
        {
            _userQuery = userQuery;
            _authHelper = authHelper;
            _userApplication = userApplication;
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
            var result=_userApplication.Edit(command);
            if(!result.IsSuccedded)
            {
                ViewData["message"] = result.Message;
            }
            return Redirect("./userProfile");
        }
        #endregion

        #region Upgrading personal account

        public IActionResult UpgradeAccount()
        {
            return View();
        }
        #endregion

    }
}
