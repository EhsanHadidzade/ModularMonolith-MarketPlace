using AccountManagement.Application.Contract.PersonalityType;
using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Application.Contract.UserCooperationRequest;
using AccountManagement.Application.Contract.UserPersonality;
using AccountManagement.Application.Contract.UserRole;
using AccountManagement.Domain.PersonalityTypeAgg;
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
        private readonly IPersonalityTypeApplication _personalityTypeApplication;
        private readonly IUserPersonalityApplication _userPersonalityApplication;

        public UserCooperationRequestController(IUserCooperationRequestApplication userCooperationRequestApplication,
            IRoleTypeApplication roleTypeApplication, IUserRoleApplication userRoleApplication,
            IPersonalityTypeApplication personalityTypeApplication, IUserPersonalityApplication userPersonalityApplication)
        {
            _userCooperationRequestApplication = userCooperationRequestApplication;
            _roleTypeApplication = roleTypeApplication;
            _userRoleApplication = userRoleApplication;
            _personalityTypeApplication = personalityTypeApplication;
            _userPersonalityApplication = userPersonalityApplication;
        }

        public IActionResult Index()
        {
            var usersWithRequests = _userCooperationRequestApplication.GetUsersWithCooperationRequest();
            return View(usersWithRequests);
        }

        public IActionResult ShowAndSetRequestedPersonalities(long id)
        {
            //id is the userId from tables to return his requested RoleIds
            var RequestedRoleIds = _userCooperationRequestApplication.GetAllRequestedRoleIdsByUserId(id);
            var personalityTypesWithPersonalities = _personalityTypeApplication.GetList();
            var model = new Tuple<List<PersonalityTypeViewModel>, List<long>, long>(personalityTypesWithPersonalities, RequestedRoleIds, id);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult SetPersonalitiesForUser(long userId, List<int> ConfirmedPersonalityIds)
        {
            var command = new CreateUserPersonality
            {
                UserId = userId,
                SelectedPersonalityIds = ConfirmedPersonalityIds
            };
            _userPersonalityApplication.CreateUserPersonalities(command);
            return Redirect("./index");


        }
    }
}
