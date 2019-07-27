using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class TimeClock
    {
        [Key]
        public int TimeClockId { get; set; }

        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        public DateTime HoursWorked { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
