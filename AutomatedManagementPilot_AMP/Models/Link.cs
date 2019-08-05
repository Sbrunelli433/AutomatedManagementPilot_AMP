using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int SourceJobId { get; set; }
        public int TargetJobId { get; set; }
    }
}
