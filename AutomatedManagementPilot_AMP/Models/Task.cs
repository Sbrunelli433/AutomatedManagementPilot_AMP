using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Progress { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public int SortOrder { get; set; }
        public string Description { get; set; }
        public string Machine { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }

        public string PartName { get; set; }
        public decimal ShopOrderNumber { get; set; }
        public int OrderQuantity { get; set; }
    }
}
