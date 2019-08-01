using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        public Decimal CycleTime { get; set; }
        public Decimal Utilization { get; set; }


        [ForeignKey("ShopOrder")]
        public int ShopOrderNumber { get; set; }
        public ShopOrder ShopOrder { get; set; }


    }
}
