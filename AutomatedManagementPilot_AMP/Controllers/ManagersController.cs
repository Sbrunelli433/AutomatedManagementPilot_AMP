using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Authorization;
using AutomatedManagementPilot_AMP.ViewModels;

namespace AutomatedManagementPilot_AMP.Controllers
{
    public class ManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Managers
        [Authorize(Roles = "Supervisor,Manager")]

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Manager.Include(m => m.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Managers
        [Authorize(Roles = "Supervisor,Manager")]

        public async Task<IActionResult> ReportIndex()
        {


            //IEnumerable<ShopOrder> shopOrdersWithTime = _context.ShopOrder.Where(s => (_context.TimeClock
            // .Where(n => n.TimeClockId == s.ShopOrderNumber).
            // Select(n => n.TimeClockId).Contains(s.ShopOrderNumber)) ||
            // (_context.TimeClock.Where(n => n.EmployeeId == s.ShopOrderNumber).Select(n => n.EmployeeId).Contains(s.ShopOrderNumber))).ToList();

            //IEnumerable<ShopOrder> shopOrders = await _context.ShopOrder.ToListAsync();

            //var viewModel = new ReportViewModel();
            //viewModel.shopOrdersWithTime = shopOrdersWithTime;
            //viewModel.ShopOrders = shopOrders;

            //return View(viewModel);




            //seed report data here to display the three shop orders and the production & profitability metrics.
            //This only needs to spit out a report, doesn't need to be interactive.

            var applicationDbContext = _context.TimeClock.Include(e => e.EmployeeId)
                .Include(t => t.TimeClockId)
                .Include(s => s.ShopOrderNumber)
                .Include(ta => ta.Task)
                .Include(m => m.MachineId);
                //.Include(s=>s.ShopOrderNumber).Where(s=> s.)
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Managers/Details/5
        [Authorize(Roles = "Supervisor,Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ManagerId == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        [Authorize(Roles = "Supervisor")]
        // GET: Managers/Create
        public IActionResult Create()
        {
            ViewData["UserName"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManagerId,UserName,PayRoll")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserName"] = new SelectList(_context.ApplicationUser, "Id", "Id", manager.UserName);
            return View(manager);
        }

        // GET: Managers/Edit/5
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }
            ViewData["UserName"] = new SelectList(_context.ApplicationUser, "Id", "Id", manager.UserName);
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManagerId,UserName,PayRoll")] Manager manager)
        {
            if (id != manager.ManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagerExists(manager.ManagerId))
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
            ViewData["UserName"] = new SelectList(_context.ApplicationUser, "Id", "Id", manager.UserName);
            return View(manager);
        }

        // GET: Managers/Delete/5
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ManagerId == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // POST: Managers/Delete/5
        [Authorize(Roles = "Supervisor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manager = await _context.Manager.FindAsync(id);
            _context.Manager.Remove(manager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagerExists(int id)
        {
            return _context.Manager.Any(e => e.ManagerId == id);
        }
    }
}
