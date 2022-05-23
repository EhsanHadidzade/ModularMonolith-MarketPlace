using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Application.Contract.UserCooperationRequest;
using AccountManagement.Application.Contract.UserRole;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserCooperationRequestController : Controller
    {
        private readonly IUserCooperationRequestApplication _userCooperationRequestApplication;
        private readonly IRoleTypeApplication _roleTypeApplication;
        private readonly IUserRoleApplication _userRoleApplication;

        public UserCooperationRequestController(IUserCooperationRequestApplication userCooperationRequestApplication,
            IRoleTypeApplication roleTypeApplication, IUserRoleApplication userRoleApplication)
        {
            _userCooperationRequestApplication = userCooperationRequestApplication;
            _roleTypeApplication = roleTypeApplication;
            _userRoleApplication = userRoleApplication;
        }

        public IActionResult Index()
        {
            var usersWithRequests = _userCooperationRequestApplication.GetUsersWithCooperationRequest();
            return View(usersWithRequests);
        }

        public IActionResult ShowAndSetRequestedRoles(long id)
        {
            //id is the userId from tables to return his requested RoleIds
            var RequestedRoleIds = _userCooperationRequestApplication.GetAllRequestedRoleIdsByUserId(id);
            var roleTypesWithRoles = _roleTypeApplication.GetList();
            var model = new Tuple<List<RoleTypeViewModel>, List<long>, long>(roleTypesWithRoles, RequestedRoleIds, id);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult SetRolesForUser(long userId, List<int> ConfirmedRoleIds)
        {
            var command = new CreateUserRole
            {
                UserId = userId,
                SelectedRoleIds = ConfirmedRoleIds
            };
            var result = _userRoleApplication.CreateUserRoles(command);
            return Redirect("./index");


        }
    }
}
