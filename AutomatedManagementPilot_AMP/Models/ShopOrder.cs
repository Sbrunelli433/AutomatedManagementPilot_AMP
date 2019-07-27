using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class ShopOrder
    {
        [Key]
        public int ShopOrderNumber { get; set; }

        public string Customer { get; set; }
        [MaxLength(6)]
        public int PartNumber { get; set; }
        [MaxLength(15)]
        public string PartName { get; set; }
        [MaxLength(25)]

        public int OrderQuantity { get; set; }
        [MaxLength(250000)]

        public string RawMatlInventoryId { get; set; }
        [MaxLength(8)]

        public DateTime OrderRecDate { get; set; }
        public DateTime OrderDueDate { get; set; }
        [ForeignKey("MachineId")]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public DateTime ScheduleStartTime { get; set; }
        public DateTime ScheduleEndTime { get; set; }

        public decimal OperationSetUpHours { get; set; }
        public decimal OperationProductionHours { get; set; }
        public decimal OperationEmpBreakHours { get; set; }
        public decimal OperationMachineBreakHours { get; set; }
        public decimal OperationTearDownHours { get; set; }
        public decimal GrossProductionRate { get; set; }
        public decimal NetProductionRate { get; set; }
        public decimal Profitability { get; set; }
    }
}
