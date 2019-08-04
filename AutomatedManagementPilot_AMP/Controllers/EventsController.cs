using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedManagementPilot_AMP.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace TutorialAspnetCoreSchedulerLarge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }



        // ...

        // GET: api/Events
        [HttpGet]
        public IEnumerable GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string resources)
        {
            if (resources == null)
            {
                return Enumerable.Empty<object>();
            }
            var resArray = resources.Split(',').Select(Int32.Parse).ToList();
            return from e in _context.ShopOrder
                   where !((e.ScheduleEndTime <= start) || (e.ScheduleStartTime >= end)) && resArray.Contains(e.ShopOrderNumber)
                   select new
                   {
                       e.ScheduleStartTime,
                       e.ScheduleEndTime,
                       e.ShopOrderNumber,
                       
                       Resource = e.ShopOrderNumber
                   };
        }

    }
}