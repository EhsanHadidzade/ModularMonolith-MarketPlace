using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Application.Contract.User;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Dynamic;


namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {

        private readonly IUserApplication _userApplication;
        private readonly IRoleTypeApplication _roleTypeApplication;
        
        public UserController(IUserApplication userApplication, IRoleTypeApplication roleTypeApplication)
        {
            _userApplication = userApplication;
            _roleTypeApplication = roleTypeApplication;
        }

        public IActionResult Index()
        {
            var users=_userApplication.GetList();
            return View(users);
        }
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(CreateUser command)
        {
            var result=_userApplication.Create(command);
            return Redirect("./index");
        }
        public IActionResult Edit(long id)
        {
            var user = _userApplication.GetDetails(id);
            return PartialView(user);
        }

        [HttpPost]
        public IActionResult Edit(EditUser command)
        {
            var result = _userApplication.Edit(command);
            return Redirect("./index");
        }

        public IActionResult EditUserRole(long id)
        {
            var RoleTypes = _roleTypeApplication.GetList();
            var tupleModel=new Tuple<ro>()

            return PartialView(Model);
        }

        [HttpPost]
        public IActionResult EditUserRole()
        {

            return Redirect("./index");
        }
        

        

    }
}
