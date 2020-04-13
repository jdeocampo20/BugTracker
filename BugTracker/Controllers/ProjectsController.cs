using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var projects = projectRepository.AllProjects;
            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await projectRepository.AddProjectAsync(project);
            await projectRepository.CommitAsync();
            return RedirectToAction("Index");
        }
    }
}
