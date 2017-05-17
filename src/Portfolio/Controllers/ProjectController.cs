using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        // GET: /<controller>/
        //public IActionResult Projects()
        //{
        //    return View();
        //}

        //Method to display list of all projects
        public IActionResult GetProjects()
        {
            List<GitProject> projectList = GitProject.GetProjects();
            return View(projectList);
        }
    }
}
