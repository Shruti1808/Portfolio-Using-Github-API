using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult Projects()
        {
            List<GitProject> projectList = GitProject.GetProjects();
            return View(projectList);
        }
    }
}
