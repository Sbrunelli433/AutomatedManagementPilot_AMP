using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Name { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ApplicationUser User { get; set; }
        public double PayRoll { get; set; }
    }
}
