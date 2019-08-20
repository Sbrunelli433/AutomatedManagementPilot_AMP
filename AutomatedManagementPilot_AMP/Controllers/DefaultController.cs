using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedManagementPilot_AMP.Controllers
{
    public partial class SidebarController : Controller
    {
        public IActionResult SidebarDock()
        {
            return View();
        }
    }
}