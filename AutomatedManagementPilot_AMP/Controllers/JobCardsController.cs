﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AutomatedManagementPilot_AMP.ViewModels;

namespace AutomatedManagementPilot_AMP.Controllers
{
    public class JobCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobCards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobCard.Include(j => j.Employee).Include(j => j.ShopOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCard = await _context.JobCard
                .Include(j => j.Employee)
                .Include(j => j.ShopOrder)
                .FirstOrDefaultAsync(m => m.JobCardId == id);
            if (jobCard == null)
            {
                return NotFound();
            }

            return View(jobCard);
        }

        // GET: JobCards/Create
        public IActionResult CreateJobCard()
        {

            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            ViewData["ShopOrderNumber"] = new SelectList(_context.ShopOrder, "ShopOrderNumber", "ShopOrderNumber");
            ViewData["Operation"] = new SelectList(_context.ShopOrder, "OperationSetUp", "OperationProduction", "OperationTearDown");

            return View();
        }

        // POST: JobCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJobCard( JobCard jobCard, JobCardViewModel jobCardViewModel)
        {
            if (ModelState.IsValid)
            {
                jobCard = new JobCard();
                string empId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Employee loggedInEmployee = _context.Employee.Where(i => i.ApplicationId == empId).SingleOrDefault();
                jobCard.EmployeeId = loggedInEmployee.EmployeeId;
                jobCard.OperationClockIn = DateTime.Now;
                
                if (jobCard.OperationClockOut == null)
                {
                    throw new System.ArgumentException("You need to clock out of the current operation first!");
                    //return RedirectToAction("ClockIn", "TimeClocks");
                }
                else
                {
                    _context.Add(jobCard);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Machines");
                }

            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", jobCard.EmployeeId);
            ViewData["ShopOrderNumber"] = new SelectList(_context.ShopOrder, "ShopOrderNumber", "ShopOrderNumber", jobCard.ShopOrderNumber);
            return View(jobCard);
        }

        public async Task<IActionResult> ClockIn(TimeClock timeClock)
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
                    return RedirectToAction("ClockIn", "TimeClocks");
                }
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", timeClock.EmployeeId);
            return View(timeClock);
        }


        //// GET: JobCards/Create
        //public IActionResult Create()
        //{

        //    ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
        //    ViewData["ShopOrderNumber"] = new SelectList(_context.ShopOrder, "ShopOrderNumber", "ShopOrderNumber");
        //    return View();
        //}

        //// POST: JobCards/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("JobCardId,OperationClockIn,OperationClockOut,OperationTotal,PartsMade,Summary,EmployeeId,ShopOrderNumber")] JobCard jobCard)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(jobCard);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", jobCard.EmployeeId);
        //    ViewData["ShopOrderNumber"] = new SelectList(_context.ShopOrder, "ShopOrderNumber", "ShopOrderNumber", jobCard.ShopOrderNumber);
        //    return View(jobCard);
        //}

        // GET: JobCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCard = await _context.JobCard.FindAsync(id);
            if (jobCard == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", jobCard.EmployeeId);
            ViewData["ShopOrderNumber"] = new SelectList(_context.ShopOrder, "ShopOrderNumber", "ShopOrderNumber", jobCard.ShopOrderNumber);
            return View(jobCard);
        }

        // POST: JobCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobCardId,OperationClockIn,OperationClockOut,OperationTotal,PartsMade,Summary,EmployeeId,ShopOrderNumber")] JobCard jobCard)
        {
            if (id != jobCard.JobCardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobCardExists(jobCard.JobCardId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", jobCard.EmployeeId);
            ViewData["ShopOrderNumber"] = new SelectList(_context.ShopOrder, "ShopOrderNumber", "ShopOrderNumber", jobCard.ShopOrderNumber);
            return View(jobCard);
        }

        // GET: JobCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCard = await _context.JobCard
                .Include(j => j.Employee)
                .Include(j => j.ShopOrder)
                .FirstOrDefaultAsync(m => m.JobCardId == id);
            if (jobCard == null)
            {
                return NotFound();
            }

            return View(jobCard);
        }

        // POST: JobCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobCard = await _context.JobCard.FindAsync(id);
            _context.JobCard.Remove(jobCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobCardExists(int id)
        {
            return _context.JobCard.Any(e => e.JobCardId == id);
        }
    }
}
