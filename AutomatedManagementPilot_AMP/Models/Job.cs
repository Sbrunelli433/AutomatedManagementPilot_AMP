using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Customer { get; set; }
        public string Part { get; set; }
        public int OrderQuantity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Progress { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public int SortOrder { get; set; }

        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public Employee Employee{ get; set; }


        [ForeignKey("MachineId")]
        public int? MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}

