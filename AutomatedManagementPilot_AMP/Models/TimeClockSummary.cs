using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class TimeClockSummary
    {
        [Key]
        public int TimeClockSumId { get; set; }

        [ForeignKey("TimeClockId")]
        public int TimeClockId { get; set; }
        public TimeClock TimeClock { get; set; }

        public string Summary { get; set; }
    }

}
