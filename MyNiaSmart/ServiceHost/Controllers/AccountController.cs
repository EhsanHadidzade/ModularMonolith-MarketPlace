using AccountManagement.Application.Contract.User;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApplication _userApplication;

        public AccountController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        #region RegisterOrLogin


        public IActionResult RegisterOrLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterOrLogin(RegisterOrLoginUser command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var result = _userApplication.RegisterOrLogin(command);
            if (!result.IsSuccedded)
            {
                ModelState.AddModelError("FullName", result.Message);
                ViewData["NewUser"] = true;
                return View(command);
            }

            return Redirect("/account/verifyCode");
        }
        #endregion


        #region VerificationCode

        public IActionResult VerifyCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifyCode(VerificationCode command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var result=_userApplication.CheckVerificationCode(command);
            if (!result.IsSuccedded)
            {
                ViewData["Message"] = result.Message;
                return View(command);
            }
                
            return Redirect("/");
        }
        #endregion


        #region LogOut

        public IActionResult LogOut()
        {
            _userApplication.LogOut();
            return Redirect("/account/RegisterOrLogin");
        }
        #endregion

    }
}
