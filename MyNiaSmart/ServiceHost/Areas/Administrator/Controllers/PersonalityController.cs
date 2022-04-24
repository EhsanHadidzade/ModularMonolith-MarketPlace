using AccountManagement.Application.Contract.Personality;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class PersonalityController : Controller
    {
        private readonly IPersonalityApplication _personalityApplication;

        public PersonalityController(IPersonalityApplication personalityApplication)
        {
            _personalityApplication = personalityApplication;
        }

        public IActionResult Index()
        {
            var personalities=_personalityApplication.Getlist();
            return View(personalities);
        }
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonality command)
        {
            var result = _personalityApplication.Create(command);
            return Redirect("./index");
        }
        public IActionResult Edit(long id)
        {
            var personality = _personalityApplication.GetDetails(id);
            return PartialView(personality);
        }

        [HttpPost]
        public IActionResult Edit(EditPersonality command)
        {
            var result = _personalityApplication.Edit(command);
            return Redirect("./index");
        }
    }
}
