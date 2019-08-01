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
using AutomatedManagementPilot_AMP.ViewModels;

namespace AutomatedManagementPilot_AMP.Controllers
{
    public class TimeClockSummariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeClockSummariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeClockSummaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeClockSummary.ToListAsync());
        }

        // GET: TimeClockSummaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClockSummary = await _context.TimeClockSummary
                .FirstOrDefaultAsync(m => m.TimeClockSumId == id);
            if (timeClockSummary == null)
            {
                return NotFound();
            }

            return View(timeClockSummary);
        }

        // GET: TimeClockSummaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeClockSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimeClockViewModel timeClockViewModel, int? timeClock)
        {
            if (timeClock == null)
            {
                return NotFound();
            }
            
            var timeClockSum = await _context.TimeClockSummary.FindAsync(timeClock);
            if (ModelState.IsValid)
            {
                TimeClockSummary newTCS = new TimeClockSummary();
                newTCS.TimeClockId = timeClockSum.TimeClockSumId;

                _context.Add(newTCS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: TimeClockSummaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClockSummary = await _context.TimeClockSummary.FindAsync(id);
            if (timeClockSummary == null)
            {
                return NotFound();
            }
            return View(timeClockSummary);
        }

        // POST: TimeClockSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeClockSumId,TimeClockId,Summary")] TimeClockSummary timeClockSummary)
        {
            if (id != timeClockSummary.TimeClockSumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeClockSummary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeClockSummaryExists(timeClockSummary.TimeClockSumId))
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
            return View(timeClockSummary);
        }

        // GET: TimeClockSummaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClockSummary = await _context.TimeClockSummary
                .FirstOrDefaultAsync(m => m.TimeClockSumId == id);
            if (timeClockSummary == null)
            {
                return NotFound();
            }

            return View(timeClockSummary);
        }

        // POST: TimeClockSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeClockSummary = await _context.TimeClockSummary.FindAsync(id);
            _context.TimeClockSummary.Remove(timeClockSummary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeClockSummaryExists(int id)
        {
            return _context.TimeClockSummary.Any(e => e.TimeClockSumId == id);
        }
    }
}
