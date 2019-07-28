using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;

namespace AutomatedManagementPilot_AMP.Controllers
{
    public class ShopOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShopOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopOrder.ToListAsync());
        }

        // GET: ShopOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopOrder = await _context.ShopOrder
                .FirstOrDefaultAsync(m => m.ShopOrderNumber == id);
            if (shopOrder == null)
            {
                return NotFound();
            }

            return View(shopOrder);
        }

        // GET: ShopOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopOrderNumber,Customer,PartNumber,PartName,OrderQuantity,RawMatlInventoryId,OrderRecDate,OrderDueDate,MachineId,ScheduleStartTime,ScheduleEndTime,OperationSetUpHours,OperationProductionHours,OperationEmpBreakHours,OperationMachineBreakHours,OperationTearDownHours,GrossProductionRate,NetProductionRate,Profitability")] ShopOrder shopOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopOrder);
        }

        // GET: ShopOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopOrder = await _context.ShopOrder.FindAsync(id);
            if (shopOrder == null)
            {
                return NotFound();
            }
            return View(shopOrder);
        }

        // POST: ShopOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopOrderNumber,Customer,PartNumber,PartName,OrderQuantity,RawMatlInventoryId,OrderRecDate,OrderDueDate,MachineId,ScheduleStartTime,ScheduleEndTime,OperationSetUpHours,OperationProductionHours,OperationEmpBreakHours,OperationMachineBreakHours,OperationTearDownHours,GrossProductionRate,NetProductionRate,Profitability")] ShopOrder shopOrder)
        {
            if (id != shopOrder.ShopOrderNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopOrderExists(shopOrder.ShopOrderNumber))
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
            return View(shopOrder);
        }

        // GET: ShopOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopOrder = await _context.ShopOrder
                .FirstOrDefaultAsync(m => m.ShopOrderNumber == id);
            if (shopOrder == null)
            {
                return NotFound();
            }

            return View(shopOrder);
        }

        // POST: ShopOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopOrder = await _context.ShopOrder.FindAsync(id);
            _context.ShopOrder.Remove(shopOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopOrderExists(int id)
        {
            return _context.ShopOrder.Any(e => e.ShopOrderNumber == id);
        }
    }
}
