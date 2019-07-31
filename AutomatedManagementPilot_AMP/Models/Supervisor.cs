using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class Supervisor
    {
        [Key]
        public int SupervisorId { get; set; }
        public string UserName { get; set; }



        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("RoleId")]
        public virtual IdentityRole Roles { get; set; }
        public double PayRoll { get; set; }
    }
}
