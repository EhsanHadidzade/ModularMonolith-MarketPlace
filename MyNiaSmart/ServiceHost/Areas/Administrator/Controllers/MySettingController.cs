using AccountManagement.Application.Contract.Personality;
using AccountManagement.Application.Contract.RejectionReason;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.RoleType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class MySettingController : Controller
    {
        private readonly IRoleTypeApplication _roleTypeApplication;
        private readonly IRoleApplication _roleApplication;
        private readonly IPersonalityApplication _personalityApplication;
        private readonly IRejectionReasonApplication _rejectionReasonApplication;


        public MySettingController(IRoleTypeApplication roleTypeApplication, IRejectionReasonApplication rejectionReasonApplication,
            IPersonalityApplication personalityApplication, IRoleApplication roleApplication)
        {
            _roleTypeApplication = roleTypeApplication;
            _rejectionReasonApplication = rejectionReasonApplication;
            _personalityApplication = personalityApplication;
            _roleApplication = roleApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region RoleTypes management
      
        public IActionResult _RoleTypeCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _RoleTypeCreate(CreateRoleType command)
        {
            var result = _roleTypeApplication.Create(command);
            return Redirect("./index");

        }
        public IActionResult _RoleTypeEdit(long id)
        {
            var RoleType = _roleTypeApplication.getDetails(id);
            return PartialView(RoleType);
        }

        [HttpPost]
        public IActionResult _RoleTypeEdit(EditRoleType command)
        {
            var result = _roleTypeApplication.Edit(command);
            return Redirect("./index");
        }
        #endregion

        #region Roles management
        public IActionResult _RoleCreate()
        {
            ViewData["RoleTypes"] = new SelectList(_roleTypeApplication.GetList(), "Id", "RoleTypeName");
            return PartialView();
        }

        [HttpPost]
        public IActionResult _RoleCreate(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return Redirect("./index");
        }

        public IActionResult _RoleEdit(long id)
        {
            ViewData["RoleTypes"] = new SelectList(_roleTypeApplication.GetList(), "Id", "RoleTypeName");
            var Role = _roleApplication.getDetails(id);
            return PartialView(Role);
        }

        [HttpPost]
        public IActionResult _RoleEdit(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return Redirect("./index");

        }
        #endregion

        #region Personalities management
        public IActionResult _PersonalityCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _PersonalityCreate(CreatePersonality command)
        {
            var result = _personalityApplication.Create(command);
            return Redirect("./index");
        }
        public IActionResult _PersonalityEdit(long id)
        {
            var personality = _personalityApplication.GetDetails(id);
            return PartialView(personality);
        }

        [HttpPost]
        public IActionResult _PersonalityEdit(EditPersonality command)
        {
            var result = _personalityApplication.Edit(command);
            return Redirect("./index");
        }
        #endregion

        #region RejectionReasonManagement
        public IActionResult _RejectionReasonCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _RejectionReasonCreate(CreateRejectionReason command)
        {
            var result = _rejectionReasonApplication.Create(command);
            return Redirect("./index");
        }

        public IActionResult _RejectionReasonEdit(long id)
        {
            var reason = _rejectionReasonApplication.GetDetails(id);
            return PartialView(reason);
        }

        [HttpPost]
        public IActionResult _RejectionReasonEdit(EditRejectionReason command)
        {
            var result = _rejectionReasonApplication.Edit(command);
            return Redirect("./index");
        }
        #endregion
    }
}
