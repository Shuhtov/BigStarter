using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigStarter.Domain.Contracts.Services;
using BigStarter.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigStarter.Presentation.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            _projectService.CreateProject(project);
            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            return View(_projectService.GetAll());
        }
    }
}