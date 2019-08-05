using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Authorization;

namespace AutomatedManagementPilot_AMP.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Supervisor,Manager,Employee")]

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
