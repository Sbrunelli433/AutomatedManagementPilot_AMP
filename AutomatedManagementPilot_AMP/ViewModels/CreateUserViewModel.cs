using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.ViewModels
{
    public class CreateUserViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Models.Employee> Employees { get; set; }
        public Manager Manager { get; set; }
        public IEnumerable<Models.Manager> Managers { get; set; }
        public RoleModel RoleModel { get; set; }
        public IEnumerable<Models.RoleModel> RoleModels { get; set; }

        public  IdentityRole IdentityRole { get; set; }
        public IEnumerable<IdentityRole> IdentityRoles { get; set; }

        //backup plan: manually enter string "Manager" or "Employee" when presenting
        // public string RoleSelection { get; set; }
    }
}
