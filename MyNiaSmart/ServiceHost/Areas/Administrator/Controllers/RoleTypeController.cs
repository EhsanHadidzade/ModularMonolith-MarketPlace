using AccountManagement.Application.Contract.RoleType;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RoleTypeController : Controller
    {
        private readonly IRoleTypeApplication _roleTypeApplication;

        public RoleTypeController(IRoleTypeApplication roleTypeApplication)
        {
            _roleTypeApplication = roleTypeApplication;
        }

        public IActionResult Index()
        {
            var roleTypes = _roleTypeApplication.GetList();
            return View(roleTypes);
        }

        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(CreateRoleType command)
        {
            var result = _roleTypeApplication.Create(command);
            return Redirect("./index");

        }
        public IActionResult Edit(long id)
        {
            var RoleType = _roleTypeApplication.getDetails(id);
            return PartialView(RoleType);
        }

        [HttpPost]
        public IActionResult Edit(EditRoleType editRoleType)
        {
            var result = _roleTypeApplication.Edit(editRoleType);
            return Redirect("./index");
        }


    }
}
