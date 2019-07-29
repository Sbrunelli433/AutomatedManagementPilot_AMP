using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomatedManagementPilot_AMP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        //public List<AllUsers> allUsers = new List<AllUsers>();


        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }


        // GET: Account
        public async Task <ActionResult> Index()
        {
            var adminRole = await _roleManager.FindByNameAsync(roleName: "Admin");
            var assignableRoles = _roleManager.Roles.ToList();
            assignableRoles.RemoveAt(assignableRoles.IndexOf(adminRole));

            return View(assignableRoles);
            //var applicationDbContext = _context.ApplicationUser.Include(u => u.Id).Include(u => u.Name).Include(u => u.UserName);
            //return View(await applicationDbContext.ToListAsync());
            //var assignableRoles = _roleManager.Roles.ToList();
            //assignableRoles.RemoveAt(assignableRoles.IndexOf(RoleModel.));

            //return View();
        }

        //get:Role/Assign
        public async Task<ActionResult> Assign()
        {
            var adminRole = await _roleManager.FindByNameAsync(roleName: "Admin");
            var assignableRoles = _roleManager.Roles.ToList();
            assignableRoles.RemoveAt(assignableRoles.IndexOf(adminRole));
            //ViewData["Name"] = new SelectList(assignableRoles, "Name", "Name");
            //ViewData["UserName"] = new SelectList(_userManager.Users, "UserName", "UserName");


            return View(new RoleModel());
        }

        //POST: ROLE/ASSIGN
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Assign (RoleModel roleModel)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        ViewData["Message"] = "invalid request.";
        //        return View();
        //    }
        //    var user = await _userManager.FindByEmailAsync(roleModel.UserName);
        //    if (user != null)
        //    {
        //        if (roleModel.Name == )
        //        {

        //        }

        //    }
        //    return View();
        //}

        //////GET: Account/Details/5
        //public async Task<ActionResult> Details(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();

        //    }
        //    var account = await _context.AllUsers.FirstOrDefaultAsync(a => a.Id == id);

        //    //account.Supervisor = _context.Supervisor.Where(a => a.SupervisorId == account.Id).ToList();
        //    //account.Manager = _context.Manager.Where(a => a.ManagerId == account.Id).ToList();
        //    //account.Employee 
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return View();
        //}

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    List<RoleModel> li = new List<RoleModel>();
        //    li = _context.UserRoles.T
        //    ViewBag.listofitems = li;


        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}