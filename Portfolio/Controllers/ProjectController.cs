using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private static List<Project> _list = new List<Project>();
        private static int _cont = 0;

        public IActionResult Index()
        {
            return View(_list);
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            project.Id = ++_cont;
            _list.Add(project);
            TempData["msg"] = "Project created successfully";
            return RedirectToAction("Create");
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
