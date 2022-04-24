using AccountManagement.Application.Contract.Personality;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Application.Contract.User;
using AccountManagement.Application.Contract.UserPersonality;
using AccountManagement.Application.Contract.UserRole;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;


namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {

        private readonly IUserApplication _userApplication;
        private readonly IRoleTypeApplication _roleTypeApplication;
        private readonly IPersonalityApplication _personalityApplication;
        private readonly IUserRoleApplication _UserRoleApplication;
        private readonly IUserPersonalityApplication _userPersonalityApplication;

        public UserController(IUserApplication userApplication, IRoleTypeApplication roleTypeApplication,
            IUserRoleApplication UserRoleApplication, IPersonalityApplication personalityApplication,
            IUserPersonalityApplication userPersonalityApplication)
        {
            _userApplication = userApplication;
            _roleTypeApplication = roleTypeApplication;
            _UserRoleApplication = UserRoleApplication;
            _personalityApplication = personalityApplication;
            _userPersonalityApplication = userPersonalityApplication;
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
            var Model = _roleTypeApplication.GetAllRolesWithSelectedRolesOfOneUserByUserId(id);
            ViewData["userFullName"] = _userApplication.GetDetails(id).FullName;
            return PartialView(Model);
        }

        [HttpPost]
        public IActionResult EditUserRole(List<long> roleList,long userId)
        {
            var command = new EditUserRole() { UserId = userId, SelectedRoleIds = roleList };
            _UserRoleApplication.EditUserRole(command);
            return Redirect("./index");
        }
        public IActionResult EditUserPersonality(long id)
        {
            var model=_personalityApplication.GetAllPersonalitiesWithSelectedPersonalitiesOfUserByUserId(id);
            ViewData["userFullName"] = _userApplication.GetDetails(id).FullName;
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult EditUserPersonality(List<long> PersonalityList, long userId)
        {
            var command=new EditUserPersonality() { UserId=userId, SelectedPersonalityIds = PersonalityList };
            _userPersonalityApplication.EditUserPersonality(command);
            return Redirect("./index");
        }


    }
}
