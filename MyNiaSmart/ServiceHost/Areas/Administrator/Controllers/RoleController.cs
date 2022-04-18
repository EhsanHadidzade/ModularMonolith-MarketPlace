using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.RoleType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RoleController : Controller
    {

        private readonly IRoleApplication _roleApplication;
        private readonly IRoleTypeApplication _roleTypeApplication;

        public RoleController(IRoleApplication roleApplication, IRoleTypeApplication roleTypeApplication)
        {
            _roleApplication = roleApplication;
            _roleTypeApplication = roleTypeApplication;
        }

        public IActionResult Index()
        {
            var roles = _roleApplication.GetList();
            return View(roles);
        }

        public IActionResult Create()
        {
            ViewData["RoleTypes"] = new SelectList(_roleTypeApplication.GetList(), "Id", "RoleTypeName");
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return Redirect("./index");
        }

        public IActionResult Edit(long id)
        {
            ViewData["RoleTypes"] = new SelectList(_roleTypeApplication.GetList(), "Id", "RoleTypeName");
            var Role = _roleApplication.getDetails(id);
            return PartialView(Role);
        }

        [HttpPost]
        public IActionResult Edit(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return Redirect("./index");

        }
    }
}

