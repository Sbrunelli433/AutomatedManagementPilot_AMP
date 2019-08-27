using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AutomatedManagementPilot_AMP.ViewModels;

namespace AutomatedManagementPilot_AMP.Controllers
{
    public class TimeClocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeClocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeClocks
        [Authorize(Roles = "Supervisor, Manager, Employee")]
        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeClock.Include(t => t.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TimeClocks
        [Authorize(Roles = "Supervisor, Manager")]
        public async System.Threading.Tasks.Task<IActionResult> ReportIndex()
        {

            var applicationDbContext = _context.TimeClock.Include(t => t.Employee)
                .Include(s => s.ShopOrder)
                .Include(m => m.Machine);
                //.Include(p => p.ShopOrder.Profitability);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TimeClocks/Details/5
        [Authorize(Roles = "Supervisor, Manager")]
        public async System.Threading.Tasks.Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClock
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TimeClockId == id);
            if (timeClock == null)
            {
                return NotFound();
            }

            return View(timeClock);
        }

        // GET: TimeClocks/Create
        [Authorize(Roles = "Supervisor")]
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: TimeClocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Create([Bind("TimeClockId,ClockIn,ClockOut,HoursWorked,EmployeeId")] TimeClock timeClock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeClock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", timeClock.EmployeeId);
            return View(timeClock);
        }

        // GET: TimeClocks/Create
        [Authorize(Roles = "Employee")]
        public IActionResult ClockIn()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: TimeClocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> ClockIn(TimeClock timeClock)
        {
            if (ModelState.IsValid)
            {
                timeClock = new TimeClock();
                string empId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Employee loggedInEmployee = _context.Employee.Where(i => i.ApplicationId == empId).SingleOrDefault();
                timeClock.EmployeeId = loggedInEmployee.EmployeeId;
                timeClock.ClockIn = DateTime.Now;
                if (timeClock.ClockOut == null)
                {
                    throw new System.ArgumentException("You need to clock out first!");
                    //return RedirectToAction("ClockIn", "TimeClocks");
                }
                else
                {
                    _context.Add(timeClock);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("ClockIn", "TimeClocks");
                }
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", timeClock.EmployeeId);
            return View(timeClock);
        }

        //// GET: TimeClocks/Edit/5
        //[Authorize(Roles = "Employee")]
        //public async System.Threading.Tasks.Task<IActionResult> ClockOut(int? id, TimeClockViewModel timeClockViewModel)
        //{
        //    TimeClockViewModel ddl = new TimeClockViewModel();
        //    var queryData = new SelectList(_context.Machine.Select(c => new
        //    {
        //        Machine = c.MachineId,
        //    }), "MachineId"
        //    ).ToList();
        //    ddl.MachineList = queryData;

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var timeClock = await _context.TimeClock.FindAsync(id);
        //    if (timeClock == null)
        //    {
        //        return NotFound();
        //    }
        //    //ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", timeClock.EmployeeId);
        //    return View(timeClock);
        //}

        // GET: TimeClocks/Edit/5
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> ClockOut(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClock.FindAsync(id);
            if (timeClock == null)
            {
                return NotFound();
            }
            //ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", timeClock.EmployeeId);
            return View(timeClock);
        }

        // POST: TimeClocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> ClockOut(int id, [Bind("TimeClockId,ClockIn,ClockOut,HoursWorked,EmployeeId,MachineId,ShopOrderNumber,Task,Summary,Id,TaskId")] TimeClock timeClock)
        {

            if (id != timeClock.TimeClockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    timeClock.ClockOut = DateTime.Now;
                    timeClock.HoursWorked = timeClock.ClockOut.Subtract(timeClock.ClockIn);
                    timeClock.Summary = timeClock.Summary;
                    timeClock.Task = timeClock.Task;
                    timeClock.Id = timeClock.Id;
                    timeClock.MachineId = timeClock.MachineId;
                    timeClock.ShopOrderNumber = timeClock.ShopOrderNumber;

                    //ViewData["ShopOrderNumber"] = new SelectList(_context.ShopOrder, "ShopOrderNumber", "ShopOrderNumber");


                    _context.Update(timeClock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeClockExists(timeClock.TimeClockId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "TimeClocks");
            }
            //ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", timeClock.EmployeeId);
            return View(timeClock);
        }





        // GET: TimeClocks/Edit/5
        [Authorize(Roles = " Supervisor, Manager")]

        public async System.Threading.Tasks.Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClock.FindAsync(id);
            if (timeClock == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", timeClock.EmployeeId);
            return View(timeClock);
        }

        // POST: TimeClocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = " Supervisor, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Edit(int id, [Bind("TimeClockId,ClockIn,ClockOut,HoursWorked,EmployeeId,Summary,ShopOrderNumber,MachineId,Id")] TimeClock timeClock)
        {
            if (id != timeClock.TimeClockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeClock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeClockExists(timeClock.TimeClockId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", timeClock.EmployeeId);
            return View(timeClock);
        }

        // GET: TimeClocks/Delete/5
        [Authorize(Roles = " Supervisor, Manager")]
        public async System.Threading.Tasks.Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClock
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TimeClockId == id);
            if (timeClock == null)
            {
                return NotFound();
            }

            return View(timeClock);
        }

        // POST: TimeClocks/Delete/5
        [Authorize(Roles = " Supervisor, Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeClock = await _context.TimeClock.FindAsync(id);
            _context.TimeClock.Remove(timeClock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeClockExists(int id)
        {
            return _context.TimeClock.Any(e => e.TimeClockId == id);
        }
    }
}
