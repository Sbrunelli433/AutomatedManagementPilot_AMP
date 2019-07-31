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
using AutomatedManagementPilot_AMP.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using AutomatedManagementPilot_AMP.Areas.Identity.Pages.Account;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace AutomatedManagementPilot_AMP.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class SupervisorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SupervisorsController(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
            
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        //[Authorize(Roles = "Supervisor")]
        public IActionResult Index()
        {


            var applicationDbContext = _context.Supervisor.Include(s => s.ApplicationUser);
            return View(applicationDbContext.ToList());
        }

        //[Authorize(Roles = "Supervisor")]
        //public IActionResult Index()
        //{
            //var applicationDbContext = _context.Supervisor.Include(s => s.ApplicationUser);
            //return View(applicationDbContext.ToList());
        //}



        // GET: Supervisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.SupervisorId == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // GET: Supervisors/Create
        public IActionResult Create()
        {
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupervisorId,Name,ApplicationId,PayRoll")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationUser, "Id", "Id", supervisor.ApplicationId);
            return View(supervisor);
        }


        // GET: Supervisors/Create
        public IActionResult CreateManager()
        {
            List<IdentityRole> ir = new List<IdentityRole>();
            ir = _context.Roles.ToList();
            ViewBag.listofitems = ir;
            ViewModels.CreateUserViewModel createUserViewModel = new ViewModels.CreateUserViewModel
            {
                IdentityRoles = ir
            };
  
            return View(createUserViewModel);

            //ViewData["ApplicationId"] = new SelectList(_context.Manager, "Id", "Id");
            //return RedirectToAction("Create", "Managers");
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateManager(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                
                {
                    UserName = createUserViewModel.Email,
                    Email = createUserViewModel.Email,
                };

                var result = await _userManager.CreateAsync(user, createUserViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, StaticDetails.Manager);
                }
                _logger.LogInformation("A Manager account was cereated with password");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return RedirectToAction("Index", "Supervisors");
        }
            //RegisterModel newManager = new RegisterModel();

            //var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
            //var result = await _userManager.CreateAsync(user, Input.Password);
            //if (result.Succeeded)
            //{
            //    _logger.LogInformation("User created a new account with password.");

            //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //    var callbackUrl = Url.Page(
            //        "/Account/ConfirmEmail",
            //        pageHandler: null,
            //        values: new { userId = user.Id, code = code },
            //        protocol: Request.Scheme);

            //    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
            //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            //    await _signInManager.SignInAsync(user, isPersistent: false);
            //    if (Input.IsSupervisor)
            //    {
            //        return RedirectToAction("Create", "Supervisors");
            //    }
            //}


            //if (ModelState.IsValid)
            //{
            //    Manager newManager = new Manager();

            //    newManager.ApplicationId = createUserViewModel.Manager.ApplicationId;
            //    newManager.ApplicationUser = createUserViewModel.Manager.ApplicationUser;
            //    newManager.ManagerId = createUserViewModel.Manager.ManagerId;
            //    newManager.Name = createUserViewModel.Manager.Name;
            //    newManager.PayRoll = createUserViewModel.Manager.PayRoll;


            //    _context.Add(newManager);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Index", "Supervisors");
            //}
            //ViewData["ApplicationId"] = new SelectList(_context.ApplicationUser, "Id", "Id", supervisor.ApplicationId);
            //return View(null);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateManager(string returnUrl = null)
        //{
        //    returnUrl = returnUrl ?? Url.Content("~/");
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
        //    }

        //}


        // GET: Supervisors/Create
        public IActionResult CreateEmployee()
        {
            List<IdentityRole> ir = new List<IdentityRole>();
            ir = _context.Roles.ToList();
            ViewBag.listofitems = ir;
            ViewModels.CreateUserViewModel createUserViewModel = new ViewModels.CreateUserViewModel
            {
                IdentityRoles = ir
            };

            return View(createUserViewModel);

            //ViewData["ApplicationId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            //return View();
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee([Bind("SupervisorId,Name,ApplicationId,PayRoll")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationUser, "Id", "Id", supervisor.ApplicationId);
            return View(supervisor);
        }

        // GET: Supervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationUser, "Id", "Id", supervisor.ApplicationId);
            return View(supervisor);
        }

        // POST: Supervisors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupervisorId,Name,ApplicationId,PayRoll")] Supervisor supervisor)
        {
            if (id != supervisor.SupervisorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorExists(supervisor.SupervisorId))
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
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationUser, "Id", "Id", supervisor.ApplicationId);
            return View(supervisor);
        }

        // GET: Supervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.SupervisorId == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisor = await _context.Supervisor.FindAsync(id);
            _context.Supervisor.Remove(supervisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorExists(int id)
        {
            return _context.Supervisor.Any(e => e.SupervisorId == id);
        }
    }
}
