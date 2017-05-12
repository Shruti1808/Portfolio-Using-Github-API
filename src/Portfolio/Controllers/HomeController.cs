using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        //Create an About action
        public IActionResult About()
        {
            return View();
        }

        //Method to display list of all projects
        public IActionResult GetProjects()
        {
            List<GitProject>projectList = GitProject.GetProjects();
            return Json(projectList);
        }
    }
}
