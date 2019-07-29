using AutomatedManagementPilot_AMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.ViewModels
{
    public class SupervisorIndex
    {
        public Employee Employee { get; set; }
        public IEnumerable<Models.Employee> Employees { get; set; }
        public Manager Manager { get; set; }
        public IEnumerable<Models.Manager> Managers { get; set; }

        public Supervisor Supervisor { get; set; }
        public IEnumerable<Models.Supervisor> Supervisors { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Models.ApplicationUser> ApplicationUsers { get; set; }


    }
}
