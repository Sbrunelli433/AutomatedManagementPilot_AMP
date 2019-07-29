using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        public virtual ICollection<Supervisor> Supervisors { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        //public virtual ICollection<AllUsers> AllUsers { get; set; }
    }
}
