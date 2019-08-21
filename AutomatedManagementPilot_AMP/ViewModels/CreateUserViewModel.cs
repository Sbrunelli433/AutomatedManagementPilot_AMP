using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        public Employee Employee { get; set; }
        public IEnumerable<Models.Employee> Employees { get; set; }
        public Manager Manager { get; set; }
        public IEnumerable<Models.Manager> Managers { get; set; }
        public RoleModel RoleModel { get; set; }
        public IEnumerable<Models.RoleModel> RoleModels { get; set; }
        public RegisterModel RegisterModel { get; set; }
        public IEnumerable<RegisterModel> RegisterModels { get; set; }
        public PageModel PageModel { get; set; }
        public IEnumerable<PageModel> PageModels { get; set; }

        public IdentityRole IdentityRole { get; set; }
        public IEnumerable<IdentityRole> IdentityRoles { get; set; }





        //backup plan: manually enter string "Manager" or "Employee" when presenting
        // public string RoleSelection { get; set; }
    }
}