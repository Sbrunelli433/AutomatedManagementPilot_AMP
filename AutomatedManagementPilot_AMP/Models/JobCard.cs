using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class JobCard
    {
        [Key]
        public int JobCardId { get; set; }

        public DateTime OperationClockIn { get; set; }
        public DateTime OperationClockOut { get; set; }

        public TimeSpan OperationTotal { get; set; }
        public int PartsMade { get; set; }
        public string Summary { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("ShopOrder")]
        public int ShopOrderNumber { get; set; }
        public ShopOrder ShopOrder { get; set; }








    }
}
