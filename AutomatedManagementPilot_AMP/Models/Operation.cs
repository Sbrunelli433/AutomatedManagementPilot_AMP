using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }

        public string OperationName { get; set; }


    }
}
