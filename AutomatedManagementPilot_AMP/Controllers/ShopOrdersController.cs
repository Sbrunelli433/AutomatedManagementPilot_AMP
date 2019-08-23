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

namespace AutomatedManagementPilot_AMP.Controllers
{
    public class ShopOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: ShopOrders
        [Authorize(Roles = "Supervisor, Manager, Employee")]
        public async System.Threading.Tasks.Task<IActionResult> Index(string sortOrder, string searchString, int searchInt)
        {
            ViewData["ShopNumberParm"] = String.IsNullOrEmpty(sortOrder) ? "shopNum_desc" : "";
            ViewData["CustSortParm"] = String.IsNullOrEmpty(sortOrder) ? "cust_desc" : "";
            ViewData["PartNumberParm"] = String.IsNullOrEmpty(sortOrder) ? "partNum_desc" : "";
            ViewData["PartNameParm"] = String.IsNullOrEmpty(sortOrder) ? "partName_desc" : "";
            ViewData["OrderRecDateSortParm"] = sortOrder == "Date" ? "OrderRecDate_desc" : "Date";
            ViewData["OrderDueDateSortParm"] = sortOrder == "Date" ? "OrderDueDate_desc" : "Date";
            ViewData["MachineSortParm"] = String.IsNullOrEmpty(sortOrder) ?  "machine_desc" : "";
            ViewData["CurrentFilter"] = searchString;



            var shopOrders = from s in _context.ShopOrder
                             select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    shopOrders = shopOrders.Where(s => s.ShopOrderNumber.Contains(searchInt)
            //                                || s.Customer.Contains(searchString)
            //                                || s.PartNumber.Contains(searchString)
            //                                || s.PartName.Contains(searchString)
            //                                || s.OrderRecDate.Contains(searchString)
            //                                || s.OrderDueDate.Contains(searchString)
            //                                || s.MachineId.Contains(searchString));
            //}
            if (!String.IsNullOrEmpty(searchString))
            {
                shopOrders = shopOrders.Where(s => s.Customer.Contains(searchString)
                                            || s.PartName.Contains(searchString));

            }


            switch (sortOrder)
            {
                case "cust_desc":
                    shopOrders = shopOrders.OrderByDescending(s => s.ShopOrderNumber);
                    break;
                case "partNum_desc":
                    shopOrders = shopOrders.OrderByDescending(s => s.PartNumber);
                    break;
                case "OrderRecDate_desc":
                    shopOrders = shopOrders.OrderByDescending(s => s.OrderRecDate);
                    break;
                case "OrderDueDate_desc":
                    shopOrders = shopOrders.OrderByDescending(s => s.OrderDueDate);
                    break;
                case "machine_desc":
                    shopOrders = shopOrders.OrderByDescending(s => s.MachineId);
                    break;
                default:
                    shopOrders = shopOrders.OrderBy(s => s.ShopOrderNumber);
                    break;

            }
            return View(await shopOrders.AsNoTracking().ToListAsync());
        }


        //// GET: ShopOrders
        //[Authorize(Roles = "Supervisor, Manager, Employee")]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.ShopOrder.ToListAsync());
        //}

        // GET: ShopOrders/Details/5
        [Authorize(Roles = "Supervisor, Manager, Employee")]
        public async System.Threading.Tasks.Task<IActionResult> Details(int? id)
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
        [Authorize(Roles = "Supervisor ")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Create([Bind("ShopOrderNumber,Customer,PartNumber,PartName,OrderQuantity,RawMatlInventoryId,OrderRecDate,OrderDueDate,MachineId,ScheduleStartTime,ScheduleEndTime,OperationSetUpHours,OperationProductionHours,OperationTearDownHours,GrossProductionRate,NetProductionRate,Profitability")] ShopOrder shopOrder)
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
        [Authorize(Roles = "Supervisor")]

        public async System.Threading.Tasks.Task<IActionResult> Edit(int? id)
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
        [Authorize(Roles = "Supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Edit(int id, ShopOrder shopOrder)
        {
            if (id != shopOrder.ShopOrderNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    shopOrder.Customer = shopOrder.Customer;
                    shopOrder.PartName = shopOrder.PartName;
                    shopOrder.OrderQuantity = shopOrder.OrderQuantity;
                    shopOrder.MachineId = shopOrder.MachineId;


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
        [Authorize(Roles = "Supervisor")]

        public async System.Threading.Tasks.Task<IActionResult> Delete(int? id)
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
        [Authorize(Roles = "Supervisor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> DeleteConfirmed(int id)
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
