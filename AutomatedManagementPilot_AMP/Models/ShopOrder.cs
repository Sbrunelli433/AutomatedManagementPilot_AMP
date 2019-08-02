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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime OrderRecDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime OrderDueDate { get; set; }

        [ForeignKey("MachineId")]
        public int? MachineId { get; set; }
        public Machine Machine { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime ScheduleStartTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime ScheduleEndTime { get; set; }

        public string OperationSetUp { get; set; }

        public TimeSpan OperationSetUpHours { get; set; }
        public string OperationProduction { get; set; }
        public TimeSpan OperationProductionHours { get; set; }

        public string OperationTearDown { get; set; }

        public TimeSpan OperationTearDownHours { get; set; }
        public decimal GrossProductionRate { get; set; }
        public decimal NetProductionRate { get; set; }
        public decimal Profitability { get; set; }
    }
}
