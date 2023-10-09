using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Persistence;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private PortfolioContext _context;

		private readonly IWebHostEnvironment _hostingEnvironment;
		public ProjectController(PortfolioContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if(project.ImageFile != null)
			{
				// Save the image to the directory
				string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + project.ImageFile.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await project.ImageFile.CopyToAsync(fileStream);
				}

				// Save the file name
				project.ImageName = uniqueFileName;
			}
            else
            {
                project.ImageName = "default.jpg";
            }

            _context.Projects.Add(project);
            _context.SaveChanges();
            TempData["msg"] = "Project created successfully";
            return RedirectToAction("Create");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            var list = _context.Projects.ToList();
            return View(list);
        }

        public IActionResult Edit(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Project project, int id)
        {

            var existingProject = _context.Projects.Find(id);

            if (existingProject == null)
            {
                return NotFound();
            }

            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.StartDate = project.StartDate;
            existingProject.EndDate = project.EndDate;
            existingProject.TechnologiesUsed = project.TechnologiesUsed;
            existingProject.ProjectUrl = project.ProjectUrl;
            existingProject.Category = project.Category;

            if (project.ImageFile != null)
            {
                // Delete the old image file if it exists
                if (!string.IsNullOrEmpty(existingProject.ImageName))
                {
                    var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, "Images", existingProject.ImageName);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Save the new image file and update the ImageName
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + project.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    project.ImageFile.CopyTo(fileStream);
                }
                existingProject.ImageName = uniqueFileName;
            }

            _context.SaveChanges();

            TempData["msg"] = "Project updated successfully!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
			var project = _context.Projects.Find(id);
			if (project == null)
			{
				return NotFound();
			}
            _context.Projects.Remove(project);
            _context.SaveChanges();
			TempData["msg"] = "Project deleted successfully!";
			return RedirectToAction("Index");
		}

        public IActionResult FindByTitle()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult FindByTitle(string stringTitle)

        {
            var projects = _context.Projects.Where(p => p.Title.Contains(stringTitle)).ToList();
            return View("Index", projects);
        }
    }
}
