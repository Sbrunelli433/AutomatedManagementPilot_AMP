using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutomatedManagementPilot_AMP.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DataController : Controller
    {

        private readonly ApplicationDbContext _context;
        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/data
        [HttpGet]
        public object Get()
        {
            return new
            {
                data = _context.Jobs.ToList().Select(t => (WebApiJob)t),
                links = _context.Links.ToList().Select(l => (WebApiLink)l)
            };

        }
    }
}
